using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Events
{
    public static class EventSink
    {
        public static event OnErrorEventHandler Error;
        public static event OnBarcodeScannedEventHandler BarcodeScanned;
        public static event OnUserLogonEventHandler UserLogon;

        public static void InvokeError(object sender, ErrorEventArgs args)
        {
            if (Error != null)
                Error(sender, args);
        }

        public static void InvokeBarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (BarcodeScanned != null)
                BarcodeScanned(sender, args);
        }

        public static void InvokeUserLogon(object sender, UserLogonEventArgs args)
        {
            if (UserLogon != null)
                UserLogon(sender, args);
        }
    }
}
