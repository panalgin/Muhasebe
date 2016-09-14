namespace Muhasebe
{
    partial class Add_Device_Pop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RS232_Group = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Baud_Rate_Combo = new System.Windows.Forms.ComboBox();
            this.Com_Port_Combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.USB_Group = new System.Windows.Forms.GroupBox();
            this.ProductID_Box = new System.Windows.Forms.TextBox();
            this.VendorID_Box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NETWORK_Group = new System.Windows.Forms.GroupBox();
            this.Alias_Box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Connection_Type_Combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Device_Type_Combo = new System.Windows.Forms.ComboBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.RS232_Group.SuspendLayout();
            this.USB_Group.SuspendLayout();
            this.NETWORK_Group.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.RS232_Group);
            this.flowLayoutPanel1.Controls.Add(this.USB_Group);
            this.flowLayoutPanel1.Controls.Add(this.NETWORK_Group);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 92);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(298, 258);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // RS232_Group
            // 
            this.RS232_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RS232_Group.Controls.Add(this.label3);
            this.RS232_Group.Controls.Add(this.Baud_Rate_Combo);
            this.RS232_Group.Controls.Add(this.Com_Port_Combo);
            this.RS232_Group.Controls.Add(this.label2);
            this.RS232_Group.Location = new System.Drawing.Point(3, 3);
            this.RS232_Group.Name = "RS232_Group";
            this.RS232_Group.Size = new System.Drawing.Size(287, 81);
            this.RS232_Group.TabIndex = 0;
            this.RS232_Group.TabStop = false;
            this.RS232_Group.Text = "Bağlantı Bilgileri - RS232";
            this.RS232_Group.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Baud Rate:";
            // 
            // Baud_Rate_Combo
            // 
            this.Baud_Rate_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Baud_Rate_Combo.FormattingEnabled = true;
            this.Baud_Rate_Combo.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.Baud_Rate_Combo.Location = new System.Drawing.Point(132, 46);
            this.Baud_Rate_Combo.Name = "Baud_Rate_Combo";
            this.Baud_Rate_Combo.Size = new System.Drawing.Size(149, 21);
            this.Baud_Rate_Combo.TabIndex = 1;
            // 
            // Com_Port_Combo
            // 
            this.Com_Port_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Com_Port_Combo.FormattingEnabled = true;
            this.Com_Port_Combo.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24"});
            this.Com_Port_Combo.Location = new System.Drawing.Point(132, 19);
            this.Com_Port_Combo.Name = "Com_Port_Combo";
            this.Com_Port_Combo.Size = new System.Drawing.Size(149, 21);
            this.Com_Port_Combo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // USB_Group
            // 
            this.USB_Group.Controls.Add(this.ProductID_Box);
            this.USB_Group.Controls.Add(this.VendorID_Box);
            this.USB_Group.Controls.Add(this.label6);
            this.USB_Group.Controls.Add(this.label5);
            this.USB_Group.Location = new System.Drawing.Point(3, 90);
            this.USB_Group.Name = "USB_Group";
            this.USB_Group.Size = new System.Drawing.Size(287, 74);
            this.USB_Group.TabIndex = 1;
            this.USB_Group.TabStop = false;
            this.USB_Group.Text = "Bağlantı Bilgileri - USB";
            this.USB_Group.Visible = false;
            // 
            // ProductID_Box
            // 
            this.ProductID_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductID_Box.Location = new System.Drawing.Point(132, 45);
            this.ProductID_Box.Name = "ProductID_Box";
            this.ProductID_Box.Size = new System.Drawing.Size(149, 20);
            this.ProductID_Box.TabIndex = 1;
            // 
            // VendorID_Box
            // 
            this.VendorID_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VendorID_Box.Location = new System.Drawing.Point(132, 19);
            this.VendorID_Box.Name = "VendorID_Box";
            this.VendorID_Box.Size = new System.Drawing.Size(149, 20);
            this.VendorID_Box.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ürün Kimliği:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Üretici Kimliği:";
            // 
            // NETWORK_Group
            // 
            this.NETWORK_Group.Controls.Add(this.Alias_Box);
            this.NETWORK_Group.Controls.Add(this.label7);
            this.NETWORK_Group.Location = new System.Drawing.Point(3, 170);
            this.NETWORK_Group.Name = "NETWORK_Group";
            this.NETWORK_Group.Size = new System.Drawing.Size(287, 55);
            this.NETWORK_Group.TabIndex = 2;
            this.NETWORK_Group.TabStop = false;
            this.NETWORK_Group.Text = "Bağlantı Bilgileri - AĞ";
            this.NETWORK_Group.Visible = false;
            // 
            // Alias_Box
            // 
            this.Alias_Box.Location = new System.Drawing.Point(132, 19);
            this.Alias_Box.Name = "Alias_Box";
            this.Alias_Box.Size = new System.Drawing.Size(149, 20);
            this.Alias_Box.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ağ Adı:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Connection_Type_Combo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Device_Type_Combo);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 74);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aygıt Bilgileri";
            // 
            // Connection_Type_Combo
            // 
            this.Connection_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Connection_Type_Combo.FormattingEnabled = true;
            this.Connection_Type_Combo.Location = new System.Drawing.Point(132, 39);
            this.Connection_Type_Combo.Name = "Connection_Type_Combo";
            this.Connection_Type_Combo.Size = new System.Drawing.Size(149, 21);
            this.Connection_Type_Combo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bağlantı Türü:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aygıt Türü:";
            // 
            // Device_Type_Combo
            // 
            this.Device_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Device_Type_Combo.FormattingEnabled = true;
            this.Device_Type_Combo.Location = new System.Drawing.Point(132, 14);
            this.Device_Type_Combo.Name = "Device_Type_Combo";
            this.Device_Type_Combo.Size = new System.Drawing.Size(149, 21);
            this.Device_Type_Combo.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(198, 356);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(99, 23);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(93, 356);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(99, 23);
            this.Save_Button.TabIndex = 6;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Add_Device_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 391);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Save_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Add_Device_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Aygıt Ekle";
            this.Load += new System.EventHandler(this.Add_Device_Pop_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.RS232_Group.ResumeLayout(false);
            this.RS232_Group.PerformLayout();
            this.USB_Group.ResumeLayout(false);
            this.USB_Group.PerformLayout();
            this.NETWORK_Group.ResumeLayout(false);
            this.NETWORK_Group.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox RS232_Group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Baud_Rate_Combo;
        private System.Windows.Forms.ComboBox Com_Port_Combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox USB_Group;
        private System.Windows.Forms.TextBox ProductID_Box;
        private System.Windows.Forms.TextBox VendorID_Box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox NETWORK_Group;
        private System.Windows.Forms.TextBox Alias_Box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox Connection_Type_Combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Device_Type_Combo;
        private System.Windows.Forms.Button Save_Button;
    }
}