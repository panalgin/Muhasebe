using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Add_UnitType_Pop : Form
    {
        public delegate void OnUnitTypeAdded(UnitType UnitType);
        public event OnUnitTypeAdded UnitTypeAdded;
        
        public Add_UnitType_Pop()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UnitType m_Type = new UnitType();
                m_Type.Name = this.Name_Box.Text;
                m_Type.Abbreviation = this.Abbreviation_Box.Text;
                m_Type.DecimalPlaces = Convert.ToInt32(this.DecimalPlaces_Num.Value);
                m_Type.OwnerID = Program.User.WorksAtID;

                MicroEntities m_Context = new MicroEntities();
                m_Context.UnitTypes.Add(m_Type);
                m_Context.SaveChanges();
                InvokeUnitTypeAdded(m_Type);

                this.Close();
            }
        }

        private void InvokeUnitTypeAdded(UnitType UnitType)
        {
            if (UnitTypeAdded != null)
                UnitTypeAdded(UnitType);
        }

        private bool ValidateInput()
        {
            MicroEntities m_Context = new MicroEntities();

            if (this.Name_Box.Text.Length < 2)
            {
                this.Error_Provider.SetError(this.Name_Box, "Girdiğiniz ölçü adı çok kısa.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Name_Box, string.Empty);

            bool m_ContainsName = m_Context.UnitTypes.Where(q => q.Name == this.Name_Box.Text && (q.OwnerID == null || q.OwnerID == Program.User.WorksAtID)).FirstOrDefault() != null;

            if (m_ContainsName)
            {
                this.Error_Provider.SetError(this.Name_Box, "Girdiğiniz ölçü adı zaten kayıtlı, başka bir isim deneyin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Name_Box, string.Empty);

            if (this.Abbreviation_Box.Text.Length < 1)
            {
                this.Error_Provider.SetError(this.Abbreviation_Box, "Bir kısaltma girmelisiniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Abbreviation_Box, string.Empty);

            bool m_ContainsAbb = m_Context.UnitTypes.Where(q => q.Abbreviation == this.Abbreviation_Box.Text && (q.OwnerID == null || q.OwnerID == Program.User.WorksAtID)).FirstOrDefault() != null;

            if (m_ContainsAbb)
            {
                this.Error_Provider.SetError(this.Abbreviation_Box, "Girdiğiniz kısaltma zaten kayıtlı, başka bir kısaltma girin.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Abbreviation_Box, string.Empty);

            return true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
