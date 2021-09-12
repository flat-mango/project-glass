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
    using DllImports;

    using Process = System.Diagnostics.Process;
    using ProcessModule = System.Diagnostics.ProcessModule;
    using Marshal = System.Runtime.InteropServices.Marshal;
    using KeyCode = UnityEngine.KeyCode;


    /// <summary>
    /// Module that processes low level keyboard input.
    /// </summary>
    public sealed class KeyboardInputModule : Module<KeyboardInputModule>
    {
        /// <summary>
        /// Map of low level keyboard notifications to UnityEngine.<see cref="KeyCode"/>.
        /// 
        /// <br/><br/>
        /// 
        /// Taken from:<br/>
        /// 1. <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes">Virtual Key Codes</see><br/>
        /// 2. <see href="https://docs.unity3d.com/ScriptReference/KeyCode.html">UnityEngine.KeyCode</see>
        /// </summary>
        private readonly static Dictionary<int, KeyCode> keysMap = new Dictionary<int, KeyCode>()
        {
            { 0x01, KeyCode.Mouse0 },
            { 0x02, KeyCode.Mouse1 },
            { 0x03, KeyCode.Break },
            { 0x04, KeyCode.Mouse2 },
            { 0x05, KeyCode.Mouse3 },
            { 0x06, KeyCode.Mouse4 },
            { 0x08, KeyCode.Backspace },
            { 0x09, KeyCode.Tab },
            { 0x0C, KeyCode.Clear },
            { 0x0D, KeyCode.Return },

            { 0x13, KeyCode.Pause },
            { 0x14, KeyCode.CapsLock },
            { 0x1B, KeyCode.Escape },

            { 0x20, KeyCode.Space },
            { 0x21, KeyCode.PageUp },
            { 0x22, KeyCode.PageDown },
            { 0x23, KeyCode.End },
            { 0x24, KeyCode.Home },
            { 0x25, KeyCode.LeftArrow },
            { 0x26, KeyCode.UpArrow },
            { 0x27, KeyCode.RightArrow },
            { 0x28, KeyCode.DownArrow },
            { 0x2A, KeyCode.Print },
            { 0x2C, KeyCode.Colon },
            { 0x2D, KeyCode.Insert },
            { 0x2E, KeyCode.Delete },
            { 0x2F, KeyCode.Help },

            { 0x30, KeyCode.Alpha0 },
            { 0x31, KeyCode.Alpha1 },
            { 0x32, KeyCode.Alpha2 },
            { 0x33, KeyCode.Alpha3 },
            { 0x34, KeyCode.Alpha4 },
            { 0x35, KeyCode.Alpha5 },
            { 0x36, KeyCode.Alpha6 },
            { 0x37, KeyCode.Alpha7 },
            { 0x38, KeyCode.Alpha8 },
            { 0x39, KeyCode.Alpha9 },
            { 0x3C, KeyCode.Less },
            { 0x3D, KeyCode.Equals },
            { 0x3E, KeyCode.Greater },
            { 0x3F, KeyCode.Question },

            { 0x40, KeyCode.At },
            { 0x41, KeyCode.A },
            { 0x42, KeyCode.B },
            { 0x43, KeyCode.C },
            { 0x44, KeyCode.D },
            { 0x45, KeyCode.E },
            { 0x46, KeyCode.F },
            { 0x47, KeyCode.G },
            { 0x48, KeyCode.H },
            { 0x49, KeyCode.I },
            { 0x4A, KeyCode.J },
            { 0x4B, KeyCode.K },
            { 0x4C, KeyCode.L },
            { 0x4D, KeyCode.M },
            { 0x4E, KeyCode.N },
            { 0x4F, KeyCode.O },
            { 0x50, KeyCode.P },
            { 0x51, KeyCode.Q },
            { 0x52, KeyCode.R },
            { 0x53, KeyCode.S },
            { 0x54, KeyCode.T },
            { 0x55, KeyCode.U },
            { 0x56, KeyCode.V },
            { 0x57, KeyCode.W },
            { 0x58, KeyCode.X },
            { 0x59, KeyCode.Y },
            { 0x5A, KeyCode.Z },
            { 0x5B, KeyCode.LeftWindows },
            { 0x5C, KeyCode.RightWindows },
            { 0x5E, KeyCode.Caret },
            { 0x5F, KeyCode.Underscore },

            { 0x6A, KeyCode.Asterisk },

            { 0x70, KeyCode.F1 },
            { 0x71, KeyCode.F2 },
            { 0x72, KeyCode.F3 },
            { 0x73, KeyCode.F4 },
            { 0x74, KeyCode.F5 },
            { 0x75, KeyCode.F6 },
            { 0x76, KeyCode.F7 },
            { 0x77, KeyCode.F8 },
            { 0x78, KeyCode.F9 },
            { 0x79, KeyCode.F10 },
            { 0x7A, KeyCode.F11 },
            { 0x7B, KeyCode.F12 },
            { 0x7C, KeyCode.F13 },
            { 0x7D, KeyCode.F14 },
            { 0x7E, KeyCode.F15 },

            { 0x90, KeyCode.Numlock },
            { 0x91, KeyCode.ScrollLock },

            { 0xA0, KeyCode.LeftShift },
            { 0xA1, KeyCode.RightShift },
            { 0xA2, KeyCode.LeftControl },
            { 0xA3, KeyCode.RightControl },
            { 0xA4, KeyCode.LeftAlt },
            { 0xA5, KeyCode.RightAlt },

            { 0xBA, KeyCode.Semicolon },
            { 0xBB, KeyCode.Plus },
            { 0xBC, KeyCode.Comma },
            { 0xBD, KeyCode.Minus },
            { 0xBE, KeyCode.Period },
            { 0xBF, KeyCode.Slash },
            
            { 0xC0, KeyCode.BackQuote },

            { 0xDB, KeyCode.LeftBracket},
            { 0xDC, KeyCode.Backslash },
            { 0xDD, KeyCode.RightBracket},
            { 0xDE, KeyCode.Quote },
            { 0xDF, KeyCode.Exclaim },
        };

        /// <summary>
        /// Repeats count for all of the registered <b>Unity KeyCodes</b>.
        /// </summary>
        private readonly static Dictionary<int, int> keysRepeats;

        private IntPtr hook = IntPtr.Zero;

        public event Action<KeyCode> KeyDown;
        public event Action<KeyCode> KeyUp;

        /// <summary>
        /// Set of currently pressed keys.
        /// </summary>
        private readonly HashSet<KeyCode> pressed = new HashSet<KeyCode>();


        static KeyboardInputModule()
        {
            keysRepeats = new Dictionary<int, int>(keysMap.Count);

            foreach (int key in keysMap.Values)
                keysRepeats.Add(key, default);
        }

        private KeyboardInputModule()
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

                hook = User32Dll.SetWindowsHookEx((int)HookType.WH_KEYBOARD_LL, LowLevelKeyboardProc, hMod, 0);
            }
        }

        protected sealed override void OnDisable()
        {
            User32Dll.UnhookWindowsHookEx(hook);
            hook = IntPtr.Zero;
        }

        protected sealed override void OnUpdate() { }

        /// <summary>
        /// The system calls this function every time a new keyboard input event is about 
        /// to be posted into a thread input queue. <br/>
        /// Note: When this callback function is called in response to a change in the state 
        /// of a key, the callback function is called before the asynchronous state of the key 
        /// is updated. Consequently, the asynchronous state of the key cannot be determined by 
        /// calling <see href="https://msdn.microsoft.com/en-us/library/ms646293(v=vs.85)">GetAsyncKeyState</see> 
        /// from within the callback function.
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
        /// The identifier of the keyboard message. This parameter can be one of the following messages: 
        /// WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP.
        /// </param>
        /// 
        /// <param name="lParam">
        /// A pointer to a <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-kbdllhookstruct">
        /// KBDLLHOOKSTRUCT</see> structure.
        /// </param>
        /// 
        /// <returns>
        /// If <paramref name="nCode"/> is less than zero, the hook procedure must 
        /// return the value returned by <b>CallNextHookEx</b>.
        /// If <paramref name="nCode"/> is greater than or equal to zero, and the hook procedure did not 
        /// process the message, it is highly recommended that you call <b>CallNextHookEx</b> 
        /// and return the value it returns; otherwise, other applications that have installed 
        /// <b>WH_KEYBOARD_LL</b> hooks will not receive hook notifications and may behave incorrectly 
        /// as a result. If the hook procedure processed the message, it may return a nonzero value 
        /// to prevent the system from passing the message to the rest of the hook chain or the target 
        /// window procedure.
        /// </returns>
        /// 
        /// <remarks>
        /// <see href="https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms644985(v=vs.85)#remarks">
        /// LowLevelKeyboardProc.Remarks</see>
        /// </remarks>
        /// 
        /// SOME USEFUL INFO:
        /// 
        /// Q: Why <see cref="LowLevelKeyboardProc"/> has to be static?<br/>
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
        /// others can also be set for only a specific thread. WH_KEYBOARD_LL which we use to hook keyboard events
        /// can be set only in global scope (i.e. "all existing threads running in the same desktop as the
        /// calling thread" - from the previous answer).
        private static IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
         {
            if (nCode < 0)
                return User32Dll.CallNextHookEx(instance.hook, nCode, wParam, lParam);

            /*
             * Why Marshal here? In current context lParams is a pointer to a KBDLLHOOKSTRUCT structure 
             * which contains information about a low-level keyboard input event. First 4 bytes (i.e. DWORD/ 32 bits)
             * holds information about virtual key code. So we use Marshal.ReadInt32() to read this data.
             * 
             * More info about KBDLLHOOKSTRUCT: https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-kbdllhookstruct
             * 
             */

            int notificationCode = Marshal.ReadInt32(lParam);
            
            if (!keysMap.TryGetValue(notificationCode, out KeyCode keyCode))
                return User32Dll.CallNextHookEx(instance.hook, nCode, wParam, lParam);

            if (wParam == (IntPtr)WM_KEYBOARD.KEYDOWN)
            {
                int keyRepeats = keysRepeats[(int)keyCode];

                if (keyRepeats == 0)
                {
                    instance.pressed.Add(keyCode);
                    instance.KeyDown?.Invoke(keyCode);
                }

                keysRepeats[(int)keyCode] = ++keyRepeats;
            }
            else if (wParam == (IntPtr)WM_KEYBOARD.KEYUP)
            {
                keysRepeats[(int)keyCode] = 0;
                instance.pressed.Remove(keyCode);
                instance.KeyUp?.Invoke(keyCode);
            }

            return User32Dll.CallNextHookEx(instance.hook, nCode, wParam, lParam);
        }

        public bool GetKeyPressed(KeyCode key) => keysRepeats[(int)key] > 0;
    }
}
