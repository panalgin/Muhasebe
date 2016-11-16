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
    public partial class Manage_Revenue_Mdi : Form
    {
        public Manage_Revenue_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Revenue_Mdi_Load(object sender, EventArgs e)
        {
            this.Sort_Combo.SelectedIndex = 0;
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
            MuhasebeEntities m_Context = new MuhasebeEntities();
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

            var m_Incomes = m_Context.Incomes.Where(q => q.OwnerID == Program.User.WorksAtID && q.CreatedAt >= m_Begin && q.CreatedAt <= m_End).OrderByDescending(q => q.CreatedAt).ToList();
            int m_Count = m_Incomes.Count;
            decimal? m_Total = m_Incomes.Sum(q => q.Amount);

            this.BeginInvoke((MethodInvoker)delegate()
            {
                this.Revenue_List.BeginUpdate();
                this.Revenue_List.Items.Clear();

                m_Incomes.ForEach(delegate(Income m_Income)
                {
                    if (this == null)
                        return;

                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Income.ID;
                    m_Item.Text = m_Income.CreatedAt.Value.ToString();
                    m_Item.SubItems.Add(m_Income.IncomeType.Name);
                    m_Item.SubItems.Add(m_Income.Amount.Value.ToString());

                    if (m_Income.Author != null)
                        m_Item.SubItems.Add(string.Format("{0} {1}", m_Income.Author.Name, m_Income.Author.Surname));
                    else
                        m_Item.SubItems.Add("Bilinmeyen");

                    if (m_Income.Account != null)
                        m_Item.SubItems.Add(m_Income.Account.Name);
                    else
                        m_Item.SubItems.Add("-");

                    m_Item.SubItems.Add(m_Income.Description);

                    this.Revenue_List.Items.Add(m_Item);
                    
                });

                this.Revenue_List.EndUpdate();
            });

            this.Stats_Label.Text = string.Format("Toplam Kayıt: {0} adet, Toplam Gelir: {1} TL", m_Count, m_Total.Value);
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
            Add_Revenue_Pop m_Pop = new Add_Revenue_Pop();
            m_Pop.RevenueAdded += m_Pop_RevenueAdded;
            m_Pop.ShowDialog();
        }

        void m_Pop_RevenueAdded(Income income)
        {
            this.PopulateListView();
        }

        private void Revenue_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Revenue_List.SelectedItems.Count == 1)
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
            if (this.Revenue_List.SelectedItems.Count > 0)
            {
                ListViewItem m_Selected = this.Revenue_List.SelectedItems[0];

                if (m_Selected.Tag != null)
                {
                    MuhasebeEntities m_Context = new MuhasebeEntities();
                    int m_ItemID = Convert.ToInt32(m_Selected.Tag);
                    Income m_Income = m_Context.Incomes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Income.AuthorID == Program.User.ID || Program.User.Position.ID == 1)
                    {
                        if (m_Income.InvoiceID != null && m_Income.InvoiceID != 0)
                        {
                            AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.MovementTypeID == 1 && q.ContractID == m_Income.InvoiceID).FirstOrDefault();
                            // peşin satış sonucu oluşan faturayı ve gelirin kendisini, hareketi de siliyoruz

                            if (m_Movement != null)
                                m_Context.AccountMovements.Remove(m_Movement); // Ticari Mal Satışı yada Alacak tahsilatı olan gelire ait hareketi sil

                            m_Income.Invoice.Nodes.All(delegate (InvoiceNode node)
                            {
                                if (node.Item != null)
                                    node.Item.Amount += node.Amount.Value;

                                return true;
                            });

                            m_Context.InvoiceNodes.RemoveRange(m_Income.Invoice.Nodes);
                            m_Context.Invoices.Remove(m_Income.Invoice);
                        }
                        else { //Bu gelirin faturası yok, bir vade tahsilatı olabilir?
                            AccountMovement m_Movement = m_Context.AccountMovements.Where(q => q.MovementTypeID == 2 && q.ContractID == m_Income.ID).FirstOrDefault();

                            if (m_Movement != null)
                                m_Context.AccountMovements.Remove(m_Movement);
                        }

                        m_Context.Incomes.Remove(m_Income);
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

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Revenue_List.SelectedItems.Count > 0)
            {
                MuhasebeEntities m_Context = new MuhasebeEntities();
                ListViewItem m_Selected = this.Revenue_List.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Selected.Tag);

                if (m_ItemID > 0)
                {
                    Income m_Income = m_Context.Incomes.Where(q => q.ID == m_ItemID).FirstOrDefault();

                    if (m_Income.OwnerID != null && m_Income.OwnerID == Program.User.WorksAtID)
                    {
                        Edit_Revenue_Pop m_Pop = new Edit_Revenue_Pop();
                        m_Pop.Income = m_Income;
                        m_Pop.RevenueEdited += Pop_RevenueEdited;
                        m_Pop.ShowDialog();
                    }
                    else
                        MessageBox.Show("Bu nesneyi düzenlemek için yetkiniz bulunmamaktadır", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Düzenleme sırasında bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Pop_RevenueEdited(Income income)
        {
            PopulateListView();
        }
    }
}
