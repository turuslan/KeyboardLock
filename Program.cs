using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardLock
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            const int WH_KEYBOARD_LL = 13;
            IntPtr hHook = SetWindowsHookEx(WH_KEYBOARD_LL, Callback, LoadLibrary("User32"), 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            UnhookWindowsHookEx(hHook);
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc();

        private static IntPtr Callback()
        {
            return (IntPtr)1;
        }
    }
}
