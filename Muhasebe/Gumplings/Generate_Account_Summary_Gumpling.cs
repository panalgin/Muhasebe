using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe.Gumplings
{
    public partial class Generate_Account_Summary_Gumpling : Form
    {
        public Account Account { get; set; }
        public Generate_Account_Summary_Gumpling()
        {
            InitializeComponent();
        }

        private void Generate_Account_Summary_Gumpling_Load(object sender, EventArgs e)
        {
            if (this.Account != null)
            {
                this.Account_Box.Text = this.Account.Name;
            }
        } 



        private void All_Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton m_Current = sender as RadioButton;

            if (m_Current.Checked)
            {
                if (m_Current.Tag.ToString() == "4")
                {
                    this.BeginsAt_Picker.Enabled = true;
                    this.EndsAt_Picker.Enabled = true;
                }
                else
                {
                    this.BeginsAt_Picker.Enabled = false;
                    this.EndsAt_Picker.Enabled = false;
                }
            }
        }

        private void Last_Month_Radio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
