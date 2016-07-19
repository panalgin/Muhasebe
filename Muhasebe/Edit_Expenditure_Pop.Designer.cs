namespace Muhasebe
{
    partial class Edit_Expenditure_Pop
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
            this.Expenditure_Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.ExpenditureDesc_Text = new System.Windows.Forms.TextBox();
            this.Responsible_Combo = new System.Windows.Forms.ComboBox();
            this.PaymentType_Combo = new System.Windows.Forms.ComboBox();
            this.Expenditure_Type_Combo = new System.Windows.Forms.ComboBox();
            this.CreatedAt_Picker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Expenditure_Amount_Num)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Expenditure_Amount_Num
            // 
            this.Expenditure_Amount_Num.DecimalPlaces = 2;
            this.Expenditure_Amount_Num.Location = new System.Drawing.Point(185, 72);
            this.Expenditure_Amount_Num.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Expenditure_Amount_Num.Name = "Expenditure_Amount_Num";
            this.Expenditure_Amount_Num.Size = new System.Drawing.Size(192, 20);
            this.Expenditure_Amount_Num.TabIndex = 30;
            // 
            // ExpenditureDesc_Text
            // 
            this.ExpenditureDesc_Text.Location = new System.Drawing.Point(185, 152);
            this.ExpenditureDesc_Text.Multiline = true;
            this.ExpenditureDesc_Text.Name = "ExpenditureDesc_Text";
            this.ExpenditureDesc_Text.Size = new System.Drawing.Size(192, 79);
            this.ExpenditureDesc_Text.TabIndex = 27;
            // 
            // Responsible_Combo
            // 
            this.Responsible_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Responsible_Combo.FormattingEnabled = true;
            this.Responsible_Combo.Location = new System.Drawing.Point(185, 125);
            this.Responsible_Combo.Name = "Responsible_Combo";
            this.Responsible_Combo.Size = new System.Drawing.Size(192, 21);
            this.Responsible_Combo.TabIndex = 26;
            // 
            // PaymentType_Combo
            // 
            this.PaymentType_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaymentType_Combo.FormattingEnabled = true;
            this.PaymentType_Combo.Location = new System.Drawing.Point(185, 98);
            this.PaymentType_Combo.Name = "PaymentType_Combo";
            this.PaymentType_Combo.Size = new System.Drawing.Size(192, 21);
            this.PaymentType_Combo.TabIndex = 25;
            // 
            // Expenditure_Type_Combo
            // 
            this.Expenditure_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Expenditure_Type_Combo.FormattingEnabled = true;
            this.Expenditure_Type_Combo.Location = new System.Drawing.Point(185, 45);
            this.Expenditure_Type_Combo.Name = "Expenditure_Type_Combo";
            this.Expenditure_Type_Combo.Size = new System.Drawing.Size(192, 21);
            this.Expenditure_Type_Combo.TabIndex = 24;
            // 
            // CreatedAt_Picker
            // 
            this.CreatedAt_Picker.Location = new System.Drawing.Point(185, 19);
            this.CreatedAt_Picker.Name = "CreatedAt_Picker";
            this.CreatedAt_Picker.Size = new System.Drawing.Size(192, 20);
            this.CreatedAt_Picker.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Harcama Açıklaması :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Harcama Sorumlusu :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ödeme Yöntemi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Harcama Tutarı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Gider Türü :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Harcama Tarihi :";
            // 
            // Save_Btn
            // 
            this.Save_Btn.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Btn.Location = new System.Drawing.Point(197, 265);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(96, 23);
            this.Save_Btn.TabIndex = 29;
            this.Save_Btn.Text = "Kaydet";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Btn.Location = new System.Drawing.Point(299, 265);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(96, 23);
            this.Cancel_Btn.TabIndex = 28;
            this.Cancel_Btn.Text = "İptal";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Expenditure_Amount_Num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ExpenditureDesc_Text);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Responsible_Combo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PaymentType_Combo);
            this.groupBox1.Controls.Add(this.CreatedAt_Picker);
            this.groupBox1.Controls.Add(this.Expenditure_Type_Combo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 240);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gider Düzenle";
            // 
            // Edit_Expenditure_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Save_Btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Expenditure_Pop";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gider Düzenleme";
            this.Load += new System.EventHandler(this.Edit_Expenditure_Pop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Expenditure_Amount_Num)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Expenditure_Amount_Num;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.TextBox ExpenditureDesc_Text;
        private System.Windows.Forms.ComboBox Responsible_Combo;
        private System.Windows.Forms.ComboBox PaymentType_Combo;
        private System.Windows.Forms.ComboBox Expenditure_Type_Combo;
        private System.Windows.Forms.DateTimePicker CreatedAt_Picker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}