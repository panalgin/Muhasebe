﻿namespace Muhasebe
{
    partial class Add_BarcodeTemplate_Mdi
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
            this.Save_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Path_Box = new System.Windows.Forms.TextBox();
            this.Width_Num = new System.Windows.Forms.NumericUpDown();
            this.Height_Num = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Browse_Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Width_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Location = new System.Drawing.Point(144, 208);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 5;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(225, 208);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Name_Box
            // 
            this.Name_Box.Location = new System.Drawing.Point(109, 12);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(188, 20);
            this.Name_Box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Etiket Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Yükseklik:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Genişlik:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dosya Yolu:";
            // 
            // Path_Box
            // 
            this.Path_Box.Location = new System.Drawing.Point(109, 38);
            this.Path_Box.Name = "Path_Box";
            this.Path_Box.Size = new System.Drawing.Size(188, 20);
            this.Path_Box.TabIndex = 1;
            // 
            // Width_Num
            // 
            this.Width_Num.Location = new System.Drawing.Point(109, 109);
            this.Width_Num.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.Width_Num.Name = "Width_Num";
            this.Width_Num.Size = new System.Drawing.Size(120, 20);
            this.Width_Num.TabIndex = 3;
            // 
            // Height_Num
            // 
            this.Height_Num.Location = new System.Drawing.Point(109, 135);
            this.Height_Num.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.Height_Num.Name = "Height_Num";
            this.Height_Num.Size = new System.Drawing.Size(120, 20);
            this.Height_Num.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(186, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(186, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "mm";
            // 
            // Browse_Button
            // 
            this.Browse_Button.Image = global::Muhasebe.Properties.Resources.magnifier;
            this.Browse_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Browse_Button.Location = new System.Drawing.Point(215, 64);
            this.Browse_Button.Name = "Browse_Button";
            this.Browse_Button.Size = new System.Drawing.Size(82, 23);
            this.Browse_Button.TabIndex = 2;
            this.Browse_Button.Text = "Gözat";
            this.Browse_Button.UseVisualStyleBackColor = true;
            this.Browse_Button.Click += new System.EventHandler(this.Browse_Button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Printer Dosyası|*.prn";
            // 
            // Add_BarcodeTemplate_Mdi
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(312, 243);
            this.Controls.Add(this.Browse_Button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Height_Num);
            this.Controls.Add(this.Width_Num);
            this.Controls.Add(this.Path_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_BarcodeTemplate_Mdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Barkod Tasarımı Ekle";
            this.Load += new System.EventHandler(this.Add_BarcodeTemplate_Mdi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Width_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Path_Box;
        private System.Windows.Forms.NumericUpDown Width_Num;
        private System.Windows.Forms.NumericUpDown Height_Num;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Browse_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}