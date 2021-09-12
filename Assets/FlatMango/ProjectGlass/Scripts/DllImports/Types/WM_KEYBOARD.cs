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
namespace FlatMango.ProjectGlass.DllImports
{
    /// <summary>
    /// Enumerates keyboard input notigications.
    /// https://docs.microsoft.com/en-us/windows/win32/inputdev/keyboard-input
    /// </summary>
    internal enum WM_KEYBOARD
    {
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-setfocus"/>
        /// </summary>
        SETFOCUS = 0x0007,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-killfocus"/>
        /// </summary>
        KILLFOCUS = 0x0008,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-activate"/>
        /// </summary>
        ACTIVATE = 0x0006,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keydown"/>
        /// </summary>
        KEYDOWN = 0x0100,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keyup"/>
        /// </summary>
        KEYUP = 0x0101,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-char"/>
        /// </summary>
        CHAR = 0x0102,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-deadchar"/>
        /// </summary>
        DEADCHAR = 0x0103,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-syskeydown"/>
        /// </summary>
        SYSKEYDOWN = 0x0104,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-syskeyup"/>
        /// </summary>
        SYSKEYUP = 0x0105,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-sysdeadchar"/>
        /// </summary>
        SYSDEADCHAR = 0x0107,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-unichar"/>
        /// </summary>
        UNICHAR = 0x0109,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-hotkey"/>
        /// </summary>
        HOTKEY = 0x0312,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-appcommand"/>
        /// </summary>
        APPCOMMAND = 0x0319,
    }
}
