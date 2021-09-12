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
    /// Window handles (HWND) used for hWndInsertAfter.
    /// </summary>
    internal enum SpecialHWND
    {
        /// <summary>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). 
        /// This flag has no effect if the window is already a non-topmost window.
        /// </summary>
        NOTOPMOST = -2,
        /// <summary>
        /// Places the window above all non-topmost windows. The window maintains its topmost 
        /// position even when it is deactivated.
        /// </summary>
        TOPMOST = -1,
        /// <summary>
        /// Places the window at the top of the Z order.
        /// </summary>
        /// <remarks>
        /// <see cref="TOP"/> will bring a window to the front of the Z-Order only if the thread is in the foreground. 
        /// Otherwise it will bring the window to the front of the thread's Z-order.
        /// </remarks>
        TOP = 0,
        /// <summary>
        /// Places the window at the bottom of the Z order. If the <b>hWnd</b> parameter identifies 
        /// a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </summary>
        BOTTOM = 1,
    }
}
