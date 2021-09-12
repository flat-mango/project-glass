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
    using System.Collections.Generic;
    using UnityEngine;
    using DllImports;

    using Process = System.Diagnostics.Process;
    using ProcessModule = System.Diagnostics.ProcessModule;
    

    /// <summary>
    /// Module that processes low level mouse input.
    /// </summary>
    public sealed class MouseInputModule : Module<MouseInputModule>
    {
        /// <summary>
        /// Map of low level mouse <b>down</b> notifications to Unity mouse buttons.
        /// </summary>
        private static readonly Dictionary<int, int> downMap = new Dictionary<int, int>
        {
            { (int)WM_MOUSE.LBUTTONDOWN, 0 },
            { (int)WM_MOUSE.MBUTTONDOWN, 2 },
            { (int)WM_MOUSE.RBUTTONDOWN, 1 },
        };

        /// <summary>
        /// Map of low level mouse <b>up</b> notifications to Unity mouse buttons.
        /// </summary>
        private static readonly Dictionary<int, int> upMap = new Dictionary<int, int>
        {
            { (int)WM_MOUSE.LBUTTONUP, 0 },
            { (int)WM_MOUSE.MBUTTONUP, 2 },
            { (int)WM_MOUSE.RBUTTONUP, 1 },
        };

        private IntPtr hook = IntPtr.Zero;

        /// <summary>
        /// Set of currently pressed mouse buttons.
        /// </summary>
        private readonly HashSet<int> pressed = new HashSet<int>();

        /// <summary>
        /// Position of the cursor.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                User32Dll.GetCursorPos(out Point point);
                return new Vector2(point.x, point.y);
            }
            set => User32Dll.SetCursorPos((int)value.x, (int)value.y);
        }

        public event Action<int> ButtonDown;
        public event Action<int> ButtonUp;


        private MouseInputModule()
        {

        }

        protected sealed override void OnEnable()
        {
            /*
             * Code sample taken from:
             * http://pinvoke.net/default.aspx/user32/SetWindowsHookEx.html
             */

            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr hMod = Kernel32Dll.GetModuleHandle(module.ModuleName);
                
                hook = User32Dll.SetWindowsHookEx((int)HookType.WH_MOUSE_LL, LowLevelMouseProc, hMod, 0);
            }
        }

        protected sealed override void OnDisable()
        {
            User32Dll.UnhookWindowsHookEx(hook);
            hook = IntPtr.Zero;
        }

        protected sealed override void OnUpdate()
        {
            
        }

        /// <summary>
        /// The system calls this function every time a new mouse input event is about 
        /// to be posted into a thread input queue.
        /// </summary>
        /// 
        /// <param name="nCode">
        /// A code the hook procedure uses to determine how to process the message. 
        /// If <b>nCode</b> is less than zero, the hook procedure must pass the message to 
        /// the <b>CallNextHookEx</b> function without further processing and should return 
        /// the value returned by <b>CallNextHookEx</b>.
        /// </param>
        /// 
        /// <param name="wParam">
        /// The identifier of the mouse message. This parameter can be one of the following messages: 
        /// WM_LBUTTONDOWN, WM_LBUTTONUP, WM_MOUSEMOVE, WM_MOUSEWHEEL, WM_MOUSEHWHEEL, WM_RBUTTONDOWN, 
        /// or WM_RBUTTONUP.
        /// </param>
        /// 
        /// <param name="lParam">
        /// A pointer to an <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msllhookstruct">
        /// MSLLHOOKSTRUCT</see> structure.
        /// </param>
        /// 
        /// <returns>
        /// If <paramref name="nCode"/> is less than zero, the hook procedure must 
        /// return the value returned by <b>CallNextHookEx</b>.
        /// If <paramref name="nCode"/> is greater than or equal to zero, and the hook procedure did not 
        /// process the message, it is highly recommended that you call <b>CallNextHookEx</b> 
        /// and return the value it returns; otherwise, other applications that have installed 
        /// <b>WH_MOUSE_LL</b> hooks will not receive hook notifications and may behave incorrectly 
        /// as a result. If the hook procedure processed the message, it may return a nonzero value 
        /// to prevent the system from passing the message to the rest of the hook chain or the target 
        /// window procedure.
        /// </returns>
        /// 
        /// <remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644986(v=vs.85)#remarks">
        /// LowLevelMouseProc.Remarks</seealso>
        /// </remarks>
        /// 
        /// SOME USEFUL INFO:
        /// 
        /// Q: Why <see cref="LowLevelMouseProc"/> has to be static?<br/>
        /// 
        /// A1: If the dwThreadId parameter of <see cref="User32Dll.SetWindowsHookEx"/> is 0 (this is our case) 
        /// or specifies the identifier of a thread created by a different process, the lpfn parameter 
        /// must point to a hook procedure in a DLL (i.e. static method). Otherwise, lpfn 
        /// can point to a hook procedure in the code associated with the current process.
        /// 
        /// A2: Also I found an interesting remark on pinvoke.net (https://pinvoke.net/default.aspx/user32/SetWindowsHookEx.html):
        /// "Remember to keep the <see cref="HookProc"/> delegate alive manually, such as using a class member 
        /// as shown in the example below, otherwise the garbage collector will clean up your hook delegate 
        /// eventually, resulting in your code throwing a <see cref="NullReferenceException"/>".
        /// I've tried different approaches to save this delegate (including one mentioned on pinvoke page) with no luck.
        /// <see cref="NullReferenceException"/> was thrown all the time on the very first low level mouse callback.
        /// 
        /// 
        /// Q: Why <b>dwThreadId</b> has to be 0?
        /// 
        /// A: if this parameter is zero, the hook procedure is associated with <b>all</b> existing threads 
        /// running in the same desktop as the calling thread.
        /// 
        /// 
        /// Q: So why is it 0?
        /// 
        /// A: The scope of a hook depends on the hook type. Some hooks can be set only with global scope; 
        /// others can also be set for only a specific thread. WH_MOUSE_LL which we use to hook mouse events
        /// can be set only in global scope (i.e. "all existing threads running in the same desktop as the
        /// calling thread" - from the previous answer).
        private static IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return User32Dll.CallNextHookEx(instance.hook, nCode, wParam, lParam);
            
            int notificationCode = (int)wParam;

            if (downMap.TryGetValue(notificationCode, out int keyCode))
            {
                instance.pressed.Add(keyCode);
                instance.ButtonDown?.Invoke(keyCode);
            }
            else if (upMap.TryGetValue(notificationCode, out keyCode))
            {
                instance.pressed.Remove(keyCode);
                instance.ButtonUp?.Invoke(keyCode);
            }

            return User32Dll.CallNextHookEx(instance.hook, nCode, wParam, lParam);
        }

        public bool GetButtonPressed(int button) => pressed.Contains(button);
    }
}
