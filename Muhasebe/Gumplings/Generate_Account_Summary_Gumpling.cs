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

namespace Muhasebe.Gumplings
{
    public partial class Generate_Account_Summary_Gumpling : Form
    {
        public Account Account { get; set; }
        public Generate_Account_Summary_Gumpling()
        {
            InitializeComponent();
        }

        private void Generate_Account_Summary_Gumpling_Load(object sender, EventArgs e)
        {
            if (this.Account != null)
            {
                this.Account_Box.Text = this.Account.Name;
            }
        } 

        private void All_Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton m_Current = sender as RadioButton;

            if (m_Current.Checked)
            {
                if (m_Current.Tag.ToString() == "4")
                {
                    this.BeginsAt_Picker.Enabled = true;
                    this.EndsAt_Picker.Enabled = true;
                }
                else
                {
                    this.BeginsAt_Picker.Enabled = false;
                    this.EndsAt_Picker.Enabled = false;
                }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.Save_Button.Enabled = false;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                using (MuhasebeEntities m_Context = new MuhasebeEntities())
                {
                    List<AccountMovement> m_List = m_Context.AccountMovements.Where(q => q.AccountID == this.Account.ID).ToList();

                    m_List = m_List.OrderBy(q => q.CreatedAt).ToList();

                   

                    string m_Data = "";
                    string m_SummaryTemplate = "Yukarıdaki işlemler sonucunda firmamız <strong>{0}</strong>";
                    string m_BaseTemplate = "<tr class=\"movement\">" +
                                                 "<td class=\"id\">{0}</td>" +
                                                 "<td class=\"mtype\">{1}</td>" +
                                                 "<td class=\"date\">{2}</td>" +
                                                 "<td class=\"author\">{3}</td>" +
                                                 "<td class=\"payment\">{4}</td>" +
                                                 "<td class=\"desc\">{5}</td> " +
                                                 "<td class=\"price\">{6}</td>" +
                                             "</tr>";

                    m_List.All(delegate (AccountMovement movement)
                    {
                        string m_Description = "";

                        if (movement.MovementTypeID != 3) // ürün tedariğinde yorum yok
                        {
                            if (movement.MovementTypeID == 1 && movement.PaymentTypeID != 3) // Vadeli satış değilse
                            {
                                Income m_Income = m_Context.Incomes.Where(q => q.InvoiceID == movement.ContractID).FirstOrDefault();

                                if (m_Income != null)
                                    m_Description = m_Income.Description;
                            }
                            else if (movement.MovementTypeID == 2) // Alacak tahsilatı, gelir
                            {
                                Income m_Income = m_Context.Incomes.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Income != null)
                                    m_Description = m_Income.Description;
                            }
                            else if (movement.MovementTypeID == 4) // Borç ödemesi, gider
                            {
                                Expenditure m_Expenditure = m_Context.Expenditures.Where(q => q.ID == movement.ContractID).FirstOrDefault();

                                if (m_Expenditure != null)
                                    m_Description = m_Expenditure.Description;
                            }
                        }

                        string m_Formatted = string.Format(m_BaseTemplate, movement.ID, movement.MovementType.Name, movement.CreatedAt.ToString("dd/MM/yyyy"),
                            movement.Author.FullName, movement.PaymentType.Name, m_Description, ItemHelper.GetFormattedPrice(movement.Value));

                        m_Data += m_Formatted;

                        return true;
                    });

                    AccountSummary m_Summary = this.Account.GetSummary(m_Context.AccountMovements.Where(q => q.AccountID == this.Account.ID).ToList());

                    if (m_Summary.Net < 0)
                        m_SummaryTemplate = string.Format(m_SummaryTemplate, string.Format("sizden {0} alacaklıdır.", ItemHelper.GetFormattedPrice(Math.Abs(m_Summary.Net))));
                    else if (m_Summary.Net > 0)
                        m_SummaryTemplate = string.Format(m_SummaryTemplate, string.Format("size {0} borçludur.", ItemHelper.GetFormattedPrice(Math.Abs(m_Summary.Net))));
                    else
                        m_SummaryTemplate = "Herhangi bir alacak/borç bulunmamaktadır.";

                    this.Save_Dialog.FileName = string.Format("{0} - Hesap Özeti.pdf", this.Account.Name);

                    if (this.Save_Dialog.ShowDialog() == DialogResult.OK)
                    {
                        string m_SavePath = this.Save_Dialog.FileName;
                        string html = "";
                        string m_LocalPath = Application.StartupPath;
                        string m_IndexPath = Path.Combine(m_LocalPath, "View\\AccountSummaryForm\\index.html");
                        string m_AbsPath = Path.Combine(m_LocalPath, "View\\AccountSummaryForm\\");

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

                        html = html.Replace("{DATA}", m_Data);
                        html = html.Replace("{SUMMARY}", m_SummaryTemplate);

                        html = html.Replace("{ACCOUNT-NAME}", this.Account.Name);
                        html = html.Replace("{ACCOUNT-TAXOFFICE", this.Account.TaxDepartment);
                        html = html.Replace("{ACCOUNT-TAXID}", this.Account.TaxID);
                        html = html.Replace("{ACCOUNT-ADDRESS}", this.Account.Address);
                        html = html.Replace("{ACCOUNT-CITY}", this.Account.City.Name);
                        html = html.Replace("{ACCOUNT-PROVINCE}", this.Account.Province.Name);
                        html = html.Replace("{ACCOUNT-PHONE}", this.Account.Phone);
                        html = html.Replace("{ACCOUNT-GSM}", this.Account.Gsm);
                        html = html.Replace("{ACCOUNT-EMAIL}", this.Account.Email);

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

            this.Save_Button.Enabled = true;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
