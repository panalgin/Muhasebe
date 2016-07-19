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
    public partial class Manage_Expenditure_Mdi : Form
    {
        public Manage_Expenditure_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Expenditure_Mdi_Load(object sender, EventArgs e)
        {
            this.Sort_Combo.SelectedIndex = 0;
            PopulateListView();
        }

        private void Sort_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Sort_Combo.SelectedItem.ToString() == "Belirli Tarih Aralığı")
            {
                this.Begin_Label.Visible = true;
                this.Begin_Picker.Visible = true;
                this.End_Label.Visible = true;
                this.End_Picker.Visible = true;
            }
            else
            {
                this.Begin_Label.Visible = false;
                this.Begin_Picker.Visible = false;
                this.End_Label.Visible = false;
                this.End_Picker.Visible = false;
            }

            PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();
            MicroEntities m_Context = new MicroEntities();
            DateTime m_Now = DateTime.Now;

            DateTime m_Begin = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 0, 0, 0);
            DateTime m_End = new DateTime(m_Now.Year, m_Now.Month, m_Now.Day, 23, 59, 59);

            switch (this.Sort_Combo.SelectedItem.ToString())
            {
                case "Bugün": //defaulted 
                    break;

                case "Son 7 Gün":
                    {
                        m_Begin = m_Begin.Subtract(TimeSpan.FromDays(7));

                        break;
                    }

                case "Son 30 Gün":
                    {
                        m_Begin = m_Begin.Subtract(TimeSpan.FromDays(30.0));

                        break;
                    }

                case "Son 60 Gün":
                    {
                        m_Begin = m_Begin.Subtract(TimeSpan.FromDays(60.0));

                        break;
                    }

                case "Son 6 Ay":
                    {
                        m_Begin = m_Begin.Subtract(TimeSpan.FromDays(180.0));

                        break;
                    }

                case "Son 1 Yıl":
                    {
                        m_Begin = m_Begin.Subtract(TimeSpan.FromDays(365.0));

                        break;
                    }

                case "Belirli Tarih Aralığı":
                    {
                        m_Begin = new DateTime(this.Begin_Picker.Value.Year, this.Begin_Picker.Value.Month, this.Begin_Picker.Value.Day, 0,0,0);
                        m_End = new DateTime(this.End_Picker.Value.Year, this.End_Picker.Value.Month, this.End_Picker.Value.Day, 23, 59, 59);

                        break;
                    }
            }

            var m_Expenditures = m_Context.Expenditures.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Begin && q.CreatedAt <= m_End).OrderByDescending(q => q.CreatedAt).ToList();
            int m_Count = m_Expenditures.Count;
            decimal? m_Total = m_Expenditures.Sum(q => q.Amount);

            this.BeginInvoke((MethodInvoker)delegate()
            {
                this.listView1.BeginUpdate();
                this.listView1.Items.Clear();

                m_Expenditures.ForEach(delegate(Expenditure m_Expenditure)
                {
                    if (this == null)
                        return;

                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Expenditure.ID;
                    m_Item.Text = m_Expenditure.CreatedAt.Value.ToString();
                    m_Item.SubItems.Add(m_Expenditure.ExpenditureType.Name);
                    m_Item.SubItems.Add(m_Expenditure.Amount.Value.ToString());
                    m_Item.SubItems.Add(m_Expenditure.PaymentType.Name);
                    m_Item.SubItems.Add(string.Format("{0} {1}", m_Expenditure.Author.Name, m_Expenditure.Author.Surname));
                    m_Item.SubItems.Add(m_Expenditure.Description);

                    this.listView1.Items.Add(m_Item);
                    
                });

                this.listView1.EndUpdate();
            });

            this.Stats_Label.Text = string.Format("Toplam Kayıt: {0} adet, Toplam Gider: {1} TL", m_Count, m_Total.Value);
        }

        private void Begin_Picker_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void End_Picker_ValueChanged(object sender, EventArgs e)
        {
            this.PopulateListView();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Expenditure_Pop m_Pop = new Add_Expenditure_Pop();
            m_Pop.ExpenditureAdded += Pop_ExpenditureAdded;
            m_Pop.ShowDialog();
        }

        void Pop_ExpenditureAdded(Expenditure Expenditure)
        {
            this.PopulateListView();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                MicroEntities m_Context = new MicroEntities();
                ListViewItem m_Selected = this.listView1.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Selected.Tag);

                if (m_ItemID > 0)
                {
                    Expenditure m_Item = m_Context.Expenditures.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Item.OwnerID != null && m_Item.OwnerID == Program.User.WorksAtID)
                    {
                        Edit_Expenditure_Pop m_Pop = new Edit_Expenditure_Pop();
                        m_Pop.Expenditure = m_Item;
                        m_Pop.ExpenditureEdited += Pop_ExpenditureEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Bu nesneyi düzenlemek için yetkiniz bulunmamaktadır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Pop_ExpenditureEdited(Expenditure Expenditure)
        {
            this.PopulateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem m_Selected = this.listView1.SelectedItems[0];

                if (m_Selected.Tag != null)
                {
                    MicroEntities m_Context = new MicroEntities();
                    int m_ItemID = Convert.ToInt32(m_Selected.Tag);
                    Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Expenditure.OwnerID != null && m_Expenditure.OwnerID == Program.User.WorksAtID)
                    {
                        m_Context.Expenditures.Remove(m_Expenditure);
                        m_Context.SaveChanges();
                        m_Selected.Remove();

                        PopulateListView();
                    }
                    else
                        MessageBox.Show("Bu nesneyi silmek için yetkiniz bulunmamaktadır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
