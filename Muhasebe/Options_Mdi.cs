using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Muhasebe.Scripts;

namespace Muhasebe
{
    public partial class Options_Mdi : Form
    {
        public Options_Mdi()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Startup_Check.Checked)
            {
                if (AutoStarter.IsAutoStartEnabled)
                    AutoStarter.UnSetAutoStart();

                AutoStarter.SetAutoStart();
            }
            else
                AutoStarter.UnSetAutoStart();

            if (this.ShowStats_Check.Checked)
                GuiManipulator.CanShowStatistics = true;
            else
                GuiManipulator.CanShowStatistics = false;

            Properties.Settings.Default.AlertForLowAmountItems = this.AlertForAmount_Check.Checked;
            Properties.Settings.Default.LowAmountTheresold = Convert.ToInt32(this.LowAmountTheresold_Num.Value);
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Options_Mdi_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            if (AutoStarter.IsAutoStartEnabled)
                this.Startup_Check.Checked = true;

            if (GuiManipulator.CanShowStatistics)
                this.ShowStats_Check.Checked = true;

            if (Properties.Settings.Default.AlertForLowAmountItems)
                this.AlertForAmount_Check.Checked = true;

            this.LowAmountTheresold_Num.Value = Properties.Settings.Default.LowAmountTheresold;
            this.groupBox1.Enabled = this.AlertForAmount_Check.Checked;

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (Program.User.Position != null && Program.User.PositionID == 1) // Is owner ?
                    this.ShowStats_Check.Visible = true;

                else
                    this.ShowStats_Check.Visible = false;
            }
        }

        private void AlertForAmount_Check_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.AlertForAmount_Check.Checked;
        }
    }
}
