namespace Muhasebe
{
    partial class Add_BarcodeWriter_Mdi
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
            this.label1 = new System.Windows.Forms.Label();
            this.ComputerName_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrinterAddress_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectionType_Combo = new System.Windows.Forms.ComboBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DefaultTemplate_Combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bilgisayar Adı:";
            // 
            // ComputerName_Box
            // 
            this.ComputerName_Box.Location = new System.Drawing.Point(106, 12);
            this.ComputerName_Box.Name = "ComputerName_Box";
            this.ComputerName_Box.Size = new System.Drawing.Size(188, 20);
            this.ComputerName_Box.TabIndex = 0;
            this.ComputerName_Box.TextChanged += new System.EventHandler(this.ComputerName_Box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yazıcı Adresi [Ağ]:";
            // 
            // PrinterAddress_Box
            // 
            this.PrinterAddress_Box.Location = new System.Drawing.Point(106, 38);
            this.PrinterAddress_Box.Name = "PrinterAddress_Box";
            this.PrinterAddress_Box.Size = new System.Drawing.Size(188, 20);
            this.PrinterAddress_Box.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bağlantı Türü:";
            // 
            // ConnectionType_Combo
            // 
            this.ConnectionType_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectionType_Combo.FormattingEnabled = true;
            this.ConnectionType_Combo.Location = new System.Drawing.Point(173, 64);
            this.ConnectionType_Combo.Name = "ConnectionType_Combo";
            this.ConnectionType_Combo.Size = new System.Drawing.Size(121, 21);
            this.ConnectionType_Combo.TabIndex = 2;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(219, 197);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Location = new System.Drawing.Point(138, 197);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 4;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Varsayılan Etiket:";
            // 
            // DefaultTemplate_Combo
            // 
            this.DefaultTemplate_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DefaultTemplate_Combo.FormattingEnabled = true;
            this.DefaultTemplate_Combo.Location = new System.Drawing.Point(106, 91);
            this.DefaultTemplate_Combo.Name = "DefaultTemplate_Combo";
            this.DefaultTemplate_Combo.Size = new System.Drawing.Size(188, 21);
            this.DefaultTemplate_Combo.TabIndex = 3;
            // 
            // Add_BarcodeWriter_Mdi
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(306, 232);
            this.Controls.Add(this.DefaultTemplate_Combo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.ConnectionType_Combo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrinterAddress_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComputerName_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_BarcodeWriter_Mdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barkod Yazıcı Ekle";
            this.Load += new System.EventHandler(this.Add_BarcodeWriter_Mdi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ComputerName_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PrinterAddress_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ConnectionType_Combo;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DefaultTemplate_Combo;
    }
}