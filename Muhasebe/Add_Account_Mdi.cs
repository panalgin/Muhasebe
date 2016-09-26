using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Add_Account_Mdi : Form
    {
        public Add_Account_Mdi()
        {
            InitializeComponent();
        }

        private void Add_Account_Mdi_Load(object sender, EventArgs e)
        {
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Cities = m_Context.Cities.ToList();

                this.City_Combo.DataSource = m_Cities;
                this.City_Combo.ValueMember = "ID";
                this.City_Combo.DisplayMember = "Name";

                this.City_Combo.SelectedIndexChanged += City_Combo_SelectedIndexChanged;
                
                this.City_Combo.Invalidate();
            }

            this.City_Combo.BeginInvoke(new MethodInvoker(delegate ()
            {
                this.City_Combo.SelectedIndex = 58;
            }));

            this.AccountType_Combo.SelectedIndex = 0;
        }

        private void City_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                int m_CityID = Convert.ToInt32(this.City_Combo.SelectedValue);
                City m_City = m_Context.Cities.Where(q => q.ID == m_CityID).FirstOrDefault();

                if (m_City != null)
                {
                    var m_Provinces = m_City.Provinces.ToList();

                    this.Province_Combo.DataSource = m_Provinces;
                    this.Province_Combo.ValueMember = "ID";
                    this.Province_Combo.DisplayMember = "Name";

                    this.Province_Combo.Invalidate();
                }
            } 
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
