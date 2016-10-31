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
    public partial class Manage_Orders_Mdi : Form
    {
        public Manage_Orders_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Orders_Mdi_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Order_Mdi m_Mdi = new Add_Order_Mdi();
            m_Mdi.ShowDialog();
            PopulateListView();
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Orders = Program.User.WorksAt.Orders;

                m_Orders.All(delegate (Order order)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = order.ID;
                    m_Item.Text = order.ID.ToString();
                    m_Item.SubItems.Add(order.Name);
                    m_Item.SubItems.Add(order.CreatedAt.ToString());

                    if (order.Account != null)
                        m_Item.SubItems.Add(order.Account.Name);
                    else
                        m_Item.SubItems.Add("Yok");

                    m_Item.SubItems.Add(order.Note);

                    this.listView1.Items.Add(m_Item);

                    return true;
                });
            }
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
            if (this.listView1.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_OrderID = Convert.ToInt32(m_Item.Tag);

                using(MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Order m_Order = m_Context.Orders.Where(q => q.ID == m_OrderID).FirstOrDefault();

                    if (m_Order != null)
                    {
                        if (MessageBox.Show(string.Format("{0} adlı sipariş silinecek, emin misiniz?", m_Order.Name), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            m_Context.Orders.Remove(m_Order);
                            m_Context.SaveChanges();

                            PopulateListView();
                        }
                    }
                }

            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_OrderID = Convert.ToInt32(m_Item.Tag);
                
                using(MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Order m_Order = m_Context.Orders.Where(q => q.ID == m_OrderID).FirstOrDefault();

                    if (m_Order != null)
                    {
                        Edit_Order_Mdi m_Mdi = new Edit_Order_Mdi();
                        m_Mdi.Order = m_Order;
                        m_Mdi.ShowDialog();

                        PopulateListView();
                    }
                }
            }
        }
    }
}
