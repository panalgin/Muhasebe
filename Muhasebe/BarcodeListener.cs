using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RawInputInterface;
using System.Windows.Forms;
using System.Diagnostics;
using Muhasebe.Events;

namespace Muhasebe
{
    public static class BarcodeListener
    {
        private static RawInput RawListener;
        private static PreMessageFilter Filter = new PreMessageFilter();
        private static string Buffer = "";
        public static void Initialize(IntPtr parentHandle)
        {
            RawListener = new RawInput(parentHandle, false);
            RawListener.KeyPressed += RawListener_KeyPressed;
        }

        private static void RawListener_KeyPressed(object sender, RawInputEventArg e)
        {
            if (e.KeyPressEvent.KeyPressState == "MAKE")
            {
                if (e.KeyPressEvent.DeviceName.Contains("1D57"))
                {
                    Application.AddMessageFilter(Filter);
                }
            }
            else if (e.KeyPressEvent.KeyPressState == "BREAK")
            {
                Application.RemoveMessageFilter(Filter);

                if (e.KeyPressEvent.DeviceName.Contains("1D57"))
                {
                    if (e.KeyPressEvent.VKey != (int)Keys.Enter && e.KeyPressEvent.VKey != 16) // 16 = Data Link Escape
                        Buffer += string.Format("{0}", GetKeyNumericValue(e.KeyPressEvent.VKey));

                    if (e.KeyPressEvent.VKey == (int)Keys.Enter)
                    {
                        Debug.WriteLine(Buffer);
                        BarcodeScannedEventArgs m_Args = new BarcodeScannedEventArgs();
                        m_Args.Barcode = Buffer;
                        m_Args.ScannedAt = DateTime.Now;
                        EventSink.InvokeBarcodeScanned(e.KeyPressEvent.DeviceName, m_Args);
                        Buffer = "";
                    }
                }
            }
        }

        private static char GetKeyNumericValue(int e)
        {
            return (char)e;
        }
    }
}
