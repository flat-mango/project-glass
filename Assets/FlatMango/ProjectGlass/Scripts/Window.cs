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
    using UnityEngine;
    using DllImports;
    
    using StringBuilder = System.Text.StringBuilder;


    [System.Diagnostics.DebuggerDisplay("{hWnd} {titleBuilder}")]
    public sealed class Window : IEquatable<Window>, IDisposable
    {
        private readonly IntPtr hWnd;
        private readonly uint baseStyle;

        private readonly uint threadId;
        private readonly uint processId;

        private NativeRect nativeRect;
        private Rect rect;

        private readonly StringBuilder titleBuilder;
        private const int MAX_TITLE_LENGTH = 256;

        internal WindowStatus Status { get; set; } = WindowStatus.Open;
        internal IntPtr HWnd => hWnd;

        public uint ThreadId => threadId;
        public uint ProcessId => processId;

        public Rect Rect => rect;

        /// Useful post regarding positioning windows with multiple monitors
        /// <see cref="https://stackoverflow.com/a/53026765"/>
        /// 
        /// TODO: Investigate.
        public Vector2 Position
        {
            get => rect.position;
            set
            {
                if (User32Dll.MoveWindow(hWnd, (int)value.x, (int)value.y, (int)rect.width, (int)rect.height, true))
                    rect.Set(value.x, value.y, rect.width, rect.height);
            }
        }

        public Vector2 Size
        {
            get => rect.size;
            set
            {
                if (User32Dll.MoveWindow(hWnd, (int)rect.x, (int)rect.y, (int)value.x, (int)value.y, true))
                    rect.Set(rect.x, rect.y, value.x, value.y);
            }
        }

        public string Title
        {
            get => titleBuilder.ToString();
            set
            {
                User32Dll.SetWindowText(hWnd, value);
                UpdateTitle();
            }
        }


        internal Window(IntPtr hWnd)
        {
            this.hWnd = hWnd;

            threadId = User32Dll.GetWindowThreadProcessId(hWnd, out processId);
            baseStyle = User32Dll.GetWindowLong(hWnd, (int)GWL.STYLE);
            titleBuilder = new StringBuilder(MAX_TITLE_LENGTH);

            Update();
        }

        internal void Update()
        {
            UpdateRect();
            UpdateTitle();
        }

        private void UpdateRect()
        {
            User32Dll.GetWindowRect(hWnd, ref nativeRect);
            rect.Set(nativeRect.left, nativeRect.top, nativeRect.Width, nativeRect.Height);
        }

        private void UpdateTitle()
        {
            /// Excerpt from the <see cref="User32Dll.GetWindowText"/> remarks:
            /// To retrieve the text of a control in another process, send a <see cref="WM.GETTEXT"/> message directly 
            /// instead of calling <see cref="GetWindowText"/>.
            /// 
            /// TODO: Investigate this topic.

            User32Dll.GetWindowText(hWnd, titleBuilder, MAX_TITLE_LENGTH);
        }

        public void SetTopMost(bool value)
        {
            /// Remark from <see cref="User32Dll.SetWindowPos"/> function:
            /// 
            /// A window can be made a topmost window either by setting the <b>hWndInsertAfter</b> parameter to 
            /// <see cref="SpecialHWND.TOPMOST"/> and ensuring that the <see cref="SWP.NOZORDER"/> flag is not set, 
            /// or by setting a window's position in the Z order so that it is above any existing topmost windows.
            /// 
            /// So the first option is what we're going to deal with here.

            int hWndInsertAfter = value ? (int)SpecialHWND.TOPMOST : (int)SpecialHWND.NOTOPMOST;
            int uFlags = (int)SWP.DRAWFRAME | (int)SWP.NOOWNERZORDER | (int)SWP.NOMOVE | (int)SWP.NOSIZE;

            /// Also we're going to just make this window topmost or not topmost so no need to provide any
            /// values for x, y, cx and xy. We can pass 0 and use <see cref="SWP.NOMOVE"/> and <see cref="SWP.NOSIZE"/>
            /// flags for these parameters to be ignored.

            User32Dll.SetWindowPos(hWnd, hWndInsertAfter, 0, 0, 0, 0, uFlags);
        }

        public void SetTransparent(bool value)
        {
            uint dwNewLong = value ? (uint)WS.POPUP | (uint)WS.VISIBLE : baseStyle;
            User32Dll.SetWindowLong(hWnd, (int)GWL.STYLE, dwNewLong);

            /// Above lines seem to work fine. But there is remark to <see cref="User32Dll.SetWindowPos"/> function:
            /// 
            /// If you have changed certain window data using <see cref="User32Dll.SetWindowLong"/>, you must call 
            /// <see cref="User32Dll.SetWindowPos"/> for the changes to take effect. Use the following combination for uFlags: 
            /// <see cref="SWP.NOMOVE"/> | <see cref="SWP.NOSIZE"/> | <see cref="SWP.NOZORDER"/> | <see cref="SWP_FRAMECHANGED"/>.
            /// 
            /// TODO: Investigate.

            int marginValue = value ? -1 : 0;
            Margins pMarInset = new Margins
            {
                cxLeftWidth = marginValue,
                cxRightWidth = marginValue,
                cyTopHeight = marginValue,
                cyBottomHeight = marginValue
            };

            DwmApiDll.DwmExtendFrameIntoClientArea(hWnd, ref pMarInset);
        }

        public void SetClickThrough(bool value)
        {
            uint currentStyle = User32Dll.GetWindowLong(hWnd, (int)GWL.EXSTYLE);

            /// Q: Why using <see cref="WS_EX.LAYERED"/> here?
            /// A: Using a layered window can significantly improve performance and visual effects for a window that 
            /// has a complex shape, animates its shape, or wishes to use alpha blending effects. The system 
            /// automatically composes and repaints layered windows and the windows of underlying applications. 
            /// As a result, layered windows are rendered smoothly, without the flickering typical of complex 
            /// window regions. In addition, layered windows can be partially translucent, that is, alpha-blended.
            /// 
            /// For more information, read this page:
            /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/window-features#layered-windows"/>

            if (value)
                User32Dll.SetWindowLong(hWnd, (int)GWL.EXSTYLE, currentStyle | (uint)WS_EX.LAYERED | (uint)WS_EX.TRANSPARENT);
            else
                User32Dll.SetWindowLong(hWnd, (int)GWL.EXSTYLE, currentStyle & ~((int)WS_EX.LAYERED | (uint)WS_EX.TRANSPARENT));


            /// Above lines seem to work fine. But there is remark to <see cref="User32Dll.SetWindowPos"/> function:
            /// 
            /// If you have changed certain window data using <see cref="User32Dll.SetWindowLong"/>, you must call 
            /// <see cref="User32Dll.SetWindowPos"/> for the changes to take effect. Use the following combination for uFlags: 
            /// <see cref="SWP.NOMOVE"/> | <see cref="SWP.NOSIZE"/> | <see cref="SWP.NOZORDER"/> | <see cref="SWP_FRAMECHANGED"/>.
            /// 
            /// TODO: Investigate.
        }

        public void Focus() => User32Dll.SetForegroundWindow(hWnd);

        public void Minimize() => User32Dll.ShowWindow(hWnd, (int)SW.MINIMIZE);
        public void Restore() => User32Dll.ShowWindow(hWnd, (int)SW.RESTORE);
        public void Maximize() => User32Dll.ShowWindow(hWnd, (int)SW.SHOWMAXIMIZED);


        public override bool Equals(object obj)
        {
            if (obj is Window window)
                return Equals(window);

            return false;
        }

        public bool Equals(Window other)
        {
            if (other == null)
                return false;

            return hWnd == other.hWnd;
        }

        public override int GetHashCode()
        {
            return hWnd.ToInt32();
        }

        public void Dispose()
        {
            titleBuilder.Clear();
        }

        public static bool operator ==(Window w1, Window w2)
        {
            if (ReferenceEquals(w1, w2))
                return true;
            else if (ReferenceEquals(w1, null))
                return false;
            else if (ReferenceEquals(w2, null))
                return false;

            return w1.Equals(w2);
        }

        public static bool operator !=(Window w1, Window w2) => !(w1 == w2);
    }
}
