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
    public partial class Add_Device_Pop : Form
    {
        public Add_Device_Pop()
        {
            InitializeComponent();
        }

        private void Add_Device_Pop_Load(object sender, EventArgs e)
        {
            using (MuhasebeEntities m_Context = new MuhasebeEntities())
            {

                var m_DeviceTypes = m_Context.DeviceTypes.ToList();

                this.Device_Type_Combo.DataSource = m_DeviceTypes;
                this.Device_Type_Combo.DisplayMember = "Name";
                this.Device_Type_Combo.ValueMember = "ID";


                var m_ConnectionTypes = m_Context.ConnectionTypes.ToList();
                this.Connection_Type_Combo.DataSource = m_ConnectionTypes;
                this.Connection_Type_Combo.DisplayMember = "Name";
                this.Connection_Type_Combo.ValueMember = "ID";
            }

            this.Device_Type_Combo.SelectedIndexChanged += Device_Type_Combo_SelectedIndexChanged;
            this.Connection_Type_Combo.SelectedIndexChanged += Connection_Type_Combo_SelectedIndexChanged;

            this.Connection_Type_Combo.Invalidate();
        }

        private void Device_Type_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateView();
        }


        private void Connection_Type_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateView();
        }

        private void PopulateView()
        {
            switch(this.Connection_Type_Combo.SelectedText)
            {
                case "USB":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = true;

                        break;
                    }

                case "RS-232":
                    {
                        this.RS232_Group.Visible = true;
                        this.NETWORK_Group.Visible = false;
                        this.USB_Group.Visible = false;
                        break;
                    }

                case "NETWORK":
                    {
                        this.RS232_Group.Visible = false;
                        this.NETWORK_Group.Visible = true;
                        this.USB_Group.Visible = false;
                        break;
                    }
            }
        }

    }
}
