using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public partial class InvoiceNode
    {
        public bool UseCustomPricing { get; set; }

        public InvoiceNode()
        {
            throw new Exception("Ürün nesnesi oluşturulurken hata oluştur.");
        }

        public InvoiceNode(Item item)
        {
            this.ItemID = item.ID;
            this.Item = item;
            this.BasePrice = item.FinalPrice;
            this.FinalPrice = this.BasePrice;
            this.Tax = item.Tax;
        }
    }
}
