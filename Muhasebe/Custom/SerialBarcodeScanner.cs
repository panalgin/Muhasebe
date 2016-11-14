using Muhasebe.Events;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Custom
{
    public class SerialBarcodeScanner : SerialDevice
    {
        public SerialBarcodeScanner()
        {
            this.DataReceived += SerialBarcodeScanner_DataReceived;
        }

        private void SerialBarcodeScanner_DataReceived(string data)
        {
            BarcodeScannedEventArgs m_Args = new BarcodeScannedEventArgs();
            m_Args.Barcode = data.Split('\r')[0];
            m_Args.ScannedAt = DateTime.Now;

            EventSink.InvokeBarcodeScanned(this, m_Args);
        }
    }
}
