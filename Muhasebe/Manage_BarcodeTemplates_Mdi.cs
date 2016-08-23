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
    public partial class Manage_BarcodeTemplates_Mdi : Form
    {
        public Manage_BarcodeTemplates_Mdi()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_BarcodeTemplate_Mdi m_Mdi = new Add_BarcodeTemplate_Mdi();
            m_Mdi.ShowDialog();
            this.PopulateListView();
        }

        private void Manage_BarcodeTemplates_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {

                var m_Templates = m_Context.BarcodeTemplates.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.listView1.BeginUpdate();
                    this.listView1.Items.Clear();

                    m_Templates.ForEach(delegate (BarcodeTemplate m_Template)
                    {
                        if (this == null)
                            return;

                        ListViewItem m_Item = new ListViewItem();
                        m_Item.Tag = m_Template.ID;
                        m_Item.Text = m_Template.Name;
                        m_Item.SubItems.Add(m_Template.Path);
                        m_Item.SubItems.Add(m_Template.CreatedAt.ToString());
                        m_Item.SubItems.Add(m_Template.Width.ToString());
                        m_Item.SubItems.Add(m_Template.Height.ToString());
                        m_Item.SubItems.Add(m_Template.ID.ToString());

                        this.listView1.Items.Add(m_Item);

                    });

                    this.listView1.EndUpdate();
                });
            }
        }
    }
}
