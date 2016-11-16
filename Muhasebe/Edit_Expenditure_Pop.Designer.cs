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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Account_Box = new Muhasebe.Custom.SearchBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Expenditure_Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ExpenditureDesc_Text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Responsible_Combo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CreatedAt_Picker = new System.Windows.Forms.DateTimePicker();
            this.Expenditure_Type_Combo = new System.Windows.Forms.ComboBox();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expenditure_Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Account_Box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Expenditure_Amount_Num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ExpenditureDesc_Text);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Responsible_Combo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CreatedAt_Picker);
            this.groupBox1.Controls.Add(this.Expenditure_Type_Combo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 240);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gider Düzenle";
            // 
            // Account_Box
            // 
            this.Account_Box.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Account_Box.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Account_Box.FillType = Muhasebe.Custom.SearchBox.Fillable.Account;
            this.Account_Box.FormattingEnabled = true;
            this.Account_Box.Location = new System.Drawing.Point(105, 98);
            this.Account_Box.Name = "Account_Box";
            this.Account_Box.Size = new System.Drawing.Size(193, 21);
            this.Account_Box.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "İlgili Hesap:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Harcama Tarihi :";
            // 
            // Expenditure_Amount_Num
            // 
            this.Expenditure_Amount_Num.DecimalPlaces = 2;
            this.Expenditure_Amount_Num.Location = new System.Drawing.Point(105, 72);
            this.Expenditure_Amount_Num.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Expenditure_Amount_Num.Name = "Expenditure_Amount_Num";
            this.Expenditure_Amount_Num.Size = new System.Drawing.Size(193, 20);
            this.Expenditure_Amount_Num.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Gider Türü :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Harcama Tutarı :";
            // 
            // ExpenditureDesc_Text
            // 
            this.ExpenditureDesc_Text.Location = new System.Drawing.Point(105, 152);
            this.ExpenditureDesc_Text.Multiline = true;
            this.ExpenditureDesc_Text.Name = "ExpenditureDesc_Text";
            this.ExpenditureDesc_Text.Size = new System.Drawing.Size(193, 79);
            this.ExpenditureDesc_Text.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Sorumlu:";
            // 
            // Responsible_Combo
            // 
            this.Responsible_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Responsible_Combo.FormattingEnabled = true;
            this.Responsible_Combo.Location = new System.Drawing.Point(105, 125);
            this.Responsible_Combo.Name = "Responsible_Combo";
            this.Responsible_Combo.Size = new System.Drawing.Size(193, 21);
            this.Responsible_Combo.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Açıklama:";
            // 
            // CreatedAt_Picker
            // 
            this.CreatedAt_Picker.Location = new System.Drawing.Point(105, 19);
            this.CreatedAt_Picker.Name = "CreatedAt_Picker";
            this.CreatedAt_Picker.Size = new System.Drawing.Size(193, 20);
            this.CreatedAt_Picker.TabIndex = 0;
            // 
            // Expenditure_Type_Combo
            // 
            this.Expenditure_Type_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Expenditure_Type_Combo.FormattingEnabled = true;
            this.Expenditure_Type_Combo.Location = new System.Drawing.Point(105, 45);
            this.Expenditure_Type_Combo.Name = "Expenditure_Type_Combo";
            this.Expenditure_Type_Combo.Size = new System.Drawing.Size(193, 21);
            this.Expenditure_Type_Combo.TabIndex = 1;
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Btn.Location = new System.Drawing.Point(221, 281);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(96, 23);
            this.Cancel_Btn.TabIndex = 5;
            this.Cancel_Btn.Text = "İptal";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // Save_Btn
            // 
            this.Save_Btn.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Btn.Location = new System.Drawing.Point(119, 281);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(96, 23);
            this.Save_Btn.TabIndex = 4;
            this.Save_Btn.Text = "Kaydet";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Edit_Expenditure_Pop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 314);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expenditure_Amount_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Custom.SearchBox Account_Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Expenditure_Amount_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ExpenditureDesc_Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Responsible_Combo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker CreatedAt_Picker;
        private System.Windows.Forms.ComboBox Expenditure_Type_Combo;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Button Save_Btn;
    }
}