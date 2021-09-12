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
    internal enum GWL
    {
        /// <summary>
        /// Retrieves the address of the window procedure, or a handle representing the address of the window procedure. 
        /// You must use the <see href="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-callwindowproca">
        /// CallWindowProc</see> function to call the window procedure. 
        /// </summary>
        WNDPROC = -4,

        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        HINSTANCE = -6,

        /// <summary>
        /// Retrieves a handle to the parent window, if any.
        /// </summary>
        HWNDPARENT = -8,

        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        ID = -12,

        /// <summary>
        /// Retrieves the <see href="https://docs.microsoft.com/en-us/windows/desktop/winmsg/window-styles">
        /// window styles</see>.
        /// </summary>
        STYLE = -16,

        /// <summary>
        /// Retrieves the <see href="https://docs.microsoft.com/en-us/windows/desktop/winmsg/extended-window-styles">
        /// extended window styles</see>.
        /// </summary>
        EXSTYLE = -20,

        /// <summary>
        /// Retrieves the user data associated with the window. This data is intended for use 
        /// by the application that created the window. Its value is initially zero.
        /// </summary>
        USERDATA = -21,
    }
}
