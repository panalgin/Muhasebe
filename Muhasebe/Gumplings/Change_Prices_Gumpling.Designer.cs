namespace Muhasebe.Gumplings
{
    partial class Change_Prices_Gumpling
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Change_Num = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Distinct_Label = new System.Windows.Forms.Label();
            this.Group_Combo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.New_FinalPrice_Label = new System.Windows.Forms.Label();
            this.New_BasePrice_Label = new System.Windows.Forms.Label();
            this.Ex_FinalPrice_Label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Ex_BasePrice_Label = new System.Windows.Forms.Label();
            this.Sample_Name_Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Change_Num)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(131, 417);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 23);
            this.Save_Button.TabIndex = 4;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(227, 417);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grup:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ürün Kalemi:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "Base";
            this.radioButton1.Text = "Sadece Alış Fiyatına";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(127, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "Final";
            this.radioButton2.Text = "Sadece Satış Fiyatına";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(156, 17);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "Both";
            this.radioButton3.Text = "Hem Alış Hem Satış Fiyatına";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Change_Num);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 133);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fiyat Değişikliği";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(246, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "%";
            // 
            // Change_Num
            // 
            this.Change_Num.Location = new System.Drawing.Point(109, 95);
            this.Change_Num.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.Change_Num.Name = "Change_Num";
            this.Change_Num.Size = new System.Drawing.Size(173, 20);
            this.Change_Num.TabIndex = 12;
            this.Change_Num.ValueChanged += new System.EventHandler(this.Change_Num_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Değişiklik Değeri:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Distinct_Label);
            this.groupBox2.Controls.Add(this.Group_Combo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 83);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etkilenecek Olan:";
            // 
            // Distinct_Label
            // 
            this.Distinct_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Distinct_Label.Location = new System.Drawing.Point(109, 46);
            this.Distinct_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Distinct_Label.Name = "Distinct_Label";
            this.Distinct_Label.Size = new System.Drawing.Size(173, 20);
            this.Distinct_Label.TabIndex = 9;
            this.Distinct_Label.Text = "0 kalem ürün etkilenecek";
            this.Distinct_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Group_Combo
            // 
            this.Group_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Group_Combo.FormattingEnabled = true;
            this.Group_Combo.Location = new System.Drawing.Point(109, 19);
            this.Group_Combo.Name = "Group_Combo";
            this.Group_Combo.Size = new System.Drawing.Size(173, 21);
            this.Group_Combo.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.New_FinalPrice_Label);
            this.groupBox3.Controls.Add(this.New_BasePrice_Label);
            this.groupBox3.Controls.Add(this.Ex_FinalPrice_Label);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Ex_BasePrice_Label);
            this.groupBox3.Controls.Add(this.Sample_Name_Label);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 147);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Örnek";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Yeni Satış Fiyatı:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Yeni Alış Fiyatı:";
            // 
            // New_FinalPrice_Label
            // 
            this.New_FinalPrice_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.New_FinalPrice_Label.Location = new System.Drawing.Point(109, 116);
            this.New_FinalPrice_Label.Margin = new System.Windows.Forms.Padding(3);
            this.New_FinalPrice_Label.Name = "New_FinalPrice_Label";
            this.New_FinalPrice_Label.Size = new System.Drawing.Size(175, 20);
            this.New_FinalPrice_Label.TabIndex = 18;
            this.New_FinalPrice_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // New_BasePrice_Label
            // 
            this.New_BasePrice_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.New_BasePrice_Label.Location = new System.Drawing.Point(109, 64);
            this.New_BasePrice_Label.Margin = new System.Windows.Forms.Padding(3);
            this.New_BasePrice_Label.Name = "New_BasePrice_Label";
            this.New_BasePrice_Label.Size = new System.Drawing.Size(175, 20);
            this.New_BasePrice_Label.TabIndex = 17;
            this.New_BasePrice_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ex_FinalPrice_Label
            // 
            this.Ex_FinalPrice_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Ex_FinalPrice_Label.Location = new System.Drawing.Point(109, 90);
            this.Ex_FinalPrice_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Ex_FinalPrice_Label.Name = "Ex_FinalPrice_Label";
            this.Ex_FinalPrice_Label.Size = new System.Drawing.Size(175, 20);
            this.Ex_FinalPrice_Label.TabIndex = 16;
            this.Ex_FinalPrice_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Eski Satış Fiyatı:";
            // 
            // Ex_BasePrice_Label
            // 
            this.Ex_BasePrice_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Ex_BasePrice_Label.Location = new System.Drawing.Point(109, 38);
            this.Ex_BasePrice_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Ex_BasePrice_Label.Name = "Ex_BasePrice_Label";
            this.Ex_BasePrice_Label.Size = new System.Drawing.Size(175, 20);
            this.Ex_BasePrice_Label.TabIndex = 14;
            this.Ex_BasePrice_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Sample_Name_Label
            // 
            this.Sample_Name_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Sample_Name_Label.Location = new System.Drawing.Point(109, 12);
            this.Sample_Name_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Sample_Name_Label.Name = "Sample_Name_Label";
            this.Sample_Name_Label.Size = new System.Drawing.Size(175, 20);
            this.Sample_Name_Label.TabIndex = 10;
            this.Sample_Name_Label.Text = "Ürün Adı";
            this.Sample_Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Eski Alış Fiyatı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ürün Adı:";
            // 
            // Change_Prices_Gumpling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 452);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Change_Prices_Gumpling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Toplu Fiyat Değişikliği";
            this.Load += new System.EventHandler(this.Change_Prices_Gumpling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Change_Num)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Change_Num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Distinct_Label;
        private System.Windows.Forms.ComboBox Group_Combo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label New_FinalPrice_Label;
        private System.Windows.Forms.Label New_BasePrice_Label;
        private System.Windows.Forms.Label Ex_FinalPrice_Label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Ex_BasePrice_Label;
        private System.Windows.Forms.Label Sample_Name_Label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}