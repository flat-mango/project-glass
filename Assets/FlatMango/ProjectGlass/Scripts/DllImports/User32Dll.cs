namespace FlatMango.ProjectGlass.DllImports
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;


    internal static class User32Dll
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure 
        /// to monitor the system for certain types of events. These events are associated either with a specific 
        /// thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// 
        /// <param name="idHook">The type of hook procedure to be installed.</param>
        /// 
        /// <param name="lpfn">
        /// A pointer to the hook procedure. If the <paramref name="dwThreadId"/> parameter is zero 
        /// or specifies the identifier of a thread created by a different process, the <paramref name="lpfn"/> parameter 
        /// must point to a hook procedure in a DLL. Otherwise, <paramref name="lpfn"/> can point to a hook procedure in 
        /// the code associated with the current process.
        /// </param>
        /// 
        /// <param name="hMod">
        /// A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. 
        /// The <paramref name="hMod"/> parameter must be set to NULL if the <paramref name="dwThreadId"/> parameter 
        /// specifies a thread created by the current process and if the hook procedure is within the code associated 
        /// with the current process.
        /// </param>
        /// 
        /// <param name="dwThreadId">
        /// The identifier of the thread with which the hook procedure is to be associated. 
        /// For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads 
        /// running in the same desktop as the calling thread.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.
        /// If the function fails, the return value is NULL. To get extended error information, call 
        /// <see cref="GetLastError" href="https://docs.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</see>.
        /// </returns>
        /// 
        /// <remarks>
        /// Calling the <see cref="CallNextHookEx(IntPtr, int, IntPtr, IntPtr)"/> function to chain to the next hook procedure 
        /// is optional, but it is highly recommended; otherwise, other applications that have installed hooks will not 
        /// receive hook notifications and may behave incorrectly as a result. You should call CallNextHookEx unless you 
        /// absolutely need to prevent the notification from being seen by other applications.
        /// </remarks>
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// 
        /// <param name="hhk">
        /// A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to SetWindowsHookEx.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call
        /// <see cref="GetLastError" href="https://docs.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</see>.
        /// </returns>
        /// 
        /// <remarks>
        /// The hook procedure can be in the state of being called by another thread even after <see cref="UnhookWindowsHookEx(IntPtr)"/> 
        /// returns. If the hook procedure is not being called concurrently, the hook procedure is removed immediately before 
        /// <see cref="UnhookWindowsHookEx(IntPtr)"/> returns.
        /// </remarks>
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. 
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// 
        /// <param name="hhk">This parameter is ignored.</param>
        /// 
        /// <param name="nCode">
        /// The hook code passed to the current hook procedure. The next hook procedure uses this code 
        /// to determine how to process the hook information.
        /// </param>
        /// 
        /// <param name="wParam">
        /// The <paramref name="wParam"/> value passed to the current hook procedure. 
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// 
        /// <param name="lParam">
        /// The <paramref name="lParam"/> value passed to the current hook procedure. 
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.
        /// </param>
        /// 
        /// <returns>
        /// This value is returned by the next hook procedure in the chain. The current hook procedure must 
        /// also return this value. The meaning of the return value depends on the hook type. For more information, 
        /// see the descriptions of the individual hook procedures.
        /// </returns>
        /// 
        /// <remarks>
        /// Calling the <see cref="CallNextHookEx(IntPtr, int, IntPtr, IntPtr)"/> function to chain to the next hook procedure 
        /// is optional, but it is highly recommended; otherwise, other applications that have installed hooks will not 
        /// receive hook notifications and may behave incorrectly as a result. You should call CallNextHookEx unless you 
        /// absolutely need to prevent the notification from being seen by other applications.
        /// </remarks>
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// 
        /// <param name="point">
        /// A pointer to a <see cref="Point"/> structure that receives the screen coordinates of the cursor.
        /// </param>
        /// 
        /// <returns>
        /// Returns nonzero if successful or zero otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// The cursor position is always specified in screen coordinates and is not affected 
        /// by the mapping mode of the window that contains the cursor.
        /// </remarks>
        internal static extern long GetCursorPos(out Point point);

        [DllImport("user32.dll")]
        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen 
        /// rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates 
        /// so that the cursor stays within the rectangle.
        /// </summary>
        /// 
        /// <param name="x">The new x-coordinate of the cursor, in screen coordinates.</param>
        /// <param name="y">The new y-coordinate of the cursor, in screen coordinates.</param>
        /// 
        /// <returns>Returns nonzero if successful or zero otherwise.</returns>
        internal static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue.
        ///
        /// Note: <see cref="GetActiveWindow"/> will only return if the calling thread is in focus.
        /// </summary>
        ///
        /// <returns>
        /// The return value is the handle to the active window attached to the calling thread's message queue. 
        /// Otherwise, the return value is NULL.
        /// </returns>
        ///
        /// <remarks>
        /// Can be used to find the active window Hwnd for 
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowtexta">GetWindowText</see>
        /// 
        /// <br/><br/>
        /// 
        /// To get the handle to the foreground window, you can use 
        /// <see href="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getforegroundwindow">
        /// GetForegroundWindow</see>.
        /// 
        /// To get the window handle to the active window in the message queue for another thread, use 
        /// <see href="https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getguithreadinfo">
        /// GetGUIThreadInfo</see>.
        /// </remarks>
        internal static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves a handle to the Shell's desktop window.
        /// </summary>
        ///
        /// <returns>
        /// The return value is the handle of the Shell's desktop window. 
        /// If no Shell process is present, the return value is NULL.
        /// </returns>
        internal static extern IntPtr GetShellWindow();

        [DllImport("user32.dll")]
        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// 
        /// <param name="hWnd">A handle to the window to be tested.</param>
        /// 
        /// <returns>
        /// If the specified window, its parent window, its parent's parent window, and so forth, 
        /// have the <see cref="WS.VISIBLE"/> style, the return value is nonzero. Otherwise, 
        /// the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// Because the return value specifies whether the window has the <see cref="WS.VISIBLE"/> style, 
        /// it may be nonzero even if the window is totally obscured by other windows.
        /// 
        /// The visibility state of a window is indicated by the <see cref="WS.VISIBLE"/> style bit. When 
        /// <see cref="WS.VISIBLE"/> is set, the window is displayed and subsequent drawing into it is displayed 
        /// as long as the window has the <see cref="WS.VISIBLE"/> style.
        ///
        /// Any drawing to a window with the <see cref="WS.VISIBLE"/> style will not be displayed if the window is obscured 
        /// by other windows or is clipped by its parent window.
        /// </remarks>
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). 
        /// If the specified window is a control, the function retrieves the length of the text within the control. 
        /// However, <see cref="GetWindowTextLength"/> cannot retrieve the length of the text of an edit control 
        /// in another application.
        /// </summary>
        /// 
        /// <param name="hWnd">A handle to the window or control.</param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the text. 
        /// Under certain conditions, this value might be greater than the length of the text (see Remarks).
        /// 
        /// If the window has no text, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="GetWindowTextLength"/> causes a 
        /// <see cref="WM.GETTEXTLENGTH"/> message to be sent to the specified window or control.
        /// 
        /// Under certain conditions, the <see cref="GetWindowTextLength"/> function may return a value that is 
        /// larger than the actual length of the text. This occurs with certain mixtures of ANSI and Unicode, 
        /// and is due to the system allowing for the possible existence of double-byte character set (DBCS) 
        /// characters within the text. The return value, however, will always be at least as large as the actual 
        /// length of the text; you can thus always use it to guide buffer allocation. This behavior can occur 
        /// when an application uses both ANSI functions and common dialogs, which use Unicode. It can also occur 
        /// when an application uses the ANSI version of GetWindowTextLength with a window whose window procedure 
        /// is Unicode, or the Unicode version of GetWindowTextLength with a window whose window procedure is ANSI.
        /// </remarks>
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window 
        /// is a control, the text of the control is copied. However, <see cref="GetWindowText"/> cannot retrieve the text 
        /// of a control in another application.
        /// </summary>
        /// 
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// 
        /// <param name="lpString">
        /// The buffer that will receive the text. If the string is as long or longer than the buffer, the string is 
        /// truncated and terminated with a null character.
        /// </param>
        /// 
        /// <param name="nMaxCount">
        /// The maximum number of characters to copy to the buffer, including the null character. 
        /// If the text exceeds this limit, it is truncated.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the copied string, 
        /// not including the terminating null character. If the window has no title bar or text, if the title 
        /// bar is empty, or if the window or control handle is invalid, the return value is zero.
        /// 
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        /// 
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="GetWindowText"/> causes a <see cref="WM.GETTEXT"/> 
        /// message to be sent to the specified window or control. If the target window is owned by another process and has 
        /// a caption, <see cref="GetWindowText"/> retrieves the window caption text. If the window does not have a caption, 
        /// the return value is a null string. This behavior is by design. It allows applications to call 
        /// <see cref="GetWindowText"/> without becoming unresponsive if the process that owns the target window is not 
        /// responding. However, if the target window is not responding and it belongs to the calling application, 
        /// <see cref="GetWindowText"/> will cause the calling application to become unresponsive.
        /// 
        /// To retrieve the text of a control in another process, send a <see cref="WM.GETTEXT"/> message directly 
        /// instead of calling <see cref="GetWindowText"/>.
        /// </remarks>
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        /// <summary>
        /// Enumerates all top-level windows associated with the specified desktop. 
        /// It passes the handle to each window, in turn, to an application-defined callback function.
        /// </summary>
        /// 
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated.
        /// If this parameter is NULL, the current desktop is used.
        /// </param>
        /// 
        /// <param name="lpfn">
        /// A pointer to an application-defined <b>EnumWindowsProc</b> callback function.
        /// </param>
        /// 
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// 
        /// <returns>
        /// If the function fails or is unable to perform the enumeration, the return value is zero.
        /// You must ensure that the callback function sets SetLastError if it fails.
        /// </returns>
        /// 
        /// <remarks>
        /// The <see cref="EnumDesktopWindows"/> function repeatedly invokes the <paramref name="lpfn"/> 
        /// callback function until the last top-level window is enumerated or the callback function returns FALSE.
        /// </remarks>
        internal static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc lpfn, IntPtr lParam);

        [DllImport("user32.dll")]
        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) 
        /// value at the specified offset into the extra window memory.
        /// 
        /// Note: This function has been superseded by the SetWindowLongPtr function. To write code that is 
        /// compatible with both 32-bit and 64-bit versions of Windows, use the SetWindowLongPtr function.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// 
        /// <param name="nIndex">
        /// The zero-based offset to the value to be set. Valid values are in the range zero through the number 
        /// of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the 
        /// <see cref="GWL"/> values.
        /// </param>
        /// 
        /// <param name="dwNewLong">
        /// The replacement value.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero.
        /// 
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds, 
        /// the return value is zero, but the function does not clear the last error information. 
        /// This makes it difficult to determine success or failure. To deal with this, you should clear 
        /// the last error information by calling SetLastError with 0 before calling <see cref="SetWindowLong"/>. 
        /// Then, function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
        /// </returns>
        /// 
        /// <remarks>
        /// Certain window data is cached, so changes you make using SetWindowLong will not take effect until 
        /// you call the <see cref="SetWindowPos"/> function. Specifically, if you change any of the frame styles, you must 
        /// call <see cref="SetWindowPos"/> with the <see cref="SWP.FRAMECHANGED"/> flag for the cache to be updated properly.
        /// 
        /// If you use SetWindowLong with the <see cref="GWL.WNDPROC"/> index to replace the window procedure, the window 
        /// procedure must conform to the guidelines specified in the description of the WindowProc callback function.
        /// 
        /// You can show and hide the window from the task bar, see Tips & Tricks on:
        /// <see href="https://pinvoke.net/default.aspx/user32/SetWindowLong.html"/>
        /// 
        /// More remarks: <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowlonga#remarks"/>
        /// </remarks>
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) 
        /// value at the specified offset into the extra window memory.
        /// 
        /// Note: If you are retrieving a pointer or a handle, this function has been superseded by the GetWindowLongPtr 
        /// function. (Pointers and handles are 32 bits on 32-bit Windows and 64 bits on 64-bit Windows.) To write code 
        /// that is compatible with both 32-bit and 64-bit versions of Windows, use GetWindowLongPtr.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// 
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number 
        /// of bytes of extra window memory, minus four; for example, if you specified 12 or more bytes of extra memory, 
        /// a value of 8 would be an index to the third 32-bit integer. To retrieve any other value, specify one of the 
        /// <see cref="GWL"/> values.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero. <br/>
        /// If <see cref="SetWindowLong"/> has not been called previously, <see cref="GetWindowLong"/> returns zero 
        /// for values in the extra window or class memory.
        /// </returns>
        internal static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are 
        /// ordered according to their appearance on the screen. The topmost window receives the highest rank 
        /// and is the first window in the Z order.
        /// 
        /// <see cref="SpecialHWND.TOP"/> will bring a window to the front of the Z-Order only if the thread 
        /// is in the foreground. Otherwise it will bring the window to the front of the thread's Z-order.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="hWndInsertAfter">
        /// A handle to the window to precede the positioned window in the Z order. This parameter must be a 
        /// window handle or one of the <see cref="SpecialHWND"/> values.
        /// </param>
        /// 
        /// <param name="x">
        /// The new position of the left side of the window, in client coordinates.
        /// </param>
        /// 
        /// <param name="y">
        /// The new position of the top of the window, in client coordinates.
        /// </param>
        /// 
        /// <param name="cx">
        /// The new width of the window, in pixels.
        /// </param>
        /// 
        /// <param name="cy">
        /// The new height of the window, in pixels.
        /// </param>
        /// 
        /// <param name="uFlags">
        /// The window sizing and positioning flags. This parameter can be a combination of <see cref="SWP"/> values.
        /// </param>
        /// 
        /// <remarks>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos#remarks">
        /// SetWindowPos.Remarks</see>
        /// </remarks>
        internal static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        [DllImport("user32.dll")]
        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. 
        /// Keyboard input is directed to the window, and various visual cues are changed for the user. 
        /// The system assigns a slightly higher priority to the thread that created the foreground window 
        /// than it does to other threads.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// 
        /// <returns>
        /// If the window was brought to the foreground, the return value is nonzero.
        /// If the window was not brought to the foreground, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// The system restricts which processes can set the foreground window. A process can set the foreground 
        /// window only if one of the following conditions is true:
        /// 
        /// * The process is the foreground process.
        /// * The process was started by the foreground process.
        /// * The process received the last input event.
        /// * There is no foreground process.
        /// * The process is being debugged.
        /// * The foreground process is not a Modern Application or the Start Screen.
        /// * The foreground is not locked (see LockSetForegroundWindow).
        /// * The foreground lock time-out has expired (see SPI_GETFOREGROUNDLOCKTIMEOUT in SystemParametersInfo).
        /// * No menus are active.
        /// 
        /// An application cannot force a window to the foreground while the user is working with another window. 
        /// Instead, Windows flashes the taskbar button of the window to notify the user.
        /// 
        /// A process that can set the foreground window can enable another process to set the foreground window 
        /// by calling the AllowSetForegroundWindow function. The process specified by <b>dwProcessId</b> loses 
        /// the ability to set the foreground window the next time the user generates input, unless the input 
        /// is directed at that process, or the next time a process calls AllowSetForegroundWindow, unless 
        /// that process is specified.
        /// 
        /// The foreground process can disable calls to SetForegroundWindow by calling the LockSetForegroundWindow function.
        /// 
        /// Not always works on Windows-7 (vista and above). See Tips & Tricks on:
        /// <see href="https://pinvoke.net/default.aspx/user32/SetForegroundWindow.html"/>
        /// </remarks>
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). 
        /// The system assigns a slightly higher priority to the thread that creates the foreground window 
        /// than it does to other threads.
        /// </summary>
        /// 
        /// <returns>
        /// The return value is a handle to the foreground window. The foreground window can be NULL in 
        /// certain circumstances, such as when a window is losing activation.
        /// </returns>
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are 
        /// given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="lpRect">
        /// A pointer to a <see cref="NativeRect"/> structure that receives the screen coordinates of 
        /// the upper-left and lower-right corners of the window.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// In conformance with conventions for the <see cref="NativeRect"/> structure, the bottom-right 
        /// coordinates of the returned rectangle are exclusive. In other words, the pixel at (right, bottom) 
        /// lies  immediately outside the rectangle.
        /// 
        /// GetWindowRect is virtualized for DPI.
        /// 
        /// In Windows Vista and later, the Window Rect now includes the area occupied by the drop shadow.
        /// Calling GetWindowRect will have different behavior depending on whether the window has ever been shown or not. 
        /// If the window has not been shown before, GetWindowRect will not include the area of the drop shadow.
        /// 
        /// To get the window bounds excluding the drop shadow, use <see cref="DwmApiDll.DwmGetWindowAttribute"/>, 
        /// specifying DWMWA_EXTENDED_FRAME_BOUNDS. Note that unlike the Window Rect, the DWM Extended Frame Bounds 
        /// are not adjusted for DPI. Getting the extended frame bounds can only be done after the window has 
        /// been shown at least once.
        /// </remarks>
        internal static extern bool GetWindowRect(IntPtr hWnd, ref NativeRect lpRect);

        [DllImport("user32.dll")]
        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="nCmdShow">
        /// Controls how the window is to be shown. This parameter is ignored the first time an application calls 
        /// <see cref="ShowWindow"/>, if the program that launched the application provides a STARTUPINFO structure. 
        /// Otherwise, the first time <see cref="ShowWindow"/> is called, the value should be the value obtained 
        /// by the <b>WinMain</b> function in its <b>nCmdShow</b> parameter. In subsequent calls, this parameter 
        /// can be one of the <see cref="SW"/> values.
        /// </param>
        /// 
        /// <returns>
        /// If the window was previously visible, the return value is nonzero.
        /// If the window was previously hidden, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// To perform certain special effects when showing or hiding a window, use <b>AnimateWindow</b>.
        /// 
        /// The first time an application calls <see cref="ShowWindow"/>, it should use the WinMain function's 
        /// <b>nCmdShow</b> parameter as its nCmdShow parameter. Subsequent calls to <see cref="ShowWindow"/> must 
        /// use one of the values in the given list, instead of the one specified by the <b>WinMain</b> function's 
        /// <b>nCmdShow</b> parameter.
        /// </remarks>
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        /// <summary>
        /// Changes the position and dimensions of the specified window. For a top-level window, the position 
        /// and dimensions are relative to the upper-left corner of the screen. For a child window, they are 
        /// relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="x">
        /// The new position of the left side of the window.
        /// </param>
        /// 
        /// <param name="y">
        /// The new position of the top of the window.
        /// </param>
        /// 
        /// <param name="nWidth">
        /// The new width of the window.
        /// </param>
        /// 
        /// <param name="nHeight">
        /// The new height of the window.
        /// </param>
        /// 
        /// <param name="bRepaint">
        /// Indicates whether the window is to be repainted. If this parameter is TRUE, the window 
        /// receives a message. If the parameter is FALSE, no repainting of any kind occurs. 
        /// This applies to the client area, the nonclient area (including the title bar and scroll bars), 
        /// and any part of the parent window uncovered as a result of moving a child window.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// If the <b>bRepaint</b> parameter is TRUE, the system sends the <b>WM_PAINT</b> message to the window procedure 
        /// immediately after moving the window (that is, the MoveWindow function calls the <b>UpdateWindow</b> function). 
        /// If <b>bRepaint</b> is FALSE, the application must explicitly invalidate or redraw any parts of the window 
        /// and parent window that need redrawing.
        /// 
        /// MoveWindow sends the WM_WINDOWPOSCHANGING, WM_WINDOWPOSCHANGED, WM_MOVE, WM_SIZE, and WM_NCCALCSIZE 
        /// messages to the window.
        /// </remarks>
        internal static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, 
        /// the text of the control is changed. However, <see cref="SetWindowText"/> cannot change the text of a control 
        /// in another application.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window or control whose text is to be changed.
        /// </param>
        /// 
        /// <param name="lpString">
        /// The new title or control text.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// If the target window is owned by the current process, <see cref="SetWindowText"/> causes a <see cref="WM.SETTEXT"/> 
        /// message to be sent to the specified window or control. If the control is a list box control created with the 
        /// <see cref="WS.CAPTION"/> style, however, SetWindowText sets the text for the control, not for the list box entries.
        /// 
        /// To set the text of a control in another process, send the <see cref="WM.SETTEXT"/> message directly instead 
        /// of calling <see cref="SetWindowText"/>.
        /// 
        /// The <see cref="SetWindowText"/> function does not expand tab characters (ASCII code 0x09).
        /// Tab characters are displayed as vertical bar (|) characters.
        /// </remarks>
        internal static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created the specified 
        /// window and returns without waiting for the thread to process the message.
        /// 
        /// To post a message in the message queue associated with a thread, use the <b>PostThreadMessage</b> function.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message. The following values have special meanings.
        /// 
        /// HWND_BROADCAST ((HWND)0xffff) - The message is posted to all top-level windows in the system, including disabled 
        /// or invisible unowned windows, overlapped windows, and pop-up windows. The message is not posted to child windows. 
        /// 
        /// NULL - The function behaves like a call to <b>PostThreadMessage</b> with the dwThreadId parameter set 
        /// to the identifier of the current thread.
        /// 
        /// Starting with Windows Vista, message posting is subject to UIPI. The thread of a process can post messages 
        /// only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        ///
        /// <param name="Msg">
        /// The message to be posted.
        /// For lists of the system-provided messages, see 
        /// <see href="https://docs.microsoft.com/en-us/windows/desktop/winmsg/about-messages-and-message-queues">
        /// System-Defined Messages</see>.
        /// </param>
        /// 
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// 
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// 
        /// <remarks>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagea#remarks"/>
        /// </remarks>
        internal static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);


        [DllImport("user32.dll")]
        /// <summary>
        /// Sends the specified message to a window or windows. The <b>SendMessage</b> function calls the window procedure 
        /// for the specified window and does not return until the window procedure has processed the message.
        /// 
        /// To send a message and return immediately, use the <b>SendMessageCallback</b> or <b>SendNotifyMessage</b> function. 
        /// To post a message to a thread's message queue and return immediately, use the <b>PostMessage</b> or 
        /// <b>PostThreadMessage</b> function.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), 
        /// the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, 
        /// overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// 
        /// Message sending is subject to UIPI. The thread of a process can send messages only to message 
        /// queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// 
        /// <param name="Msg">
        /// The message to be posted.
        /// For lists of the system-provided messages, see 
        /// <see href="https://docs.microsoft.com/en-us/windows/desktop/winmsg/about-messages-and-message-queues">
        /// System-Defined Messages</see>.
        /// </param>
        /// 
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// 
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// 
        /// <returns>
        /// The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        /// 
        /// <remarks>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendmessage#remarks"/>
        /// </remarks>
        internal static extern Int32 SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true)]
        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier 
        /// of the process that created the window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="processId">
        /// A pointer to a variable that receives the process identifier. If this parameter is not NULL, 
        /// <see cref="GetWindowThreadProcessId"/> copies the identifier of the process to the variable; 
        /// otherwise, it does not.
        /// </param>
        /// 
        /// <returns>
        /// The return value is the identifier of the thread that created the window.
        /// </returns>
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    }
}
