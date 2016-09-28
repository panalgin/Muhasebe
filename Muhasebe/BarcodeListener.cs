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
                    if (e.KeyPressEvent.VKey != (int)Keys.Enter)
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


        private static readonly IDictionary<int, int> NumericKeys = new Dictionary<int, int> {
                                                                            { (int)Keys.D0, 0 },
                                                                            { (int)Keys.D1, 1 },
                                                                            { (int)Keys.D2, 2 },
                                                                            { (int)Keys.D3, 3 },
                                                                            { (int)Keys.D4, 4 },
                                                                            { (int)Keys.D5, 5 },
                                                                            { (int)Keys.D6, 6 },
                                                                            { (int)Keys.D7, 7 },
                                                                            { (int)Keys.D8, 8 },
                                                                            { (int)Keys.D9, 9 },
                                                                            { (int)Keys.NumPad0, 0 },
                                                                            { (int)Keys.NumPad1, 1 },
                                                                            { (int)Keys.NumPad2, 2 },
                                                                            { (int)Keys.NumPad3, 3 },
                                                                            { (int)Keys.NumPad4, 4 },
                                                                            { (int)Keys.NumPad5, 5 },
                                                                            { (int)Keys.NumPad6, 6 },
                                                                            { (int)Keys.NumPad7, 7 },
                                                                            { (int)Keys.NumPad8, 8 },
                                                                            { (int)Keys.NumPad9, 9 }
                                                                       };

        private static int GetKeyNumericValue(int e)
        {
            if (NumericKeys.ContainsKey(e)) return NumericKeys[e];
            else return -1;
        }
    }
}
