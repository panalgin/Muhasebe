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
            this.Save_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LowAmountTheresold_Num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.AlertForAmount_Check = new System.Windows.Forms.CheckBox();
            this.Options_Control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowAmountTheresold_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // Options_Control
            // 
            this.Options_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Options_Control.Controls.Add(this.tabPage1);
            this.Options_Control.Controls.Add(this.tabPage2);
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
            // tabPage2
            // 
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LowAmountTheresold_Num);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // LowAmountTheresold_Num
            // 
            this.LowAmountTheresold_Num.Location = new System.Drawing.Point(142, 19);
            this.LowAmountTheresold_Num.Name = "LowAmountTheresold_Num";
            this.LowAmountTheresold_Num.Size = new System.Drawing.Size(92, 20);
            this.LowAmountTheresold_Num.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Şu Miktarın Ve Altındaki:";
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowAmountTheresold_Num)).EndInit();
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
    }
}