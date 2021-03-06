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
    /// The following are the extended window styles.
    /// </summary>
    [System.Flags]
    public enum WS_EX : uint
    {
        /// <summary>
        /// The window text is displayed using left-to-right reading-order properties. This is the default.
        /// </summary>
        LTRREADING = 0x00000000,

        /// <summary>
        /// Specifies a window that has generic left-aligned properties. This is the default.
        /// </summary>
        LEFT = 0x00000000,

        /// <summary>
        /// The vertical scroll bar (if present) is to the right of the client area. This is the default.
        /// </summary>
        RIGHTSCROLLBAR = 0x00000000,

        /// <summary>
        /// The window has a double border; the window can, optionally, be created with a title bar by specifying 
        /// the <see cref="WS.CAPTION"/> style in the <b>dwStyle</b> parameter.
        /// </summary>
        DLGMODALFRAME = 0x00000001,

        /// <summary>
        /// The child window created with this style does not send the <b>WM_PARENTNOTIFY</b> message to its parent window when 
        /// it is created or destroyed.
        /// </summary>
        NOPARENTNOTIFY = 0x00000004,

        /// <summary>
        /// The window should be placed above all non-topmost windows and should stay above them, even when the window 
        /// is deactivated. To add or remove this style, use the <see cref="User32Dll.SetWindowPos"/> function.
        /// </summary>
        TOPMOST = 0x00000008,

        /// <summary>
        /// Specifies a window that accepts drag-drop files.
        /// </summary>
        ACCEPTFILES = 0x00000010,

        /// <summary>
        /// The window should not be painted until siblings beneath the window (that were created by the same thread) 
        /// have been painted. The window appears transparent because the bits of underlying sibling windows have 
        /// already been painted.<be/>
        /// To achieve transparency without these restrictions, use the <b>SetWindowRgn</b> function.
        /// </summary>
        TRANSPARENT = 0x00000020,

        /// <summary>
        /// The window is a MDI child window.
        /// </summary>
        MDICHILD = 0x00000040,

        /// <summary>
        /// The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter 
        /// than a normal title bar, and the window title is drawn using a smaller font. A tool window does not 
        /// appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window 
        /// has a system menu, its icon is not displayed on the title bar. However, you can display the system menu 
        /// by right-clicking or by typing ALT+SPACE. 
        /// </summary>
        TOOLWINDOW = 0x00000080,

        /// <summary>
        /// The window has a border with a raised edge.
        /// </summary>
        WINDOWEDGE = 0x00000100,

        /// <summary>
        /// Specifies a window that has a border with a sunken edge.
        /// </summary>
        CLIENTEDGE = 0x00000200,

        /// <summary>
        /// Specifies a window that includes a question mark in the title bar. When the user clicks the question mark,
        /// the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child 
        /// receives a <b>WM_HELP</b> message. The child window should pass the message to the parent window procedure, 
        /// which should call the <b>WinHelp</b> function using the <b>HELP_WM_HELP</b> command. The Help application 
        /// displays a pop-up window that typically contains help for the child window.
        /// <see cref="CONTEXTHELP"/> cannot be used with the <see cref="MAXIMIZEBOX"/> or <see cref="WS.MINIMIZEBOX"/> styles.
        /// </summary>
        CONTEXTHELP = 0x00000400,

        /// <summary>
        /// The window has generic "right-aligned" properties. This depends on the window class. This style has 
        /// an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order 
        /// alignment; otherwise, the style is ignored.<br/>
        /// Using the <see cref="RIGHT"/> style for static or edit controls has the same effect as using the 
        /// <b>SS_RIGHT</b> or <b>ES_RIGHT</b> style, respectively. Using this style with button controls has 
        /// the same effect as using <b>BS_RIGHT</b> and <b>BS_RIGHTBUTTON</b> styles.
        /// </summary>
        RIGHT = 0x00001000,

        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, 
        /// the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
        /// </summary>
        RTLREADING = 0x00002000,

        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, 
        /// the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
        /// </summary>
        LEFTSCROLLBAR = 0x00004000,

        /// <summary>
        /// Specifies a window which contains child windows that should take part in dialog box navigation. If this 
        /// style is specified, the dialog manager recurses into children of this window when performing navigation 
        /// operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        CONTROLPARENT = 0x00010000,

        /// <summary>
        /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        STATICEDGE = 0x00020000,

        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible.
        /// </summary>
        APPWINDOW = 0x00040000,

        /// <summary>
        /// Specifies a window that is a layered window. This cannot be used for child windows or if the window 
        /// has a class style of either <b>CS_OWNDC</b> or <b>CS_CLASSDC</b>.
        /// </summary>
        /// <remarks>
        /// Note: Beginning with Windows 8, <see cref="WS_EX.LAYERED"/> can be used with child windows and top-level windows. 
        /// Previous Windows versions support <see cref="WS_EX.LAYERED"/> only for top-level windows.
        /// </remarks>
        LAYERED = 0x00080000,

        /// <summary>
        /// The window does not pass its window layout to its child windows.
        /// </summary>
        NOINHERITLAYOUT = 0x00100000,

        /// <summary>
        /// The window does not render to a redirection surface. This is for windows that do not have visible content 
        /// or that use mechanisms other than surfaces to provide their visual.
        /// </summary>
        NOREDIRECTIONBITMAP = 0x00200000,

        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, 
        /// the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left. 
        /// </summary>
        LAYOUTRTL = 0x00400000,

        /// <summary>
        /// Paints all descendants of a window in bottom-to-top painting order using double-buffering. 
        /// Bottom-to-top painting order allows a descendent window to have translucency (alpha) and 
        /// transparency (color-key) effects, but only if the descendent window also has the 
        /// <see cref="TRANSPARENT"/> bit set. Double-buffering allows the window and its descendents 
        /// to be painted without flicker. This cannot be used if the window has a class style of 
        /// either <b>CS_OWNDC</b> or <b>CS_CLASSDC</b>. 
        /// </summary>
        COMPOSITED = 0x02000000,

        /// <summary>
        /// A top-level window created with this style does not become the foreground window when the user clicks it. 
        /// The system does not bring this window to the foreground when the user minimizes or closes the foreground window.<br/>
        /// The window should not be activated through programmatic access or via keyboard navigation by accessible technology, 
        /// such as Narrator.<br/>
        /// To activate the window, use the <b>SetActiveWindow</b> or <b>SetForegroundWindow</b> function.<br/>
        /// The window does not appear on the taskbar by default. To force the window to appear on the taskbar, 
        /// use the <see cref="APPWINDOW"/> style.
        /// </summary>
        NOACTIVATE = 0x08000000,

        /// <summary>
        /// The window is an overlapped window.
        /// </summary>
        OVERLAPPEDWINDOW = WINDOWEDGE | CLIENTEDGE,

        /// <summary>
        /// The window is palette window, which is a modeless dialog box that presents an array of commands.
        /// </summary>
        PALETTEWINDOW = WINDOWEDGE | TOOLWINDOW | TOPMOST,
    }
}
