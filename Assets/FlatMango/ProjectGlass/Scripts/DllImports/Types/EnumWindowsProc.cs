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
    using IntPtr = System.IntPtr;

    /// <summary>
    /// An application-defined callback function used with the <b>EnumWindows</b> or 
    /// <see cref="User32Dll.EnumDesktopWindows"/> function. It receives top-level 
    /// window handles. The <see cref="EnumWindowsProc"/> type defines a pointer to this callback function.
    /// </summary>
    /// 
    /// <param name="hWnd">A handle to a top-level window.</param>
    /// 
    /// <param name="lParam">
    /// The application-defined value given in EnumWindows or EnumDesktopWindows.
    /// </param>
    /// 
    /// <returns>
    /// To continue enumeration, the callback function must return TRUE; 
    /// to stop enumeration, it must return FALSE.
    /// </returns>
    delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
}
