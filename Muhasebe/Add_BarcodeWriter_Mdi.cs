using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class Add_BarcodeWriter_Mdi : Form
    {
        public Add_BarcodeWriter_Mdi()
        {
            InitializeComponent();
        }

        private void Add_BarcodeWriter_Mdi_Load(object sender, EventArgs e)
        {
            this.ComputerName_Box.Text = this.GetFQDN();

            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                var m_Templates = Program.User.WorksAt.BarcodeTemplates.ToList();

                this.DefaultTemplate_Combo.DataSource = m_Templates;
                this.DefaultTemplate_Combo.ValueMember = "ID";
                this.DefaultTemplate_Combo.DisplayMember = "Name";

                var m_ConnectionTypes = m_Context.ConnectionTypes.ToList();

                this.ConnectionType_Combo.DataSource = m_ConnectionTypes;
                this.ConnectionType_Combo.ValueMember = "ID";
                this.ConnectionType_Combo.DisplayMember = "Name";
            }
        }

        private string GetFQDN()
        {
            string hostName = Dns.GetHostName().ToUpper();

            hostName = string.Format("\\\\{0}", hostName);

            return hostName;                    // return the fully qualified name
        }

        private void ComputerName_Box_TextChanged(object sender, EventArgs e)
        {
            if (this.PrinterAddress_Box.Text == string.Empty)
                this.PrinterAddress_Box.Text = this.ComputerName_Box.Text + "\\\\";
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            using(MuhasebeEntities m_Context = new MuhasebeEntities())
            {
                BarcodePrinter m_Printer = new BarcodePrinter();
                m_Printer.Address = this.PrinterAddress_Box.Text;
                m_Printer.BarcodeTemplateID = Convert.ToInt32(this.DefaultTemplate_Combo.SelectedValue);
                m_Printer.ConnectionTypeID = Convert.ToInt32(this.ConnectionType_Combo.SelectedValue);
                m_Printer.OwnerID = Program.User.WorksAtID;
                m_Printer.CreatedAt = DateTime.Now;

                m_Context.BarcodePrinters.Add(m_Printer);
                m_Context.SaveChanges();
            }

            this.Close();
        }
    }
}
