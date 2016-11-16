using Muhasebe.Custom;
using Muhasebe.Events;
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
    public partial class Buy_Items_Pop : Form
    {
        public StockMovement StockMovement { get; set; }
        public Buy_Items_Pop()
        {
            InitializeComponent();
        }

        private void Buy_Items_Pop_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.StockMovement == null)
                    this.StockMovement = new StockMovement();

                var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                this.PaymentType_Combo.DataSource = m_PaymentTypes;
                this.PaymentType_Combo.ValueMember = "ID";
                this.PaymentType_Combo.DisplayMember = "Name";

                this.PaymentType_Combo.Invalidate();
            }
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
                        StockMovementNode m_Node = new StockMovementNode();
                        m_Node.ItemID = m_Item.ID;
                        m_Node.StockMovementID = this.StockMovement.ID;
                        m_Node.Amount = 1.00M;

                        if (this.StockMovement.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.StockMovement.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.StockMovement.Nodes.Add(m_Node);

                        this.Buy_Items_List.Focus();
                    }
                    else
                        MessageBox.Show("Okuttuğunuz bu barkoda ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK);
                }

                PopulateListView();
            }
        }

        private void PopulateListView()
        {
            this.Buy_Items_List.Items.Clear();
            this.Buy_Items_List.BeginUpdate();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();

                    ListViewItem m_ViewItem = new ListViewItem();
                    m_ViewItem.Tag = m_Node.ID;
                    m_ViewItem.Text = m_Node.Item.Product.Barcode;
                    m_ViewItem.SubItems.Add(m_Node.Item.OrderCode);
                    m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.Item.BasePrice.Value));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.Amount * m_Node.Item.BasePrice.Value));

                    this.Buy_Items_List.Items.Add(m_ViewItem);

                    return true;
                });

                decimal expectedSummary = this.StockMovement.Nodes.Sum(q => q.Item.BasePrice.Value * q.Amount);
                this.Expected_BasePrice_Label.Text = ItemHelper.GetFormattedPrice(expectedSummary);
                this.Summary_Num.Value = expectedSummary;
            }

            this.Buy_Items_List.EndUpdate();

        }

        private void Buy_Items_Pop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                if (this.StockMovement.Nodes.Count > 0)
                {
                    StockMovementNode m_Node = this.StockMovement.Nodes.LastOrDefault();
                    Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void NodeAmountChanged(dynamic node)
        {
            StockMovementNode m_Actual = this.StockMovement.Nodes.Where(q => q.ItemID == node.ItemID).FirstOrDefault();

            if (m_Actual != null)
                m_Actual.Amount = node.Amount;

            this.PopulateListView();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                if (m_Account != null)
                {
                    this.StockMovement.AccountID = m_Account.ID;
                    this.StockMovement.CreatedAt = DateTime.Now;
                    this.StockMovement.AuthorID = Program.User.ID;
                    this.StockMovement.OwnerID = Program.User.WorksAtID.Value;
                    this.StockMovement.PaymentTypeID = Convert.ToInt32(this.PaymentType_Combo.SelectedValue);
                    this.StockMovement.Summary = this.Summary_Num.Value;

                    m_Context.Entry(this.StockMovement).State = System.Data.Entity.EntityState.Added;

                    this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                    {
                        m_Node.StockMovementID = this.StockMovement.ID;
                        m_Context.Entry(m_Node).State = System.Data.Entity.EntityState.Added;

                        return true;
                    });

                    

                    m_Context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Bu mal alımı için bir cari hesap belirtmelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
