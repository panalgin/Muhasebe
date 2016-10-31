using Muhasebe.Events;
using Muhasebe.Gumplings;
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
    public partial class Edit_Order_Mdi : Form
    {
        public Order Order { get; set; }
        public Edit_Order_Mdi()
        {
            InitializeComponent();
        }

        private void Edit_Order_Mdi_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.Order == null)
                    this.Order = new Order();
            }

            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            this.Name_Box.Text = this.Order.Name;

            if (this.Order.Account != null)
            {
                this.Account_Box.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.Account_Box.SelectedText = this.Order.Account.Name;
                });
            }
            this.Attn_Note.Text = this.Order.Note;

            PopulateListView();
        }

        private void EventSink_BarcodeScanned(object sender, BarcodeScannedEventArgs args)
        {
            if (args.Barcode != null)
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_Item = m_Context.Items.Where(q => q.Product.Barcode == args.Barcode).FirstOrDefault();

                    if (m_Item != null)
                    {
                        OrderNode m_Node = new OrderNode();
                        m_Node.ItemID = m_Item.ID;
                        m_Node.OrderID = this.Order.ID;
                        m_Node.Order = this.Order;
                        m_Node.Amount = 1.00M;

                        if (this.Order.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.Order.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.Order.Nodes.Add(m_Node);
                    }
                    else
                        MessageBox.Show("Okuttuğunuz bu barkoda ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK);
                }

                PopulateListView();
            }
        }

        private void PopulateListView()
        {
            this.listView1.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.Order.Nodes.All(delegate (OrderNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Node.ID;

                    string imageResult = "";

                    if (!string.IsNullOrEmpty(m_Node.Item.LocalImagePath) && File.Exists(m_Node.Item.LocalImagePath))
                        imageResult = "Var";
                    else
                        imageResult = "Yok";

                    m_Item.Text = imageResult;

                    string orderCode = m_Node.Item.OrderCode;

                    if (string.IsNullOrEmpty(orderCode))
                        orderCode = "Yok";

                    m_Item.SubItems.Add(orderCode);
                    m_Item.SubItems.Add(m_Node.Item.Product.Name);

                    int numberOfDecimalPlaces = m_Node.Item.UnitType.DecimalPlaces;
                    string unitTypeName = m_Node.Item.UnitType.Name;

                    string formatString = String.Concat("{0:F", numberOfDecimalPlaces, "} {1}");

                    m_Item.SubItems.Add(string.Format(formatString, m_Node.Amount, unitTypeName, unitTypeName));
                    m_Item.SubItems.Add(m_Node.Description);


                    this.listView1.Items.Add(m_Item);

                    return true;
                });
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.listView1.SelectedItems[0];
                int m_NodeID = Convert.ToInt32(m_Item.Tag);

                OrderNode m_CurrentNode = this.Order.Nodes.Where(q => q.ID == m_NodeID).FirstOrDefault();
                OrderNode_Edit_Gumpling m_Pop = new OrderNode_Edit_Gumpling();
                m_Pop.OrderNode = m_CurrentNode;
                m_Pop.ShowDialog();

                this.PopulateListView();
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçtiğiniz sipariş nesnesi silinecek, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListViewItem m_Item = this.listView1.SelectedItems[0];

                    int m_NodeID = Convert.ToInt32(m_Item.Tag);
                    OrderNode m_TargetNode = this.Order.Nodes.Where(q => q.ID == m_NodeID).FirstOrDefault();

                    this.Order.Nodes.Remove(m_TargetNode);

                    this.PopulateListView();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
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

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Order m_Actual = m_Context.Orders.Where(q => q.ID == this.Order.ID).FirstOrDefault();

                    if (m_Actual != null)
                    {
                        m_Context.OrderNodes.RemoveRange(m_Actual.Nodes);

                        m_Actual.Nodes.Clear();
                        m_Context.SaveChanges();

                        this.Order.Nodes.All(delegate (OrderNode node) 
                        {
                            m_Actual.Nodes.Add(new OrderNode() { ItemID = node.ItemID, OrderID = node.OrderID, Amount = node.Amount, Description = node.Description });

                            return true;
                        });

                        m_Actual.AuthorID = Program.User.ID;
                        m_Actual.CreatedAt = DateTime.Now;
                        m_Actual.OwnerID = Program.User.WorksAtID.Value;
                        m_Actual.Name = this.Name_Box.Text;
                        m_Actual.Note = this.Attn_Note.Text;

                        if (this.Account_Box.SelectedValue != null)
                        {
                            int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                            m_Actual.AccountID = m_AccountID;
                        }

                        m_Context.SaveChanges();

                        this.Close();
                    }
                }
            }
        }

        private bool ValidateAll()
        {
            if (this.Name_Box.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.Name_Box, "En 3 karakterden oluşan bir form adı giriniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Name_Box, "");

            if (this.Attn_Note.Text.Length < 3)
            {
                this.Error_Provider.SetError(this.Attn_Note, "En az 3 karakterden oluşan bir uyarı notu giriniz.");
                return false;
            }
            else
                this.Error_Provider.SetError(this.Attn_Note, "");

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Order m_Existing = m_Context.Orders.Where(q => q.ID != this.Order.ID && q.Name == this.Name_Box.Text).FirstOrDefault();

                if (m_Existing != null)
                {
                    this.Error_Provider.SetError(this.Name_Box, "Daha önce bu isimle bir sipariş oluşturmuşsunuz. Başka bir isim deneyin.");
                    return false;
                }
                else
                    this.Error_Provider.SetError(this.Name_Box, "");
            }

            if (this.Order.Nodes.Count == 0)
            {
                MessageBox.Show("Siparişi kaydedebilmek için en az bir adet ürünü listeye eklemelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
