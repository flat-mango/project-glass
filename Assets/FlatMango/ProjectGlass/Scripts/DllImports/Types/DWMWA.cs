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
    /// Flags used by the <see cref="DwmApiDll.DwmGetWindowAttribute"/> and <b>DwmSetWindowAttribute</b> functions 
    /// to specify window attributes for Desktop Window Manager (DWM) non-client rendering.
    /// </summary>
    internal enum DWMWA
    {
        /// <summary>
        /// Use with <see cref="DwmApiDll.DwmGetWindowAttribute"/>. Discovers whether non-client rendering is 
        /// enabled. The retrieved value is of type BOOL. TRUE if non-client rendering is enabled; otherwise, FALSE.
        /// </summary>
        NCRENDERING_ENABLED,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Sets the non-client rendering policy. The pvAttribute parameter 
        /// points to a value from the DWMNCRENDERINGPOLICY enumeration.
        /// </summary>
        NCRENDERING_POLICY,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Enables or forcibly disables DWM transitions. The pvAttribute parameter 
        /// points to a value of type BOOL. TRUE to disable transitions, or FALSE to enable transitions.
        /// </summary>
        TRANSITIONS_FORCEDISABLED,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Enables content rendered in the non-client area to be visible on the frame 
        /// drawn by DWM. The <b>pvAttribute</b> parameter points to a value of type BOOL. TRUE to enable content 
        /// rendered in the non-client area to be visible on the frame; otherwise, FALSE.
        /// </summary>
        ALLOW_NCPAINT,

        /// <summary>
        /// Use with <see cref="DwmApiDll.DwmGetWindowAttribute"/>. Retrieves the bounds of the caption button area 
        /// in the window-relative space. The retrieved value is of type <see cref="NativeRect"/>. If the window is 
        /// minimized or otherwise not visible to the user, then the value of the <see cref="NativeRect"/> retrieved 
        /// is undefined. You should check whether the retrieved <see cref="NativeRect"/> contains a boundary that you 
        /// can work with, and if it doesn't then you can conclude that the window is minimized or otherwise not visible.
        /// </summary>
        CAPTION_BUTTON_BOUNDS,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Specifies whether non-client content is right-to-left (RTL) mirrored. The 
        /// <b>pvAttribute</b> parameter points to a value of type BOOL. TRUE if the non-client content is 
        /// right-to-left (RTL) mirrored; otherwise, FALSE.
        /// </summary>
        NONCLIENT_RTL_LAYOUT,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Forces the window to display an iconic thumbnail or peek representation 
        /// (a static bitmap), even if a live or snapshot representation of the window is available. This value is normally 
        /// set during a window's creation, and not changed throughout the window's lifetime. Some scenarios, however, 
        /// might require the value to change over time. The <b>pvAttribute</b> parameter points to a value of type BOOL. 
        /// TRUE to require a iconic thumbnail or peek representation; otherwise, FALSE.
        /// </summary>
        FORCE_ICONIC_REPRESENTATION,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Sets how Flip3D treats the window. The <b>pvAttribute</b> parameter points 
        /// to a value from the DWMFLIP3DWINDOWPOLICY enumeration.
        /// </summary>
        FLIP3D_POLICY,

        /// <summary>
        /// Use with <see cref="DwmApiDll.DwmGetWindowAttribute"/>. Retrieves the extended frame bounds rectangle 
        /// in screen space. The retrieved value is of type <see cref="NativeRect"/>.
        /// </summary>
        EXTENDED_FRAME_BOUNDS,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. The window will provide a bitmap for use by DWM as an iconic thumbnail 
        /// or peek representation (a static bitmap) for the window. <b>DWMWA_HAS_ICONIC_BITMAP</b> can be specified with 
        /// <b>DWMWA_FORCE_ICONIC_REPRESENTATION</b>. <b>DWMWA_HAS_ICONIC_BITMAP</b> normally is set during a window's 
        /// creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value 
        /// to change over time. The <b>pvAttribute</b> parameter points to a value of type BOOL. TRUE to inform DWM that 
        /// the window will provide an iconic thumbnail or peek representation; otherwise, FALSE.
        /// </summary>
        HAS_ICONIC_BITMAP,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Do not show peek preview for the window. The peek view shows a full-sized 
        /// preview of the window when the mouse hovers over the window's thumbnail in the taskbar. If this attribute is set, 
        /// hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group has 
        /// a peek preview showing). The <b>pvAttribute</b> parameter points to a value of type BOOL. TRUE to prevent peek 
        /// functionality, or FALSE to allow it.
        /// </summary>
        DISALLOW_PEEK,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Prevents a window from fading to a glass sheet when peek is invoked. 
        /// The <b>pvAttribute</b> parameter points to a value of type BOOL. TRUE to prevent the window from fading 
        /// during another window's peek, or FALSE for normal behavior.
        /// </summary>
        EXCLUDED_FROM_PEEK,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Cloaks the window such that it is not visible to the user. 
        /// The window is still composed by DWM.
        /// </summary>
        CLOAK,

        /// <summary>
        /// Use with <see cref="DwmApiDll.DwmGetWindowAttribute"/>. If the window is cloaked, provides one of the 
        /// following values explaining why.
        /// 
        /// <br/><br/>
        /// 
        /// * <b>DWM_CLOAKED_APP</b> (value 0x0000001). The window was cloaked by its owner application.<br/>
        /// * <b>DWM_CLOAKED_SHELL</b> (value 0x0000002). The window was cloaked by the Shell.<br/>
        /// * <b>DWM_CLOAKED_INHERITED</b> (value 0x0000004). The cloak value was inherited from its owner window.<br/>
        /// </summary>
        CLOAKED,

        /// <summary>
        /// Use with <b>DwmSetWindowAttribute</b>. Freeze the window's thumbnail image with its current visuals. Do no 
        /// further live updates on the thumbnail image to match the window's contents.
        /// </summary>
        FREEZE_REPRESENTATION,

        /// <summary>
        /// The maximum recognized <see cref="DWMWA"/> value, used for validation purposes.
        /// </summary>
        LAST
    }
}
