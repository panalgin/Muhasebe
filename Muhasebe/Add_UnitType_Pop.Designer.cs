namespace Muhasebe
{
    partial class Add_UnitType_Pop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_UnitType_Pop));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DecimalPlaces_Num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Abbreviation_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DecimalPlaces_Num);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Abbreviation_Box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Name_Box);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ölçü Birimi";
            // 
            // DecimalPlaces_Num
            // 
            this.Error_Provider.SetIconPadding(this.DecimalPlaces_Num, -35);
            this.DecimalPlaces_Num.Location = new System.Drawing.Point(151, 71);
            this.DecimalPlaces_Num.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.DecimalPlaces_Num.Name = "DecimalPlaces_Num";
            this.DecimalPlaces_Num.Size = new System.Drawing.Size(139, 20);
            this.DecimalPlaces_Num.TabIndex = 2;
            this.Tooltip.SetToolTip(this.DecimalPlaces_Num, "Virgülden sonra kaç karakter gösterileceğini buradan ayarlayabilirsiniz.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ondalık Küsürat:";
            // 
            // Abbreviation_Box
            // 
            this.Error_Provider.SetIconPadding(this.Abbreviation_Box, -20);
            this.Abbreviation_Box.Location = new System.Drawing.Point(151, 45);
            this.Abbreviation_Box.Name = "Abbreviation_Box";
            this.Abbreviation_Box.Size = new System.Drawing.Size(139, 20);
            this.Abbreviation_Box.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kısaltma:";
            // 
            // Name_Box
            // 
            this.Error_Provider.SetIconPadding(this.Name_Box, -20);
            this.Name_Box.Location = new System.Drawing.Point(151, 19);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(139, 20);
            this.Name_Box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // Tooltip
            // 
            this.Tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tooltip.ToolTipTitle = "Bilgi";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::Muhasebe.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(209, 151);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(99, 23);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::Muhasebe.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(104, 151);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(99, 23);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Error_Provider
            // 
            this.Error_Provider.ContainerControl = this;
            this.Error_Provider.Icon = ((System.Drawing.Icon)(resources.GetObject("Error_Provider.Icon")));
            // 
            // Add_UnitType_Pop
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(320, 186);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_UnitType_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Ölçü Birimi Ekle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecimalPlaces_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Abbreviation_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DecimalPlaces_Num;
        private System.Windows.Forms.ToolTip Tooltip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.ErrorProvider Error_Provider;
    }
}