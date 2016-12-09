using Muhasebe.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe
{
    public partial class Account
    {
        public AccountSummary GetSummary(List<AccountMovement> m_Movements) { 
            AccountSummary m_Summary = new AccountSummary();

            m_Summary.BuyVolume = m_Movements.Where(q => q.MovementTypeID == 3).Sum(q => q.Value);
            m_Summary.SellVoluma = m_Movements.Where(q => q.MovementTypeID == 1).Sum(q => q.Value);

            m_Summary.LoanTotal = m_Movements.Where(q => q.MovementTypeID == 1 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli satışlardan alacak geçmişimiz
            m_Summary.Charged = m_Movements.Where(q => q.MovementTypeID == 2).Sum(q => q.Value); // Yapılan vade tahsilatları

            m_Summary.DebtTotal = m_Movements.Where(q => q.MovementTypeID == 3 && q.PaymentTypeID == 3).Sum(q => q.Value); // Yapılan vadeli ürün alımlarımıza ait borcumuz
            m_Summary.Paid = m_Movements.Where(q => q.MovementTypeID == 4).Sum(q => q.Value); // Yaptığımız borç ödemeleri

            return m_Summary;
        }
    }
}
