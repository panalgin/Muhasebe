using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public partial class Company
    {
        public IEnumerable<BarcodePrinter> BarcodePrinters
        {
            get
            {
                return this.Devices.Where(q => q.Type.Universal == "Barcode Printer") as IEnumerable<BarcodePrinter>;
            }
        }
    }
}
