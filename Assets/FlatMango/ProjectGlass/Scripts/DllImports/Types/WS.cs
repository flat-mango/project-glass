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
    /// The following are the window styles. After the window has been created, these styles 
    /// cannot be modified, except as noted.
    /// </summary>
    [System.Flags]
    internal enum WS : uint
    {
        /// <summary>
        /// The window is an overlapped window. An overlapped window has a title bar and a border. 
        /// Same as the <see cref="TILED"/> style.
        /// </summary>
        OVERLAPPED = 0x00000000,

        /// <summary>
        /// The window is an overlapped window. An overlapped window has a title bar and a border. 
        /// Same as the <see cref="OVERLAPPED"/> style.
        /// </summary>
        TILED = 0x00000000,

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key. 
        /// Pressing the TAB key changes the keyboard focus to the next control with the <see cref="TABSTOP"/> style.
        /// 
        /// <br/><br/>
        /// 
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window 
        /// has been created, use the <see cref="User32Dll.SetWindowLong"/> function. For user-created windows and 
        /// modeless dialogs to work with tab stops, alter the message loop to call the <b>IsDialogMessage</b> function.
        /// </summary>
        TABSTOP = 0x00010000,

        /// <summary>
        /// The window has a maximize button. Cannot be combined with the <see cref="WS_EX.CONTEXTHELP"/> style. 
        /// The <see cref="SYSMENU"/> style must also be specified. 
        /// </summary>
        MAXIMIZEBOX = 0x00010000,

        /// <summary>
        /// The window has a vertical scroll bar.
        /// </summary>
        VSCROLL = 0x00200000,

        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all 
        /// controls defined after it, up to the next control with the <see cref="GROUP"/> style. The first control 
        /// in each group usually has the <see cref="TABSTOP"/> style so that the user can move from group to group. 
        /// The user can subsequently change the keyboard focus from one control in the group to the next control in 
        /// the group by using the direction keys.
        /// 
        /// <br/><br/>
        /// 
        /// You can turn this style on and off to change dialog box navigation. To change this style after a window 
        /// has been created, use the <see cref="User32Dll.SetWindowLong"/> function.
        /// </summary>
        GROUP = 0x00020000,

        /// <summary>
        /// The window has a minimize button. Cannot be combined with the <see cref="WS_EX.CONTEXTHELP"/> style. 
        /// The <see cref="SYSMENU"/> style must also be specified.
        /// </summary>
        MINIMIZEBOX = 0x00020000,

        /// <summary>
        /// The window has a sizing border. Same as the <see cref="THICKFRAME"/> style.
        /// </summary>
        SIZEBOX = 0x00040000,

        /// <summary>
        /// The window has a sizing border. Same as the <see cref="SIZEBOX"/> style.
        /// </summary>
        THICKFRAME = 0x00040000,

        /// <summary>
        /// The window has a window menu on its title bar. The <see cref="CAPTION"/> style must also be specified.
        /// </summary>
        SYSMENU = 0x00080000,

        /// <summary>
        /// The window has a horizontal scroll bar.
        /// </summary>
        HSCROLL = 0x00100000,

        /// <summary>
        /// The window has a border of a style typically used with dialog boxes. A window with this style 
        /// cannot have a title bar.
        /// </summary>
        DLGFRAME = 0x00400000,

        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        BORDER = 0x00800000,

        /// <summary>
        /// The window has a title bar (includes the <see cref="BORDER"/> style).
        /// </summary>
        CAPTION = BORDER | DLGFRAME,

        /// <summary>
        /// The window is initially maximized.
        /// </summary>
        MAXIMIZE = 0x01000000,

        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window. 
        /// This style is used when creating the parent window.
        /// </summary>
        CLIPCHILDREN = 0x02000000,

        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a <b>WM_PAINT</b> 
        /// message, the <see cref="CLIPSIBLINGS"/> style clips all other overlapping child windows out of the region of 
        /// the child window to be updated. If <see cref="CLIPSIBLINGS"/> is not specified and child windows overlap, 
        /// it is possible, when drawing within the client area of a child window, to draw within the client area of 
        /// a neighboring child window.
        /// </summary>
        CLIPSIBLINGS = 0x04000000,


        /// <summary>
        /// The window is initially disabled. A disabled window cannot receive input from the user. 
        /// To change this after a window has been created, use the <b>EnableWindow</b> function.
        /// </summary>
        DISABLED = 0x08000000,

        /// <summary>
        /// The window is initially visible.<br/>
        /// This style can be turned on and off by using the <see cref="User32Dll.ShowWindow"/> or 
        /// <see cref="User32Dll.SetWindowPos"/> function.
        /// </summary>
        VISIBLE = 0x10000000,

        /// <summary>
        /// The window is initially minimized. Same as the <see cref="MINIMIZE"/> style.
        /// </summary>
        ICONIC = 0x20000000,

        /// <summary>
        /// The window is initially minimized. Same as the <see cref="ICONIC"/> style.
        /// </summary>
        MINIMIZE = 0x20000000,

        /// <summary>
        /// The window is a child window. A window with this style cannot have a menu bar. This style 
        /// cannot be used with the <see cref="POPUP"/> style.
        /// </summary>
        CHILD = 0x40000000,

        /// <summary>
        /// Same as the <see cref="CHILD"/> style.
        /// </summary>
        CHILDWINDOW = 0x40000000,

        /// <summary>
        /// The window is a pop-up window. This style cannot be used with the <see cref="CHILD"/> style.
        /// </summary>
        POPUP = 0x80000000,

        /// <summary>
        /// The window is an overlapped window. Same as the <see cref="TILEDWINDOW"/> style. 
        /// </summary>
        OVERLAPPEDWINDOW = OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX,

        /// <summary>
        /// The window is an overlapped window. Same as the <see cref="OVERLAPPEDWINDOW"/> style. 
        /// </summary>
        TILEDWINDOW = OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX,

        /// <summary>
        /// The window is a pop-up window. The <see cref="CAPTION"/> and <see cref="POPUPWINDOW"/> styles 
        /// must be combined to make the window menu visible.
        /// </summary>
        POPUPWINDOW = POPUP | BORDER | SYSMENU,
    }
}
