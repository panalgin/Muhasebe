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
using System.IO;
using System.Media;

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
            Properties.Settings.Default.LowAmountAlertColor = this.LowAmountColor_Preview_Label.BackColor;

            Properties.Settings.Default.AlertForUnpricedItems = this.AlertForUnpriced_Check.Checked;
            Properties.Settings.Default.UnpricedAlertColor = this.Unpriced_Color_Preview_Label.BackColor;

            Properties.Settings.Default.PlaySoundOnScanned = this.Sound_Check.Checked;
            Properties.Settings.Default.SoundFileLocation = (this.Sound_Combo.SelectedItem as SoundEntity).FilePath;

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

            if (Properties.Settings.Default.AlertForUnpricedItems)
                this.AlertForUnpriced_Check.Checked = true;

            this.LowAmountColor_Preview_Label.BackColor = Properties.Settings.Default.LowAmountAlertColor;
            this.LowAmountTheresold_Num.Value = Properties.Settings.Default.LowAmountTheresold;
            this.groupBox1.Enabled = this.AlertForAmount_Check.Checked;

            this.Unpriced_Color_Preview_Label.BackColor = Properties.Settings.Default.UnpricedAlertColor;
            this.groupBox2.Enabled = this.AlertForUnpriced_Check.Checked;

            string m_SoundPath = Path.Combine(Application.StartupPath, "Sounds");
            List<string> m_Files = Directory.EnumerateFiles(m_SoundPath, "*.wav", SearchOption.AllDirectories).ToList();

            List<SoundEntity> m_Source = new List<SoundEntity>();

            m_Files.All(delegate (string m_FilePath)
            {
                SoundEntity m_Entity = new SoundEntity(m_FilePath, Path.GetFileName(m_FilePath));
                m_Source.Add(m_Entity);

                return true;
            });

            this.Sound_Combo.DataSource = m_Source;
            this.Sound_Combo.DisplayMember = "Name";
            this.Sound_Combo.ValueMember = "FilePath";

            this.Sound_Combo.Invalidate();
            this.Sound_Check.Checked = Properties.Settings.Default.PlaySoundOnScanned;
            this.groupBox3.Enabled = this.Sound_Check.Checked;

            if (Properties.Settings.Default.SoundFileLocation.Length > 0)
                this.Sound_Combo.SelectedValue = Properties.Settings.Default.SoundFileLocation;

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


        private void AlertForUnpriced_Check_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = this.AlertForUnpriced_Check.Checked;
        }

        private void Choose_LowAmountColor_Button_Click(object sender, EventArgs e)
        {
            if (Color_Dialog.ShowDialog() == DialogResult.OK)
            {
                this.LowAmountColor_Preview_Label.BackColor = Color_Dialog.Color;
            }
        }

        private void Choose_UnpricedColor_Button_Click(object sender, EventArgs e)
        {
            if (Color_Dialog.ShowDialog() == DialogResult.OK)
            {
                this.Unpriced_Color_Preview_Label.BackColor = Color_Dialog.Color;
            }
        }

        private class SoundEntity
        {
            public string FilePath { get; set; }
            public string Name { get; set; }

            public SoundEntity(string filepath, string name)
            {
                this.FilePath = filepath;
                this.Name = name;
            }
        }

        private void Sound_Check_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = this.Sound_Check.Checked;
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            if (this.Sound_Combo.SelectedItem != null)
            {
                SoundEntity m_Entity = this.Sound_Combo.SelectedItem as SoundEntity;
                SoundPlayer m_Player = new SoundPlayer(m_Entity.FilePath);
                m_Player.Play();
            }
        }
    }
}
