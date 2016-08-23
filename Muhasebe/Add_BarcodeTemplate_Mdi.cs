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
    public partial class Add_BarcodeTemplate_Mdi : Form
    {
        public Add_BarcodeTemplate_Mdi()
        {
            InitializeComponent();
        }

        private void Add_BarcodeTemplate_Mdi_Load(object sender, EventArgs e)
        {

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                BarcodeTemplate m_Template = new BarcodeTemplate();
                m_Template.CreatedAt = DateTime.Now;
                m_Template.OwnerID = Program.User.WorksAtID;
                m_Template.Name = this.Name_Box.Text;
                m_Template.Path = this.Path_Box.Text;
                m_Template.Width = Convert.ToInt32(this.Width_Num.Value);
                m_Template.Height = Convert.ToInt32(this.Height_Num.Value);

                m_Context.BarcodeTemplates.Add(m_Template);
                m_Context.SaveChanges();

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
    }
}
