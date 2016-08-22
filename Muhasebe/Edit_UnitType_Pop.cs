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
    public partial class Edit_UnitType_Pop : Form
    {
        public delegate void OnUnitTypeEdited(UnitType UnitType);
        public event OnUnitTypeEdited UnitTypeEdited;
        public UnitType UnitType { get; set; }

        public Edit_UnitType_Pop()
        {
            InitializeComponent();
        }

        private void Edit_UnitType_Pop_Load(object sender, EventArgs e)
        {
            MuhasebeEntities m_Context = new MuhasebeEntities();

            this.Name_Box.Text = this.UnitType.Name;
            this.Abbreviation_Box.Text = this.UnitType.Abbreviation;
            this.DecimalPlaces_Num.Value = this.UnitType.DecimalPlaces;

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.UnitType != null)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                UnitType m_Actual = m_Context.UnitTypes.Where(q => q.ID == this.UnitType.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Name = this.Name_Box.Text;
                    m_Actual.Abbreviation = this.Abbreviation_Box.Text;
                    m_Actual.DecimalPlaces = Convert.ToInt32(this.DecimalPlaces_Num.Value);

                    m_Context.SaveChanges();
                    InvokeUnitTypeEdited(m_Actual);

                    this.Close();
                }
            }
        }

        private void InvokeUnitTypeEdited(UnitType UnitType)
        {
            if (UnitTypeEdited != null)
                UnitTypeEdited(UnitType);
        }
    }
}
