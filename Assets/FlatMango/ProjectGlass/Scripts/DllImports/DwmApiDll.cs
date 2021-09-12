namespace FlatMango.ProjectGlass.DllImports
{
    using System;
    using System.Runtime.InteropServices;


    internal static class DwmApiDll
    {
        [DllImport("dwmapi.dll")]
        /// <summary>
        /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window. 
        /// For programming guidance, and code examples, see:
        /// <see href="https://docs.microsoft.com/en-us/windows/desktop/dwm/composition-ovw#controlling-non-client-region-rendering">
        /// Controlling non-client region rendering</see>.
        /// </summary>
        /// 
        /// <param name="hwnd">
        /// The handle to the window from which the attribute value is to be retrieved.
        /// </param>
        /// 
        /// <param name="dwAttribute">
        /// A flag describing which value to retrieve, specified as a value of the <see cref="DWMWA"/> enumeration. 
        /// This parameter specifies which attribute to retrieve, and the pvAttribute parameter points to an object 
        /// into which the attribute value is retrieved.
        /// </param>
        /// 
        /// <param name="pvAttribute">
        /// A pointer to a value which, when this function returns successfully, receives the current value of the attribute. 
        /// The type of the retrieved value depends on the value of the <b>dwAttribute</b> parameter. The <see cref="DWMWA"/> 
        /// enumeration topic indicates, in the row for each flag, what type of value you should pass a pointer to in 
        /// the <paramref name="pvAttribute"/> parameter.
        /// </param>
        /// 
        /// <param name="cbAttribute">
        /// The size, in bytes, of the attribute value being received via the <b>pvAttribute</b> parameter. The type of 
        /// the retrieved value, and therefore its size in bytes, depends on the value of the <b>dwAttribute</b> parameter.
        /// </param>
        internal static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out bool pvAttribute, int cbAttribute);

        [DllImport("dwmapi.dll")]
        /// <summary>
        /// Extends the window frame into the client area.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// The handle to the window in which the frame will be extended into the client area.
        /// </param>
        /// 
        /// <param name="pMarInset">
        /// A pointer to a <see cref="Margins"/> structure that describes the margins to use when extending 
        /// the frame into the client area.
        /// </param>
        /// 
        /// <remarks>
        /// This function must be called whenever Desktop Window Manager (DWM) composition is toggled. 
        /// Handle the <b>WM_DWMCOMPOSITIONCHANGED</b> message for composition change notification.
        /// 
        /// Use negative margin values to create the "sheet of glass" effect where the client area is 
        /// rendered as a solid surface with no window border.
        /// 
        /// Use the <b>DwmIsCompositionEnabled</b> function to determine whether Aero is enabled.
        /// </remarks>
        internal static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);
    }
}
