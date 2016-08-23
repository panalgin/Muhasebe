using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Item
    {
        public string GetFormattedAmount(decimal amount)
        {
            string m_Amount = "";

            try
            {
                if (this.UnitType.DecimalPlaces == 0)
                {
                    if (amount == 0.0000M)
                        m_Amount = string.Format("0 {0}", this.UnitType.Abbreviation);
                    else
                        m_Amount = string.Format("{0} {1}", amount.ToString("#"), this.UnitType.Abbreviation);
                }

                else
                {
                    string m_Format = "#." + "".PadRight(this.UnitType.DecimalPlaces, '#');
                    m_Amount = amount.ToString(m_Format) + " " + this.UnitType.Abbreviation;
                }
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }

            return m_Amount;
        }

        public string GetFormattedAmount()
        {
            return this.GetFormattedAmount(this.Amount);
        }

        public void SynchronizeImage(Image image)
        {
            ThreadStart m_Start = new ThreadStart(delegate() { DoSynchronizeImage(image); });
            Thread m_Thread = new Thread(m_Start);
            m_Thread.IsBackground = true;
            m_Thread.Start();
        }

        private void DoSynchronizeImage(Image image)
        {
            string m_SavePath = Path.Combine(Program.BasePath, "Images");
            string m_FileName = Path.GetRandomFileName().Replace(".", "") + ".png";
            if (Directory.Exists(m_SavePath) == false)
                Directory.CreateDirectory(m_SavePath);

            image.Save(Path.Combine(m_SavePath, m_FileName), ImageFormat.Png);

            MuhasebeEntities m_Context = new MuhasebeEntities();
            Item m_Item = m_Context.Items.Where(q => q.ID == this.ID).FirstOrDefault();

            if (m_Item != null)
            {
                m_Item.LocalImagePath = string.Format(Path.Combine(m_SavePath, m_FileName));

                if (m_Item.Product.PublicImagePath == null || m_Item.Product.PublicImagePath == string.Empty)
                    m_Item.Product.PublicImagePath = string.Format("img/products/{0}", m_FileName);


                FtpWebRequest m_Request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://www.daflan.com/public_html/muhasebe/img/products/{0}", m_FileName));
                m_Request.KeepAlive = false;
                m_Request.Credentials = new NetworkCredential("daflan", "thisis2ndtime?");
                m_Request.Method = WebRequestMethods.Ftp.UploadFile;

                Stream m_FileStream = new FileStream(Path.Combine(m_SavePath, m_FileName), FileMode.Open);
                BinaryReader m_Reader = new BinaryReader(m_FileStream, Encoding.UTF8);
                byte[] m_Data = m_Reader.ReadBytes(Convert.ToInt32(m_FileStream.Length));

                m_Reader.Close();

                
                Stream m_RequestStream = m_Request.GetRequestStream();

                m_Request.ContentLength = m_Data.Length;

                m_RequestStream.Write(m_Data, 0, m_Data.Length);
                m_RequestStream.Flush();
                m_RequestStream.Close();


                try
                {
                    FtpWebResponse m_Response = m_Request.GetResponse() as FtpWebResponse;
                }
                catch (Exception ex)
                {
                    Logger.Enqueue(ex);
                }

                try
                {
                    m_Context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    Logger.Enqueue(ex);
                }
            }
        }

        internal void Append(InvoiceNode m_Node)
        {
            throw new NotImplementedException();
        }
    }
}
