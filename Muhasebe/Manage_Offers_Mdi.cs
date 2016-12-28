using Muhasebe.Custom;
using OpenHtmlToPdf;
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
    public partial class Manage_Offers_Mdi : Form
    {
        public Manage_Offers_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Offers_Mdi_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Offer_Pop m_Pop = new Add_Offer_Pop();
            m_Pop.ShowDialog();
            PopulateListView();
        }

        private void PopulateListView()
        {
            this.Offers_List.Items.Clear();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Offers = m_Context.Offers.Where(q => q.OwnerID == Program.User.WorksAtID).ToList();

                this.Offers_List.BeginUpdate();

                m_Offers.All(delegate (Offer offer)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = offer.ID;
                    m_Item.Text = offer.ID.ToString();
                    m_Item.SubItems.Add(offer.Name);
                    m_Item.SubItems.Add(offer.CreatedAt.ToString());

                    if (offer.Account != null)
                        m_Item.SubItems.Add(offer.Account.Name);
                    else
                        m_Item.SubItems.Add("Yok");

                    m_Item.SubItems.Add(offer.Note);

                    this.Offers_List.Items.Add(m_Item);

                    return true;
                });

                this.Offers_List.EndUpdate();
            }
        }

        private void Offer_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Offers_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
                this.Export_Pdf_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
                this.Export_Pdf_Button.Enabled = false;
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Offers_List.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.Offers_List.SelectedItems[0];
                int m_OfferID = Convert.ToInt32(m_Item.Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Offer m_Offer = m_Context.Offers.Where(q => q.ID == m_OfferID).FirstOrDefault();

                    if (m_Offer != null)
                    {
                        if (MessageBox.Show(string.Format("{0} adlı teklif silinecek, emin misiniz?", m_Offer.Name), "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            m_Context.Offers.Remove(m_Offer);
                            m_Context.SaveChanges();

                            PopulateListView();
                        }
                    }
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Offers_List.SelectedItems.Count == 1)
            {
                ListViewItem m_Item = this.Offers_List.SelectedItems[0];
                int m_OfferID = Convert.ToInt32(m_Item.Tag);

                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    Offer m_Offer = m_Context.Offers.Where(q => q.ID == m_OfferID).FirstOrDefault();

                    if (m_Offer != null)
                    {
                        Edit_Offer_Pop m_Pop = new Edit_Offer_Pop();
                        m_Pop.Offer = m_Offer;
                        m_Pop.ShowDialog();

                        PopulateListView();
                    }
                }
            }
        }

        private void Export_Pdf_Button_Click(object sender, EventArgs e)
        {
            this.Export_Pdf_Button.Enabled = false;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    ListViewItem m_Item = this.Offers_List.SelectedItems[0];
                    int m_OfferID = Convert.ToInt32(m_Item.Tag);

                    Offer m_Offer = m_Context.Offers.Where(q => q.ID == m_OfferID).FirstOrDefault();

                    this.Save_Dialog.FileName = string.Format("Teklif - {0}.pdf", m_OfferID);

                    if (m_Offer != null && this.Save_Dialog.ShowDialog() == DialogResult.OK)
                    {
                        string m_SavePath = this.Save_Dialog.FileName;
                        string html = "";
                        string m_LocalPath = Application.StartupPath;
                        string m_IndexPath = Path.Combine(m_LocalPath, "View\\OfferForm\\index.html");
                        string m_AbsPath = Path.Combine(m_LocalPath, "View\\OfferForm\\");

                        using (StreamReader m_Reader = new StreamReader(m_IndexPath, Encoding.UTF8, true))
                        {
                            html = m_Reader.ReadToEnd();
                        }

                        html = html.Replace("{PATH}", m_AbsPath);
                        html = html.Replace("{BASEPATH}", m_LocalPath);
                        html = html.Replace("{COMPANY-NAME}", Program.User.WorksAt.Name);
                        html = html.Replace("{TAXID}", Program.User.WorksAt.TaxID);
                        html = html.Replace("{TAXPLACE}", Program.User.WorksAt.TaxDepartment);
                        html = html.Replace("{ADDRESS}", Program.User.WorksAt.Address);
                        html = html.Replace("{DISTRICT}", Program.User.WorksAt.District);
                        html = html.Replace("{PROVINCE}", Program.User.WorksAt.Province);
                        html = html.Replace("{TELEPHONE}", Program.User.WorksAt.Phone);
                        html = html.Replace("{EMAIL}", Program.User.WorksAt.Email);
                        html = html.Replace("{ATTN-NAME}", m_Offer.Account != null ? m_Offer.Account.Name : "Yetkili");
                        html = html.Replace("{AUTHOR-NAME}", Program.User.FullName);
                        html = html.Replace("{AUTHOR-POSITION}", Program.User.Position.Name);
                        html = html.Replace("{AUTHOR-EMAIL}", Program.User.Email);
                        html = html.Replace("{AUTHOR-GSM}", Program.User.WorksAt.Gsm);
                        html = html.Replace("{ORDER-ID}", m_Offer.ID.ToString());
                        html = html.Replace("{ATTN-NOTE}", m_Offer.Note);

                        string m_Template = "<tr class=\"item\">" +
                                    "<td class=\"pro-img\"><img src=\"{0}\" /></td>" +
                                    "<td class=\"pro-code\">{1}</td>" +
                                    "<td class=\"pro-name\">{2}</td>" +
                                    "<td class=\"pro-quantity\">{3}</td>" +
                                    "<td class=\"pro-base\">{4}</td>" +
                                    "<td class=\"pro-total\">{5}</td>" +
                                    "<td class=\"pro-desc\">{6}</td>" +
                                "</tr>";

                        string m_Data = "";

                        m_Offer.Nodes.All(delegate (OfferNode node)
                        {
                            if (node.Item == null)
                                return true;

                            string m_ProImgPath = Path.Combine(m_LocalPath, node.Item.LocalImagePath);

                            m_Data += string.Format(m_Template, File.Exists(m_ProImgPath) ? m_ProImgPath : "", node.Item.Product.Barcode, node.Item.Product.Name, ItemHelper.GetFormattedAmount(node.Amount, node.Item.UnitType.DecimalPlaces, node.Item.UnitType.Name), ItemHelper.GetFormattedPrice(node.BasePrice), ItemHelper.GetFormattedPrice(node.FinalPrice), node.Description);

                            return true;
                        });

                        html = html.Replace("{DATA}", m_Data);

                        try
                        {
                            var pdf = Pdf
                                .From(html)
                                .OfSize(PaperSize.A4)
                                .WithTitle("Title")
                                .WithMargins(0.8.Centimeters())
                                .WithoutOutline()
                                .Portrait()
                                .Comressed()
                                .Content();


                            FileStream m_Stream = new FileStream(m_SavePath, FileMode.Create);

                            using (BinaryWriter m_Writer = new BinaryWriter(m_Stream))
                            {
                                m_Writer.Write(pdf, 0, pdf.Length);
                            }

                            m_Stream.Close();
                            m_Stream.Dispose();
                            MessageBox.Show("Pdf dosyası oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Logger.Enqueue(ex);
                            MessageBox.Show("Oluşan bir hata nedeniyle pdf dosyası yazılamadı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            this.Export_Pdf_Button.Enabled = true;
        }
    }
}
