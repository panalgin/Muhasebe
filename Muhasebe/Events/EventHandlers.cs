using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Events
{
    public delegate void OnErrorEventHandler(object sender, ErrorEventArgs args);
    public delegate void OnBarcodeScannedEventHandler(object sender, BarcodeScannedEventArgs args);
    public delegate void OnUserLogonEventHandler(object sender, UserLogonEventArgs args);
}
