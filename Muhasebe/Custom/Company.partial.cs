using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
                //Too bad EF doesnt support cast DynamicProxy to Inherited Object 
                IEnumerable<BarcodePrinter> m_Output = this.Devices.Where(q => q.TypeID == 3).Select(q => new BarcodePrinter()
                {
                    Company = q.Company,
                    ConnectionType = q.ConnectionType,
                    Type = q.Type,
                    ConnectionTypeID = q.ConnectionTypeID,
                    ID = q.ID,
                    OwnerID = q.OwnerID,
                    Parameters = q.Parameters,
                    TypeID = q.TypeID
                });

                return m_Output;
            }
        }
    }
}
