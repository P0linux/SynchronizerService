using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynchronizerService
{
    class Massage
    {
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSSendMessage(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.I4)] int SessionId,
            String pTitle,
            [MarshalAs(UnmanagedType.U4)] int TitleLength,
            String pMessage,
            [MarshalAs(UnmanagedType.U4)] int Messagelength,
            [MarshalAs(UnmanagedType.U4)] int Style,
            [MarshalAs(UnmanagedType.I4)] int Timeout,
            [MarshalAs(UnmanagedType.I4)] out int pResponse,
            bool bWait);

        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
        public static int WTS_CURRENT_SESSION = 1;

        public void ShowMessage(string wildcard, string sourceFolder, string targetFolder)
        {
            try
            {
                bool result = false;
                string title = "SynchronizerService notification";
                int tlen = title.Length;
                String message = String.Format("All {0} files were copied from {1} to {2}", wildcard, sourceFolder, targetFolder);
                int mlen = message.Length;
                int resp = 0;
                result = WTSSendMessage(WTS_CURRENT_SERVER_HANDLE, WTS_CURRENT_SESSION, title, tlen, message, mlen, 0, 0, out resp, false);
                //int err = Marshal.GetLastWin32Error();
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }
        }
    }
}
