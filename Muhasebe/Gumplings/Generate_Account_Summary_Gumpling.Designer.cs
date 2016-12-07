namespace Muhasebe.Gumplings
{
    partial class Generate_Account_Summary_Gumpling
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
            this.Account_Box = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Last_Month_Radio = new System.Windows.Forms.RadioButton();
            this.Last_6Months_Radio = new System.Windows.Forms.RadioButton();
            this.Last_2Years_Radio = new System.Windows.Forms.RadioButton();
            this.Specific_Radio = new System.Windows.Forms.RadioButton();
            this.BeginsAt_Picker = new System.Windows.Forms.DateTimePicker();
            this.EndsAt_Picker = new System.Windows.Forms.DateTimePicker();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hesap Adı:";
            // 
            // Account_Box
            // 
            this.Account_Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Account_Box.Location = new System.Drawing.Point(91, 9);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(206, 21);
            this.Account_Box.TabIndex = 1;
            this.Account_Box.Text = "label2";
            this.Account_Box.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tarih";
            // 
            // Last_Month_Radio
            // 
            this.Last_Month_Radio.AutoSize = true;
            this.Last_Month_Radio.Checked = true;
            this.Last_Month_Radio.Location = new System.Drawing.Point(91, 41);
            this.Last_Month_Radio.Name = "Last_Month_Radio";
            this.Last_Month_Radio.Size = new System.Drawing.Size(68, 17);
            this.Last_Month_Radio.TabIndex = 0;
            this.Last_Month_Radio.TabStop = true;
            this.Last_Month_Radio.Text = "Son 1 Ay";
            this.Last_Month_Radio.UseVisualStyleBackColor = true;
            // 
            // Last_6Months_Radio
            // 
            this.Last_6Months_Radio.AutoSize = true;
            this.Last_6Months_Radio.Location = new System.Drawing.Point(91, 64);
            this.Last_6Months_Radio.Name = "Last_6Months_Radio";
            this.Last_6Months_Radio.Size = new System.Drawing.Size(68, 17);
            this.Last_6Months_Radio.TabIndex = 1;
            this.Last_6Months_Radio.Text = "Son 6 Ay";
            this.Last_6Months_Radio.UseVisualStyleBackColor = true;
            // 
            // Last_2Years_Radio
            // 
            this.Last_2Years_Radio.AutoSize = true;
            this.Last_2Years_Radio.Location = new System.Drawing.Point(91, 88);
            this.Last_2Years_Radio.Name = "Last_2Years_Radio";
            this.Last_2Years_Radio.Size = new System.Drawing.Size(67, 17);
            this.Last_2Years_Radio.TabIndex = 2;
            this.Last_2Years_Radio.Text = "Son 2 Yıl";
            this.Last_2Years_Radio.UseVisualStyleBackColor = true;
            // 
            // Specific_Radio
            // 
            this.Specific_Radio.AutoSize = true;
            this.Specific_Radio.Location = new System.Drawing.Point(91, 112);
            this.Specific_Radio.Name = "Specific_Radio";
            this.Specific_Radio.Size = new System.Drawing.Size(107, 17);
            this.Specific_Radio.TabIndex = 3;
            this.Specific_Radio.Text = "Belirli Tarih Aralığı";
            this.Specific_Radio.UseVisualStyleBackColor = true;
            // 
            // BeginsAt_Picker
            // 
            this.BeginsAt_Picker.Location = new System.Drawing.Point(209, 112);
            this.BeginsAt_Picker.Name = "BeginsAt_Picker";
            this.BeginsAt_Picker.Size = new System.Drawing.Size(93, 20);
            this.BeginsAt_Picker.TabIndex = 4;
            // 
            // EndsAt_Picker
            // 
            this.EndsAt_Picker.Location = new System.Drawing.Point(209, 138);
            this.EndsAt_Picker.Name = "EndsAt_Picker";
            this.EndsAt_Picker.Size = new System.Drawing.Size(93, 20);
            this.EndsAt_Picker.TabIndex = 5;
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(131, 192);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 23);
            this.Save_Button.TabIndex = 6;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(227, 192);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Generate_Account_Summary_Gumpling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 227);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.EndsAt_Picker);
            this.Controls.Add(this.BeginsAt_Picker);
            this.Controls.Add(this.Specific_Radio);
            this.Controls.Add(this.Last_2Years_Radio);
            this.Controls.Add(this.Last_6Months_Radio);
            this.Controls.Add(this.Last_Month_Radio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Account_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Generate_Account_Summary_Gumpling";
            this.Text = "Hesap Özeti Oluştur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Account_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Last_Month_Radio;
        private System.Windows.Forms.RadioButton Last_6Months_Radio;
        private System.Windows.Forms.RadioButton Last_2Years_Radio;
        private System.Windows.Forms.RadioButton Specific_Radio;
        private System.Windows.Forms.DateTimePicker BeginsAt_Picker;
        private System.Windows.Forms.DateTimePicker EndsAt_Picker;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
    }
}