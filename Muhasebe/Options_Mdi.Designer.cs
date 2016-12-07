namespace Muhasebe
{
    partial class Options_Mdi
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
            this.Options_Control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ShowStats_Check = new System.Windows.Forms.CheckBox();
            this.Startup_Check = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Unpriced_Color_Preview_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AlertForUnpriced_Check = new System.Windows.Forms.CheckBox();
            this.AlertForAmount_Check = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LowAmountColor_Preview_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LowAmountTheresold_Num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Sound_Check = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Sound_Combo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Color_Dialog = new System.Windows.Forms.ColorDialog();
            this.Choose_UnpricedColor_Button = new System.Windows.Forms.Button();
            this.Choose_LowAmountColor_Button = new System.Windows.Forms.Button();
            this.Play_Button = new System.Windows.Forms.Button();
            this.Options_Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowAmountTheresold_Num)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options_Control
            // 
            this.Options_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Options_Control.Controls.Add(this.tabPage1);
            this.Options_Control.Controls.Add(this.tabPage2);
            this.Options_Control.Controls.Add(this.tabPage3);
            this.Options_Control.Location = new System.Drawing.Point(12, 12);
            this.Options_Control.Name = "Options_Control";
            this.Options_Control.SelectedIndex = 0;
            this.Options_Control.Size = new System.Drawing.Size(628, 432);
            this.Options_Control.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ShowStats_Check);
            this.tabPage1.Controls.Add(this.Startup_Check);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Genel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ShowStats_Check
            // 
            this.ShowStats_Check.AutoSize = true;
            this.ShowStats_Check.Location = new System.Drawing.Point(6, 29);
            this.ShowStats_Check.Name = "ShowStats_Check";
            this.ShowStats_Check.Size = new System.Drawing.Size(167, 17);
            this.ShowStats_Check.TabIndex = 1;
            this.ShowStats_Check.Text = "Anasayfada istatistikleri göster";
            this.ShowStats_Check.UseVisualStyleBackColor = true;
            this.ShowStats_Check.Visible = false;
            // 
            // Startup_Check
            // 
            this.Startup_Check.AutoSize = true;
            this.Startup_Check.Location = new System.Drawing.Point(6, 6);
            this.Startup_Check.Name = "Startup_Check";
            this.Startup_Check.Size = new System.Drawing.Size(199, 17);
            this.Startup_Check.TabIndex = 0;
            this.Startup_Check.Text = "Sistem başlangıcında otomatik başlat";
            this.Startup_Check.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.AlertForUnpriced_Check);
            this.tabPage2.Controls.Add(this.AlertForAmount_Check);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Envanter";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Choose_UnpricedColor_Button);
            this.groupBox2.Controls.Add(this.Unpriced_Color_Preview_Label);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // Unpriced_Color_Preview_Label
            // 
            this.Unpriced_Color_Preview_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Unpriced_Color_Preview_Label.Location = new System.Drawing.Point(142, 18);
            this.Unpriced_Color_Preview_Label.Name = "Unpriced_Color_Preview_Label";
            this.Unpriced_Color_Preview_Label.Size = new System.Drawing.Size(34, 22);
            this.Unpriced_Color_Preview_Label.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Uyarı Rengi:";
            // 
            // AlertForUnpriced_Check
            // 
            this.AlertForUnpriced_Check.AutoSize = true;
            this.AlertForUnpriced_Check.Location = new System.Drawing.Point(6, 116);
            this.AlertForUnpriced_Check.Name = "AlertForUnpriced_Check";
            this.AlertForUnpriced_Check.Size = new System.Drawing.Size(157, 17);
            this.AlertForUnpriced_Check.TabIndex = 8;
            this.AlertForUnpriced_Check.Text = "Fiyat girilmemiş ürünleri belirt";
            this.AlertForUnpriced_Check.UseVisualStyleBackColor = true;
            this.AlertForUnpriced_Check.CheckedChanged += new System.EventHandler(this.AlertForUnpriced_Check_CheckedChanged);
            // 
            // AlertForAmount_Check
            // 
            this.AlertForAmount_Check.AutoSize = true;
            this.AlertForAmount_Check.BackColor = System.Drawing.Color.Transparent;
            this.AlertForAmount_Check.Location = new System.Drawing.Point(6, 6);
            this.AlertForAmount_Check.Name = "AlertForAmount_Check";
            this.AlertForAmount_Check.Size = new System.Drawing.Size(194, 17);
            this.AlertForAmount_Check.TabIndex = 6;
            this.AlertForAmount_Check.Text = "Az olan ürünleri kırmızı renkte göster";
            this.AlertForAmount_Check.UseVisualStyleBackColor = false;
            this.AlertForAmount_Check.CheckedChanged += new System.EventHandler(this.AlertForAmount_Check_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Choose_LowAmountColor_Button);
            this.groupBox1.Controls.Add(this.LowAmountColor_Preview_Label);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LowAmountTheresold_Num);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // LowAmountColor_Preview_Label
            // 
            this.LowAmountColor_Preview_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LowAmountColor_Preview_Label.Location = new System.Drawing.Point(142, 45);
            this.LowAmountColor_Preview_Label.Name = "LowAmountColor_Preview_Label";
            this.LowAmountColor_Preview_Label.Size = new System.Drawing.Size(34, 23);
            this.LowAmountColor_Preview_Label.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Uyarı Rengi:";
            // 
            // LowAmountTheresold_Num
            // 
            this.LowAmountTheresold_Num.Location = new System.Drawing.Point(142, 19);
            this.LowAmountTheresold_Num.Name = "LowAmountTheresold_Num";
            this.LowAmountTheresold_Num.Size = new System.Drawing.Size(121, 20);
            this.LowAmountTheresold_Num.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Şu Miktar Ve Altındaki:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Sound_Check);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(620, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sesler";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Sound_Check
            // 
            this.Sound_Check.AutoSize = true;
            this.Sound_Check.BackColor = System.Drawing.Color.Transparent;
            this.Sound_Check.Location = new System.Drawing.Point(6, 6);
            this.Sound_Check.Name = "Sound_Check";
            this.Sound_Check.Size = new System.Drawing.Size(193, 17);
            this.Sound_Check.TabIndex = 8;
            this.Sound_Check.Text = "Başarılı barkod okunuşunda ses çal";
            this.Sound_Check.UseVisualStyleBackColor = false;
            this.Sound_Check.CheckedChanged += new System.EventHandler(this.Sound_Check_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Play_Button);
            this.groupBox3.Controls.Add(this.Sound_Combo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 52);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // Sound_Combo
            // 
            this.Sound_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sound_Combo.FormattingEnabled = true;
            this.Sound_Combo.Location = new System.Drawing.Point(60, 18);
            this.Sound_Combo.Name = "Sound_Combo";
            this.Sound_Combo.Size = new System.Drawing.Size(165, 21);
            this.Sound_Combo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ses:";
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Location = new System.Drawing.Point(484, 450);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.Location = new System.Drawing.Point(565, 450);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Choose_UnpricedColor_Button
            // 
            this.Choose_UnpricedColor_Button.Image = global::Muhasebe.Properties.Resources.magnifier;
            this.Choose_UnpricedColor_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Choose_UnpricedColor_Button.Location = new System.Drawing.Point(182, 17);
            this.Choose_UnpricedColor_Button.Name = "Choose_UnpricedColor_Button";
            this.Choose_UnpricedColor_Button.Size = new System.Drawing.Size(81, 23);
            this.Choose_UnpricedColor_Button.TabIndex = 11;
            this.Choose_UnpricedColor_Button.Text = "Seç";
            this.Choose_UnpricedColor_Button.UseVisualStyleBackColor = true;
            this.Choose_UnpricedColor_Button.Click += new System.EventHandler(this.Choose_UnpricedColor_Button_Click);
            // 
            // Choose_LowAmountColor_Button
            // 
            this.Choose_LowAmountColor_Button.Image = global::Muhasebe.Properties.Resources.magnifier;
            this.Choose_LowAmountColor_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Choose_LowAmountColor_Button.Location = new System.Drawing.Point(182, 45);
            this.Choose_LowAmountColor_Button.Name = "Choose_LowAmountColor_Button";
            this.Choose_LowAmountColor_Button.Size = new System.Drawing.Size(81, 23);
            this.Choose_LowAmountColor_Button.TabIndex = 7;
            this.Choose_LowAmountColor_Button.Text = "Seç";
            this.Choose_LowAmountColor_Button.UseVisualStyleBackColor = true;
            this.Choose_LowAmountColor_Button.Click += new System.EventHandler(this.Choose_LowAmountColor_Button_Click);
            // 
            // Play_Button
            // 
            this.Play_Button.Image = global::Muhasebe.Properties.Resources.control_play_blue;
            this.Play_Button.Location = new System.Drawing.Point(231, 16);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(32, 23);
            this.Play_Button.TabIndex = 5;
            this.Play_Button.UseVisualStyleBackColor = true;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // Options_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 483);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Options_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options_Mdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seçenekler";
            this.Load += new System.EventHandler(this.Options_Mdi_Load);
            this.Options_Control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowAmountTheresold_Num)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Options_Control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox Startup_Check;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.CheckBox ShowStats_Check;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox AlertForAmount_Check;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown LowAmountTheresold_Num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Choose_LowAmountColor_Button;
        private System.Windows.Forms.Label LowAmountColor_Preview_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog Color_Dialog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Choose_UnpricedColor_Button;
        private System.Windows.Forms.Label Unpriced_Color_Preview_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox AlertForUnpriced_Check;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox Sound_Check;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox Sound_Combo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Play_Button;
    }
}