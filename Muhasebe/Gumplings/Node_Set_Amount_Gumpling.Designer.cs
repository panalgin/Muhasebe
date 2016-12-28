namespace Muhasebe
{
    partial class Node_Set_Amount_Gumpling
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
            this.label2 = new System.Windows.Forms.Label();
            this.Amount_Num = new System.Windows.Forms.NumericUpDown();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Name_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UnitPrice_Num = new System.Windows.Forms.NumericUpDown();
            this.Description_Label = new System.Windows.Forms.Label();
            this.Description_Box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPrice_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün için yeni miktar giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Miktar:";
            // 
            // Amount_Num
            // 
            this.Amount_Num.Location = new System.Drawing.Point(92, 63);
            this.Amount_Num.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Amount_Num.Name = "Amount_Num";
            this.Amount_Num.Size = new System.Drawing.Size(150, 20);
            this.Amount_Num.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(167, 175);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(71, 175);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 23);
            this.Save_Button.TabIndex = 2;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ürün Adı:";
            // 
            // Name_Label
            // 
            this.Name_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name_Label.Location = new System.Drawing.Point(92, 36);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(150, 20);
            this.Name_Label.TabIndex = 5;
            this.Name_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Birim Fiyat:";
            // 
            // UnitPrice_Num
            // 
            this.UnitPrice_Num.DecimalPlaces = 2;
            this.UnitPrice_Num.Location = new System.Drawing.Point(92, 89);
            this.UnitPrice_Num.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.UnitPrice_Num.Name = "UnitPrice_Num";
            this.UnitPrice_Num.Size = new System.Drawing.Size(150, 20);
            this.UnitPrice_Num.TabIndex = 1;
            // 
            // Description_Label
            // 
            this.Description_Label.AutoSize = true;
            this.Description_Label.Location = new System.Drawing.Point(33, 120);
            this.Description_Label.Name = "Description_Label";
            this.Description_Label.Size = new System.Drawing.Size(53, 13);
            this.Description_Label.TabIndex = 7;
            this.Description_Label.Text = "Açıklama:";
            this.Description_Label.Visible = false;
            // 
            // Description_Box
            // 
            this.Description_Box.Location = new System.Drawing.Point(92, 115);
            this.Description_Box.Multiline = true;
            this.Description_Box.Name = "Description_Box";
            this.Description_Box.Size = new System.Drawing.Size(150, 43);
            this.Description_Box.TabIndex = 8;
            this.Description_Box.Visible = false;
            // 
            // Node_Set_Amount_Gumpling
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(254, 210);
            this.Controls.Add(this.Description_Box);
            this.Controls.Add(this.Description_Label);
            this.Controls.Add(this.UnitPrice_Num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Amount_Num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Node_Set_Amount_Gumpling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Miktarı Düzenle";
            this.Load += new System.EventHandler(this.Node_Set_Amount_Gumpling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Amount_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPrice_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Amount_Num;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown UnitPrice_Num;
        private System.Windows.Forms.Label Description_Label;
        private System.Windows.Forms.TextBox Description_Box;
    }
}