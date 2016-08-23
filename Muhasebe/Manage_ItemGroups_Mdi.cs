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
    public partial class Manage_ItemGroups_Mdi : Form
    {
        public Manage_ItemGroups_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_ItemGroups_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_ItemGroups = m_Context.ItemGroups.ToList();

                    this.listView1.BeginUpdate();
                    this.listView1.Items.Clear();

                    m_ItemGroups.ForEach(delegate (ItemGroup m_Group)
                    {
                        if (this == null)
                            return;

                        ListViewItem m_Item = new ListViewItem();
                        m_Item.Tag = m_Group.ID;
                        m_Item.Text = m_Group.Name;

                        if (m_Group.Items != null)
                            m_Item.SubItems.Add(m_Group.Items.Count.ToString());
                        else
                            m_Item.SubItems.Add("-");

                        m_Item.SubItems.Add(m_Group.ID.ToString());

                        this.listView1.Items.Add(m_Item);

                    });

                    this.listView1.EndUpdate();

                }

            });
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_ItemGroup_Mdi m_Mdi = new Add_ItemGroup_Mdi();
            m_Mdi.ShowDialog();
            this.PopulateListView();
        }
    }
}
