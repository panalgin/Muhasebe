using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Events
{
    public class ErrorEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
        public DateTime HappenedAt { get; set; }
        public object ObjectContext { get; set; }
    }

    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
        public DateTime ScannedAt { get; set; }
    }

    public class UserLogonEventArgs : EventArgs
    {
        public User User { get; set; }
        public DateTime LogonAt { get; set; }
    }
}
