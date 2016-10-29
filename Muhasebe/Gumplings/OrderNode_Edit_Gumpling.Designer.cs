namespace Muhasebe.Gumplings
{
    partial class OrderNode_Edit_Gumpling
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
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Description_Box = new System.Windows.Forms.TextBox();
            this.Unit_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(110, 132);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(87, 23);
            this.Save_Button.TabIndex = 2;
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
            this.Cancel_Button.Location = new System.Drawing.Point(203, 132);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "İstediğimiz Miktar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Açıklama:";
            // 
            // Amount_Num
            // 
            this.Amount_Num.DecimalPlaces = 4;
            this.Amount_Num.Location = new System.Drawing.Point(112, 12);
            this.Amount_Num.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Amount_Num.Name = "Amount_Num";
            this.Amount_Num.Size = new System.Drawing.Size(166, 20);
            this.Amount_Num.TabIndex = 0;
            // 
            // Description_Box
            // 
            this.Description_Box.Location = new System.Drawing.Point(112, 38);
            this.Description_Box.Multiline = true;
            this.Description_Box.Name = "Description_Box";
            this.Description_Box.Size = new System.Drawing.Size(166, 69);
            this.Description_Box.TabIndex = 1;
            // 
            // Unit_Label
            // 
            this.Unit_Label.BackColor = System.Drawing.SystemColors.Window;
            this.Unit_Label.Location = new System.Drawing.Point(195, 15);
            this.Unit_Label.Name = "Unit_Label";
            this.Unit_Label.Size = new System.Drawing.Size(63, 15);
            this.Unit_Label.TabIndex = 6;
            this.Unit_Label.Text = "birim";
            this.Unit_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrderNode_Edit_Gumpling
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(290, 167);
            this.Controls.Add(this.Unit_Label);
            this.Controls.Add(this.Description_Box);
            this.Controls.Add(this.Amount_Num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderNode_Edit_Gumpling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş Nesnesini Düzenle";
            this.Load += new System.EventHandler(this.OrderNode_Edit_Gumpling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.TextBox Description_Box;
        private System.Windows.Forms.Label Unit_Label;
    }
}