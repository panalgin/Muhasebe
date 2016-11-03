using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public partial class AccountMovement
    {
        public string Flag
        {
            get
            {
                string result = "";

                if (this.MovementTypeID == 1) // Ticari Mal Satışı Yapıldı
                {
                    if (this.PaymentType.ID == 3) // Vadeli, veresiye satış
                        result = "Red";
                }
                else if (this.MovementTypeID == 2) //Vade Tahsilatı Yapıldı
                    result = "Green";
                else if (this.MovementTypeID == 3 && this.PaymentType.ID == 3) //Ürün Tedariği Yapıldı
                    result = "Red";
                else if (this.MovementTypeID == 4) //Ürün Ödemesi Yapıldı
                    result = "Green";

                return result;
            }
        }
        public AccountMovement()
        {

        }
    }
}
