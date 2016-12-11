using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Custom
{
    public class AccountSummary
    {
        public decimal BuyVolume { get; set; }
        public decimal SellVolume { get; set; }
        public decimal LoanTotal { get; set; }
        public decimal DebtTotal { get; set; }

        public decimal Charged { get; set; }
        public decimal Paid { get; set; }

        public decimal LoanNet { get { return LoanTotal - Charged; } }
        public decimal DebtNet { get { return DebtTotal - Paid; } }
        public decimal Net { get { return DebtNet - LoanNet; } }
    }
}
