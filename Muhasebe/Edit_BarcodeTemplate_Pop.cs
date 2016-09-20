using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Edit_BarcodeTemplate_Pop : Form
    {
        public delegate void OnItemEdited(BarcodeTemplate template);
        public event OnItemEdited ItemEdited;

        public BarcodeTemplate Template { get; set; }

        public Edit_BarcodeTemplate_Pop()
        {
            InitializeComponent();
        }

        private void Edit_BarcodeTemplate_Pop_Load(object sender, EventArgs e)
        {
            if (this.Template != null)
            {
                this.Name_Box.Text = this.Template.Name;
                this.Path_Box.Text = this.Template.Path;
                this.Width_Num.Value = this.Template.Width.Value;
                this.Height_Num.Value = this.Template.Height.Value;

                if (this.Template.IsDefault.HasValue)
                    this.IsDefault_Check.Checked = this.Template.IsDefault.Value;
            }
        }
        private void Save_Button_Click(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                BarcodeTemplate m_Actual = m_Context.BarcodeTemplates.Where(q => q.ID == this.Template.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Name = this.Name_Box.Text;
                    m_Actual.Path = this.Path_Box.Text;
                    m_Actual.Width = Convert.ToInt32(this.Width_Num.Value);
                    m_Actual.Height = Convert.ToInt32(this.Height_Num.Value);

                    if (this.IsDefault_Check.Checked)
                    {
                        m_Context.BarcodeTemplates.Where(q => q.OwnerID == Program.User.WorksAtID).All(delegate (BarcodeTemplate template)
                        {
                            template.IsDefault = false;
                            return true;
                        });
                    }

                    m_Actual.IsDefault = this.IsDefault_Check.Checked;

                    m_Context.SaveChanges();
                    InvokeItemEdited(m_Actual);
                }
                else
                {
                    MessageBox.Show("Düzenlemeye çalıştığınız tasarım artık yok.", "Hata", MessageBoxButtons.OK);
                }

                this.Close();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(this.openFileDialog1.FileName))
                {
                    string m_Path = this.openFileDialog1.FileName;

                    this.Path_Box.Text = m_Path;
                }
            }
        }


        private void InvokeItemEdited(BarcodeTemplate template)
        {
            ItemEdited?.Invoke(template);
        }
    }
}
