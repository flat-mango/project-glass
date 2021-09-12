﻿namespace FlatMango.ProjectGlass.DllImports
{
    using System;
    using System.Runtime.InteropServices;


    internal static class Kernel32Dll
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// 
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, 
        /// the default library extension .dll is appended. The file name string can include a trailing point character
        /// (.) to indicate that the module name has no extension. The string does not have to specify a path. 
        /// When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared
        /// (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).
        /// The GetModuleHandle function does not retrieve handles for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is NULL. To get extended error information, call 
        /// <see cref="GetLastError" href="https://docs.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror">GetLastError</see>.
        /// </returns>
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
