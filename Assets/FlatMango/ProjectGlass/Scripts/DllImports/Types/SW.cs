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
    /// <see cref="User32Dll.ShowWindow"/> commands.
    /// </summary>
    internal enum SW
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        HIDE,

        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system 
        /// restores it to its original size and position. An application should specify this 
        /// flag when displaying the window for the first time.
        /// </summary>
        SHOWNORMAL,

        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SHOWMINIMIZED,

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SHOWMAXIMIZED,

        /// <summary>
        /// Displays a window in its most recent size and position. This value is similar to 
        /// <see cref="SHOWNORMAL"/>, except that the window is not activated.
        /// </summary>
        SHOWNOACTIVATE,

        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        SHOW,

        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        MINIMIZE,

        /// <summary>
        /// Displays the window as a minimized window. This value is similar to <see cref="SW.SHOWMINIMIZED"/>, 
        /// except the window is not activated.
        /// </summary>
        SHOWMINNOACTIVE,

        /// <summary>
        /// Displays the window in its current size and position. This value is similar to <see cref="SW.SHOW"/>, 
        /// except that the window is not activated.
        /// </summary>
        SHOWNA,

        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to 
        /// its original size and position. An application should specify this flag when restoring a minimized window.
        /// </summary>
        RESTORE,

        /// <summary>
        /// Sets the show state based on the <b>SW_</b> value specified in the STARTUPINFO structure passed 
        /// to the <b>CreateProcess</b> function by the program that started the application.
        /// </summary>
        SHOWDEFAULT,

        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding. This flag 
        /// should only be used when minimizing windows from a different thread.
        /// </summary>
        FORCEMINIMIZE
    }
}
