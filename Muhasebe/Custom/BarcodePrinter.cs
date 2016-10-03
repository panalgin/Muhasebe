using Muhasebe.Custom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public class BarcodePrinter : Device
    {
        public void Print(string text, string barcode)
        {
            string m_Data = "";

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                BarcodeTemplate m_Template = this.Company.BarcodeTemplates.Where(q => q.IsDefault == true).FirstOrDefault();

                if (m_Template == null)
                {
                    MessageBox.Show("Varsayılan barkod tasarımı belirli değil, lütfen ayarlayıp deneyiniz.", "Hata", MessageBoxButtons.OK);
                    return;
                }

                using (StreamReader m_Reader = new StreamReader(m_Template.Path, Encoding.GetEncoding(1252)))
                {
                    m_Data = m_Reader.ReadToEnd();
                }

                text = this.RemoveDiacritics(text);

                if (text.Length < 25)
                {
                    m_Data = m_Data.Replace("{LINE-1}", text);
                    m_Data = m_Data.Replace("{LINE-2}", "");
                }
                else
                {
                    m_Data = m_Data.Replace("{LINE-1}", text.Substring(0, 25));

                    int left = (text.Length - 26) > 25 ? 25 : (text.Length - 26);
                    m_Data = m_Data.Replace("{LINE-2}", text.Substring(25, left));
                }

                m_Data = m_Data.Replace("{BARCODE}", barcode);

                string m_TempPath = Path.Combine(Program.BasePath, "Temp.prn");

                using (StreamWriter m_Writer = new StreamWriter(m_TempPath, false, Encoding.GetEncoding(1252)))
                { // ANSI Encoding
                    m_Writer.Write(m_Data);
                }

                if (this.ConnectionType.Name == "NETWORK")
                {
                    NetworkConnectionParameters m_Parameters = this.GetConnectionParameters() as NetworkConnectionParameters;
                    string m_Command = string.Format("COPY /B \"{0}\" \"{1}\"", m_TempPath, m_Parameters.Alias);
                    string m_Output = this.ExecuteCommand(m_Command);

                    //MessageBox.Show(m_Command);
                    //MessageBox.Show(m_Output);
                }
                else
                {
                    MessageBox.Show("Bu yazıcının bağlantı türü desteklenmiyor.", "Hata", MessageBoxButtons.OK);
                }
            }
        }

        private string ExecuteCommand(string command)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();

                string output = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(output))
                    output = proc.StandardError.ReadToEnd();

                return output;
            }

        }

        /// <summary>
        /// Replaces non unicode chars like ş, ı, ç, ğ
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string RemoveDiacritics(string text)
        {
            Encoding srcEncoding = Encoding.UTF8;
            Encoding destEncoding = Encoding.GetEncoding(1252); // Latin alphabet

            text = destEncoding.GetString(Encoding.Convert(srcEncoding, destEncoding, srcEncoding.GetBytes(text)));

            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                if (!CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]).Equals(UnicodeCategory.NonSpacingMark))
                {
                    result.Append(normalizedString[i]);
                }
            }

            return result.ToString();
        }
    }
}
