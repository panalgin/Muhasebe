using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Custom
{
    public static class ItemHelper
    {
        public static string GetFormattedAmount(decimal amount, int decimalPlaces, string abbreviation)
        {
            string m_Amount = "";

            try
            {
                if (decimalPlaces == 0)
                {
                    if (amount == 0.0000M)
                    {
                        if (!string.IsNullOrEmpty(abbreviation))
                            m_Amount = string.Format("0 {0}", abbreviation);
                        else
                            m_Amount = "0";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(abbreviation))
                            m_Amount = string.Format("{0} {1}", amount.ToString("#"), abbreviation);
                        else
                            m_Amount = amount.ToString("#");
                    }
                }

                else
                {
                    string m_Format = "#." + "".PadRight(decimalPlaces, '#');

                    if (!string.IsNullOrEmpty(abbreviation))
                        m_Amount = amount.ToString(m_Format) + " " + abbreviation;
                    else
                        m_Amount = amount.ToString(m_Format);
                }
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }

            return m_Amount;
        }

        public static string GetFormattedPrice(decimal price)
        {
            return string.Format("{0:0.00} TL", price);
        }
    }
}
