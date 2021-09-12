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
    /// Enumerates mouse input notifications.
    /// https://docs.microsoft.com/en-us/windows/win32/inputdev/mouse-input
    /// </summary>
    internal enum WM_MOUSE
    {
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest"/>
        /// </summary>
        NCHITTEST = 0x0084,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmousemove"/>
        /// </summary>
        NCMOUSEMOVE = 0x00A0,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttondown"/>
        /// </summary>
        NCLBUTTONDOWN = 0x00A1,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttonup"/>
        /// </summary>
        NCLBUTTONUP = 0x00A2,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttondblclk"/>
        /// </summary>
        NCLBUTTONDBLCLK = 0x00A3,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttondown"/>
        /// </summary>
        NCRBUTTONDOWN = 0x00A4,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttonup"/>
        /// </summary>
        NCRBUTTONUP = 0x00A5,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttondblclk"/>
        /// </summary>
        NCRBUTTONDBLCLK = 0x00A6,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttondown"/>
        /// </summary>
        NCMBUTTONDOWN = 0x00A7,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttonup"/>
        /// </summary>
        NCMBUTTONUP = 0x00A8,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttondblclk"/>
        /// </summary>
        NCMBUTTONDBLCLK = 0x00A9,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttondown"/>
        /// </summary>
        NCXBUTTONDOWN = 0x00AB,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttonup"/>
        /// </summary>
        NCXBUTTONUP = 0x00AC,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttondblclk"/>
        /// </summary>
        NCXBUTTONDBLCLK = 0x00AD,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousemove"/>
        /// </summary>
        MOUSEMOVE = 0x0200,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttondown"/>
        /// </summary>
        LBUTTONDOWN = 0x0201,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttonup"/>
        /// </summary>
        LBUTTONUP = 0x0202,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttondblclk"/>
        /// </summary>
        LBUTTONDBLCLK = 0x0203,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttondown"/>
        /// </summary>
        RBUTTONDOWN = 0x0204,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttonup"/>
        /// </summary>
        RBUTTONUP = 0x0205,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttondblclk"/>
        /// </summary>
        RBUTTONDBLCLK = 0x0206,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttondown"/>
        /// </summary>
        MBUTTONDOWN = 0x0207,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttonup"/>
        /// </summary>
        MBUTTONUP = 0x0208,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttondblclk"/>
        /// </summary>
        MBUTTONDBLCLK = 0x0209,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttondown"/>
        /// </summary>
        XBUTTONDOWN = 0x020B,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttonup"/>
        /// </summary>
        XBUTTONUP = 0x020C,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttondblclk"/>
        /// </summary>
        XBUTTONDBLCLK = 0x020D,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-capturechanged"/>
        /// </summary>
        CAPTURECHANGED = 0x0215,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mouseactivate"/>
        /// </summary>
        MOUSEACTIVATE = 0x0021,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousewheel"/>
        /// </summary>
        MOUSEWHEEL = 0x020A,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousehwheel"/>
        /// </summary>
        MOUSEHWHEEL = 0x020E,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmousehover"/>
        /// </summary>
        NCMOUSEHOVER = 0x02A0,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousehover"/>
        /// </summary>
        MOUSEHOVER = 0x02A1,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmouseleave"/>
        /// </summary>
        NCMOUSELEAVE = 0x02A2,
        /// <summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mouseleave"/>
        /// </summary>
        MOUSELEAVE = 0x02A3,
    }
}
