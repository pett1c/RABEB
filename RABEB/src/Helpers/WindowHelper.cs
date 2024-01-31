using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RABEB
{
    internal static class WindowHelper
    {
        private const int _mfByCommand = 0x00000000;
        private const int _scMaximize = 0xF030;
        private const int _scRestore = 0xF120;
        private const int _scSize = 0xF000;
        private const int _swMaximize = 3;

        public static void DisableResizing()
        {
            IntPtr sysMenu = GetSystemMenu(Process.GetCurrentProcess().MainWindowHandle, false);
            
            DeleteMenu(sysMenu, _scMaximize, _mfByCommand);
            DeleteMenu(sysMenu, _scRestore, _mfByCommand);
            DeleteMenu(sysMenu, _scSize, _mfByCommand);
        }

        public static void MaximizeWindow()
        {
            ShowWindow(Process.GetCurrentProcess().MainWindowHandle, _swMaximize);
        }

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
