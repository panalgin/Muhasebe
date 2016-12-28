using Muhasebe.Custom;
using Muhasebe.Events;
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
    public partial class Add_Offer_Pop : Form
    {
        public Offer Offer { get; set; }

        public Add_Offer_Pop()
        {
            InitializeComponent();
        }

        private void Add_Offer_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                if (this.Offer == null)
                    this.Offer = new Offer();
            }

            EventSink.BarcodeScanned += EventSink_BarcodeScanned;
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
                        OfferNode m_Node = new OfferNode();
                        m_Node.Item = m_Item;
                        m_Node.ItemID = m_Item.ID;
                        m_Node.OfferID = this.Offer.ID;
                        m_Node.Offer = this.Offer;
                        m_Node.Amount = 1.00M;
                        m_Node.BasePrice = m_Node.Item.FinalPrice.Value;
                        m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;

                        if (this.Offer.Nodes.Any(q => q.ItemID == m_Node.ItemID))
                            this.Offer.Nodes.Where(q => q.ItemID == m_Node.ItemID).FirstOrDefault().Amount += 1.00M;
                        else
                            this.Offer.Nodes.Add(m_Node);
                    }
                    else
                        MessageBox.Show("Okuttuğunuz bu barkoda ait bir ürün bulunamadı.", "Hata", MessageBoxButtons.OK);
                }

                PopulateListView();
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Add_Offer_List.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.Add_Offer_List.SelectedItems[0];
                int m_ItemID = Convert.ToInt32(m_Item.Tag);

                OfferNode m_CurrentNode = this.Offer.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();
                Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                m_Gumpling.Node = m_CurrentNode;
                m_Gumpling.NodeAmountChanged += Gumpling_NodeAmountChanged;
                m_Gumpling.ShowDialog();
            }
        }

        private void Gumpling_NodeAmountChanged(dynamic node)
        {
            this.PopulateListView();
        }

        private void PopulateListView()
        {
            this.Add_Offer_List.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                this.Offer.Nodes.All(delegate (OfferNode m_Node)
                {
                    m_Node.Item = m_Context.Items.Where(q => q.ID == m_Node.ItemID).FirstOrDefault();
                    m_Node.FinalPrice = m_Node.BasePrice * m_Node.Amount;

                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = m_Node.ItemID;

                    string imageResult = "";

                    if (!string.IsNullOrEmpty(m_Node.Item.LocalImagePath) && File.Exists(m_Node.Item.LocalImagePath))
                        imageResult = "Var";
                    else
                        imageResult = "Yok";

                    m_Item.Text = imageResult;
                    m_Item.SubItems.Add(m_Node.Item.Product.Barcode);
                    m_Item.SubItems.Add(m_Node.Item.Product.Name);
                    m_Item.SubItems.Add(ItemHelper.GetFormattedAmount(m_Node.Amount, m_Node.Item.UnitType.DecimalPlaces, m_Node.Item.UnitType.Abbreviation));
                    m_Item.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.BasePrice));
                    m_Item.SubItems.Add(ItemHelper.GetFormattedPrice(m_Node.FinalPrice));
                    m_Item.SubItems.Add(m_Node.Description);

                    this.Add_Offer_List.Items.Add(m_Item);

                    return true;
                });
            }
        }

        private void Add_Offer_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Add_Offer_List.SelectedItems.Count > 0)
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
            if (this.Add_Offer_List.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Seçtiğiniz teklif nesnesi silinecek, onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListViewItem m_Item = this.Add_Offer_List.SelectedItems[0];

                    int m_ItemID = Convert.ToInt32(m_Item.Tag);
                    OfferNode m_Node = this.Offer.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                    if (m_Node != null)
                        this.Offer.Nodes.Remove(m_Node);

                    this.PopulateListView();
                }
            }
        }

        private void Add_Offer_List_DoubleClick(object sender, EventArgs e)
        {
            if (this.Add_Offer_List.SelectedItems.Count > 0)
            {
                ListViewItem m_Item = this.Add_Offer_List.SelectedItems[0];

                int m_ItemID = Convert.ToInt32(m_Item.Tag);

                OfferNode m_Node = this.Offer.Nodes.Where(q => q.ItemID == m_ItemID).FirstOrDefault();

                if (m_Node != null)
                {
                    Node_Set_Amount_Gumpling m_Gumpling = new Node_Set_Amount_Gumpling();
                    m_Gumpling.Node = m_Node;
                    m_Gumpling.NodeAmountChanged += Gumpling_NodeAmountChanged;
                    m_Gumpling.ShowDialog();
                }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    this.Offer.AuthorID = Program.User.ID;
                    this.Offer.CreatedAt = DateTime.Now;
                    this.Offer.OwnerID = Program.User.WorksAtID.Value;
                    this.Offer.Name = this.Name_Box.Text;
                    this.Offer.Note = this.Attn_Note.Text;

                    if (this.Account_Box.SelectedValue != null)
                    {
                        int m_AccountID = Convert.ToInt32(this.Account_Box.SelectedValue);
                        this.Offer.AccountID = m_AccountID;
                    }

                    this.Offer.Nodes.All(delegate (OfferNode node)
                    {
                        node.Item = null;

                        return true;
                    });

                    m_Context.Offers.Add(this.Offer);
                    m_Context.SaveChanges();

                    this.Close();
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
                Offer m_Existing = m_Context.Offers.Where(q => q.Name == this.Name_Box.Text).FirstOrDefault();

                if (m_Existing != null)
                {
                    this.Error_Provider.SetError(this.Name_Box, "Daha önce bu isimle bir teklif oluşturmuşsunuz. Başka bir isim deneyin.");
                    return false;
                }
                else
                    this.Error_Provider.SetError(this.Name_Box, "");
            }

            if (this.Offer.Nodes.Count == 0)
            {
                MessageBox.Show("Teklifi kaydedebilmek için en az bir adet ürünü listeye eklemelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
