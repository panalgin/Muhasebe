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
    public partial class Edit_StockMovement_Mdi : Form
    {
        public StockMovement StockMovement { get; set; }

        public Edit_StockMovement_Mdi()
        {
            InitializeComponent();
        }

        private void Edit_StockMovement_Mdi_Load(object sender, EventArgs e)
        {
            EventSink.BarcodeScanned += EventSink_BarcodeScanned;

            if (this.StockMovement != null)
            {
                this.CreatedAt_Picker.Value = StockMovement.CreatedAt;
                this.Account_Box.SelectedText = StockMovement.Account.Name;
                this.Account_Box.Enabled = false;
                this.Discount_Num.Value = StockMovement.Discount.Value;

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    var m_PaymentTypes = m_Context.PaymentTypes.Where(q => q.OwnerID == null || q.OwnerID == Program.User.WorksAtID).ToList();

                    this.PaymentType_Combo.DataSource = m_PaymentTypes;
                    this.PaymentType_Combo.ValueMember = "ID";
                    this.PaymentType_Combo.DisplayMember = "Name";

                    this.PaymentType_Combo.Invalidate();

                    this.PaymentType_Combo.SelectedValue = StockMovement.PaymentTypeID;
                }
            }

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
                        StockMovementNode m_Node = new StockMovementNode();
                        m_Node.ItemID = m_Item.ID;
                        m_Node.StockMovementID = this.StockMovement.ID;
                        m_Node.Amount = 1.00M;
                        m_Node.BasePrice = m_Item.BasePrice;

                        if (this.StockMovement.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.StockMovement.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.StockMovement.Nodes.Add(m_Node);

                        this.Buy_Items_List.Focus();
                    }
                    else
                    {
                        Add_Item_Pop m_Pop = new Add_Item_Pop(args.Barcode);
                        m_Pop.ShowDialog();
                    }
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
                    m_ViewItem.Tag = m_Node.ItemID;
                    m_ViewItem.Text = m_Node.Item.Product.Barcode;
                    m_ViewItem.SubItems.Add(m_Node.Item.OrderCode);
                    m_ViewItem.SubItems.Add(m_Node.Item.Product.Name);
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Item.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.BasePrice.Value));
                    m_ViewItem.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.BasePrice.Value * m_Node.Amount));

                    this.Buy_Items_List.Items.Add(m_ViewItem);

                    return true;
                });

                decimal expectedSummary = this.StockMovement.Nodes.Sum(q => q.BasePrice.Value * q.Amount);
                this.SubTotal_Label.Text = ItemHelper.GetFormattedPrice(expectedSummary);

                decimal totalSummary = expectedSummary;

                if (this.StockMovement.Discount.HasValue)
                {
                    if (totalSummary > this.StockMovement.Discount.Value)
                        totalSummary -= this.StockMovement.Discount.Value;
                    else
                    {
                        this.StockMovement.Discount = 0;
                        this.Discount_Num.Value = 0;
                    }
                }

                this.Total_Label.Text = ItemHelper.GetFormattedPrice(totalSummary);
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
            {
                m_Actual.Amount = node.Amount;
                m_Actual.BasePrice = node.BasePrice;
            }

            this.PopulateListView();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.StockMovement.Nodes == null || this.StockMovement.Nodes.Count <= 0)
            {
                MessageBox.Show("Ürün alımı için en az bir adet ürünü listeye eklemelisiniz.", "Hata");
                return;
            }

            int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                Account m_Account = m_Context.Accounts.Where(q => q.ID == m_AccountID).FirstOrDefault();

                if (m_Account != null)
                {
                    this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                    {
                        m_Node.Parent = this.StockMovement;
                        m_Node.Item = null;
                        m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;

                        return true;
                    });

                    this.StockMovement.AccountID = m_Account.ID;
                    this.StockMovement.CreatedAt = CreatedAt_Picker.Value;
                    this.StockMovement.AuthorID = Program.User.ID;
                    this.StockMovement.OwnerID = Program.User.WorksAtID.Value;
                    this.StockMovement.PaymentTypeID = Convert.ToInt32(this.PaymentType_Combo.SelectedValue);
                    this.StockMovement.Summary = this.StockMovement.Nodes.Sum(q => q.FinalPrice.Value);

                    if (this.StockMovement.Discount.HasValue)
                        this.StockMovement.Summary -= this.StockMovement.Discount.Value;

                    //m_Context.StockMovements.Add(this.StockMovement);
                    m_Context.SaveChanges();

                    /*AccountMovement m_Movement = new AccountMovement();
                    m_Movement.AccountID = m_Account.ID;
                    m_Movement.AuthorID = Program.User.ID;
                    m_Movement.ContractID = this.StockMovement.ID;
                    m_Movement.CreatedAt = CreatedAt_Picker.Value;
                    m_Movement.MovementTypeID = 3; // Ürün tedariği yapıldı
                    m_Movement.OwnerID = Program.User.WorksAtID.Value;
                    m_Movement.PaymentTypeID = this.StockMovement.PaymentTypeID;
                    m_Movement.Value = this.StockMovement.Summary;

                    m_Context.AccountMovements.Add(m_Movement);
                    m_Context.SaveChanges();*/

                    /*if (this.StockMovement.PaymentTypeID != 3) //Vadeli değil
                    {
                        Expenditure m_Expenditure = new Expenditure();
                        m_Expenditure.CreatedAt = CreatedAt_Picker.Value;
                        m_Expenditure.Amount = this.StockMovement.Summary;
                        m_Expenditure.AuthorID = Program.User.ID;
                        m_Expenditure.ExpenditureTypeID = 5; //Ürün alım gideri
                        m_Expenditure.OwnerID = Program.User.WorksAtID;
                        m_Expenditure.AccountID = this.StockMovement.AccountID;
                        m_Expenditure.Description = "Yapılan ürün/hizmet alımı karşılığı peşin ödendi.";
                        m_Expenditure.MovementID = m_Movement.ID;

                        m_Context.Expenditures.Add(m_Expenditure);
                    }*/

                    /*if (this.Increase_Stock_Check.Checked) // alınan mallar sonucu stoğu artıralım
                    {
                        this.StockMovement.Nodes.All(delegate (StockMovementNode m_Node)
                        {
                            m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault().Amount += m_Node.Amount;

                            return true;
                        });
                    }*/

                    m_Context.SaveChanges();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bu mal alımı için bir cari hesap belirtmelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Buy_Items_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
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
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                int m_ItemID = Convert.ToInt32(this.Buy_Items_List.SelectedItems[0].Tag);

                StockMovementNode m_Node = this.StockMovement.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                if (m_Node != null)
                {
                    this.StockMovement.Nodes.Remove(m_Node);
                    PopulateListView();
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                int m_ItemID = Convert.ToInt32(this.Buy_Items_List.SelectedItems[0].Tag);

                StockMovementNode m_Node = this.StockMovement.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                m_Gumpling.Node = m_Node;
                m_Gumpling.NodeAmountChanged += NodeAmountChanged;
                m_Gumpling.ShowDialog();
            }
        }

        private void Discount_Num_ValueChanged(object sender, EventArgs e)
        {
            this.StockMovement.Discount = this.Discount_Num.Value;
            this.PopulateListView();
        }

        private void Buy_Items_List_DoubleClick(object sender, EventArgs e)
        {
            if (this.Buy_Items_List.SelectedItems.Count > 0)
            {
                Edit_Button_Click(sender, e);
            }
        }
    }
}
