/*

Project Glass
Made by Oleh Zahorodnii (Flat Mango)

The MIT License (MIT)

Copyright © 2021 Oleh Zahorodnii (Flat Mango)


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/
namespace FlatMango.ProjectGlass
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using DllImports;

    using Marshal = System.Runtime.InteropServices.Marshal;


    /// <summary>
    /// Module that processes windows.
    /// </summary>
    public sealed class WindowsModule : Module<WindowsModule>, IEnumerable<Window>
    {
        private readonly List<Window> registry;

        public Window MainWindow { get; private set; }
        public Window FocusedWindow { get; private set; }

        public int Count => registry.Count;

        public event Action<Window> Opened;
        public event Action<Window> Closed;


        private WindowsModule()
        {
            registry = new List<Window>();

            IntPtr hWndMain = User32Dll.GetActiveWindow();
            MainWindow = new Window(hWndMain);
        }

        protected sealed override void OnEnable() { }
        protected sealed override void OnDisable() { }

        protected sealed override void OnUpdate()
        {
            IntPtr hWndShell = User32Dll.GetShellWindow();
            
            foreach (Window window in registry)
                window.Status = WindowStatus.Close;


            /// <see cref="EnumWindowsProc"/> has to be application-defined function so no need to
            /// implement it as a static function. Also defining it as local function will provide
            /// us ablity to capture variables from the current context, e.g. <see cref="hWndShell"/>

            bool EnumWindowsProc(IntPtr hWnd, int lParam)
            {
                if (hWnd == hWndShell)
                    return true;

                /// This check wouldn't let us filter all of the not visible windows. Why?
                /// Excerpt from the <see cref="User32Dll.IsWindowVisible"/> remarks:
                /// 
                /// Because the return value specifies whether the window has the <see cref="WS.VISIBLE"/> style, 
                /// it may be nonzero even if the window is totally obscured by other windows.
                /// 
                /// At this moment we're just filtering windows that are explicitly not visible.
                /// (i.e. has no <see cref="WS.VISIBLE"/> style).

                if (!User32Dll.IsWindowVisible(hWnd))
                    return true;

                /// So, how do we determine wether the window is not <b>really</b>visible?
                /// And why window can be visible but not visible at the same time? (WAT)
                /// This is where concept of cloaking comes into the game.
                /// See <see href="https://devblogs.microsoft.com/oldnewthing/20200302-00/?p=103507">this
                /// blog post</see> for more info. Usage sample has taken from there.
                /// 
                /// Why Marshal.SizeOf() instead of sizeof()?
                /// <see href="https://ericlippert.com/2013/06/13/whats-the-difference-sizeof-and-marshal-sizeof/"/>

                DwmApiDll.DwmGetWindowAttribute(hWnd, (int)DWMWA.CLOAKED, out bool pvAttribute, Marshal.SizeOf(typeof(bool)));

                if (pvAttribute) 
                   return true;

                int length = User32Dll.GetWindowTextLength(hWnd);
                
                /// 0 here means failure of <see cref="User32Dll.GetWindowTextLength"/> function.
                /// So we skip current window in such case.
                if (length == 0)
                    return true;

                Window window = registry.Find(w => w.HWnd == hWnd);

                if (window != null)
                    window.Status = WindowStatus.Update;
                else
                {
                    window = new Window(hWnd);
                    registry.Add(window);
                }

                return true;
            }

            /// <see cref="IntPtr.Zero"/> is currently used as <b>hDesktop</b> parameter value meaning
            /// enumeration of only current desktop windows.
            /// 
            /// TODO: Ivestigate functionality extension by taking into account windows on the other desktops.
            User32Dll.EnumDesktopWindows(IntPtr.Zero, EnumWindowsProc, IntPtr.Zero);

            /// At this point we still have some invisible suspended apps registered for some reason
            /// (e.g. Calculator, Settings, Microsoft Store, some untitled apps).
            /// 
            /// TODO: Investigate possibility to filter <b>all</b> invisible apps.
            /// https://docs.microsoft.com/en-us/windows/win32/winmsg/window-features

            for (int i = 0; i < registry.Count;)
            {
                Window window = registry[i];

                if (window.Status == WindowStatus.Close)
                {
                    registry.RemoveAt(i);
                    Closed?.Invoke(window);
                    (window as IDisposable).Dispose();
                    continue;
                }

                if (window.Status == WindowStatus.Update)
                    window.Update();

                if (window.Status == WindowStatus.Open)
                    Opened?.Invoke(window);

                window.Status = WindowStatus.Update;

                i++;
            }
            
            IntPtr hWndFocused = User32Dll.GetForegroundWindow();

            if (hWndFocused == IntPtr.Zero)
            {
                FocusedWindow = null;
                return;
            }    

            FocusedWindow = registry.Find(w => w.HWnd == hWndFocused);
        }


        public IEnumerator<Window> GetEnumerator() => new Enumerator(registry);
        IEnumerator IEnumerable.GetEnumerator() => new Enumerator(registry);


        public struct Enumerator : IEnumerator<Window>, IDisposable
        {
            private readonly IReadOnlyList<Window> registry;
            private int index;
            private Window current;

            public Window Current => current;
            object IEnumerator.Current => current;

            internal Enumerator(IReadOnlyList<Window> registry)
            {
                this.registry = registry;
                this.index = 0;
                this.current = default;
            }

            public bool MoveNext()
            {
                if (index < registry.Count)
                {
                    current = registry[index];
                    index++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                index = 0;
                current = default;
            }

            public void Dispose() { }
        }
    }
}
