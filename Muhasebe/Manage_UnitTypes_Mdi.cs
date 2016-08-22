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
    public partial class Manage_UnitTypes_Mdi : Form
    {
        public Manage_UnitTypes_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_UnitTypes_Mdi_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            this.listView1.Items.Clear();
            MuhasebeEntities m_Context = new MuhasebeEntities();

            var m_Units = m_Context.UnitTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();
            Random m_Randomer = new Random();

            m_Units.All(delegate(UnitType m_Type)
            {
                ListViewItem m_Item = new ListViewItem();
                m_Item.Tag = m_Type.ID;
                m_Item.Text = m_Type.Name;
                m_Item.SubItems.Add(m_Type.Abbreviation);
                m_Item.SubItems.Add(m_Type.DecimalPlaces.ToString());

                object m_Sample = null;

                if (m_Type.DecimalPlaces == 0)
                    m_Sample = m_Randomer.Next(1000);
                else if (m_Type.DecimalPlaces > 0)
                {
                    int m_Count = m_Type.DecimalPlaces;

                    string m_Format = "{0:0.".PadRight(m_Count + 5, '0') + "}";

                    m_Sample = Convert.ToDecimal(string.Format(m_Format, m_Randomer.NextDouble() * 1000));
                }

                m_Item.SubItems.Add(string.Format("{0} {1}", m_Sample, m_Type.Abbreviation));

                if (m_Type.Owner == null)
                {
                    m_Item.BackColor = System.Drawing.Color.WhiteSmoke;
                }

                this.listView1.Items.Add(m_Item);

                return true;
            });
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_UnitType_Pop m_Pop = new Add_UnitType_Pop();
            m_Pop.UnitTypeAdded += Pop_UnitTypeAdded;
            m_Pop.ShowDialog();
        }

        void Pop_UnitTypeAdded(UnitType UnitType)
        {
            this.PopulateList();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];

                if (m_Item.Tag != null)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    int m_ItemID = Convert.ToInt32(m_Item.Tag);
                    UnitType m_Type = m_Context.UnitTypes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Type.OwnerID != null && m_Type.OwnerID == Program.User.WorksAtID)
                    {
                        m_Context.UnitTypes.Remove(m_Type);
                        m_Context.SaveChanges();
                        m_Item.Remove();

                        PopulateList();
                    }
                    else
                        MessageBox.Show("Bu nesneyi silmek için yetkiniz yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Silme işlemi başarısız, bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Select = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Select.Tag);

                if (m_ItemID > 0)
                {
                    UnitType m_Item = m_Context.UnitTypes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Item.OwnerID != null && m_Item.OwnerID == Program.User.WorksAtID)
                    {
                        Edit_UnitType_Pop m_Pop = new Edit_UnitType_Pop();
                        m_Pop.UnitType = m_Item;
                        m_Pop.UnitTypeEdited += Pop_UnitTypeEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Bu nesneyi düzenlemek için yetkiniz yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Pop_UnitTypeEdited(UnitType UnitType)
        {
            this.PopulateList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Delete_Button.Enabled = true;
                this.Edit_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.Edit_Button.Enabled = false;
            }
        }
    }
}
