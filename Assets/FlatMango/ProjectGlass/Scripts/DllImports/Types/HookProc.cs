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
    /// Represents the method called when a hook catches a monitored event.
    /// </summary>
    /// 
    /// <param name="nCode">
    /// </param>
    /// 
    /// <param name="wParam">
    /// </param>
    /// 
    /// <param name="lParam">
    /// </param>
    /// 
    /// <returns>
    /// </returns>
    /// 
    /// <remarks>
    /// Remember to keep the <see cref="HookProc"/> delegate alive manually, 
    /// such as using a class member as shown in the example below, otherwise the 
    /// garbage collector will clean up your hook delegate eventually, resulting 
    /// in your code throwing a <see cref="System.NullReferenceException"/>.
    /// </remarks>
    delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
}
