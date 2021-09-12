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
    /// Window messages.
    /// </summary>
    internal enum WM
    {
        /// <summary>
        /// Sets the text of a window.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-settext"/>
        /// </summary>
        SETTEXT = 0x000C,

        /// <summary>
        /// Copies the text that corresponds to a window into a buffer provided by the caller.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettext"/>
        /// </summary>
        GETTEXT = 0x000D,

        /// <summary>
        /// Determines the length, in characters, of the text associated with a window.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettextlength"/>
        /// </summary>
        GETTEXTLENGTH = 0x000E,

        /// <summary>
        /// Sent when the window background must be erased (for example, when a window is resized). 
        /// The message is sent to prepare an invalidated portion of a window for painting.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-erasebkgnd"/>
        /// </summary>
        ERASEBKGND = 0x0014,

        /// <summary>
        /// Sets the font that a control is to use when drawing text.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-setfont"/>
        /// </summary>
        SETFONT = 0x0030,

        /// <summary>
        /// Retrieves the font with which the control is currently drawing its text.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-getfont"/>
        /// </summary>
        GETFONT = 0x0031,

        /// <summary>
        /// Associates a new large or small icon with a window. The system displays the large 
        /// icon in the ALT+TAB dialog box, and the small icon in the window caption.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-seticon"/>
        /// </summary>
        SETICON = 0x0080,

        /// <summary>
        /// Retrieves the menu handle for the current window.<br/>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/winmsg/mn-gethmenu"/>
        /// </summary>
        GETHMENU = 0x01E1,
    }
}
