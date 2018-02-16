namespace JoyKeyMapper
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.TitleLable = new System.Windows.Forms.Label();
            this.VersionLabel_static = new System.Windows.Forms.Label();
            this.VersionLabel_dynamic = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.LicenseBox = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.Location = new System.Drawing.Point(12, 9);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(0, 13);
            this.TitleLable.TabIndex = 0;
            // 
            // VersionLabel_static
            // 
            this.VersionLabel_static.AutoSize = true;
            this.VersionLabel_static.Location = new System.Drawing.Point(12, 32);
            this.VersionLabel_static.Name = "VersionLabel_static";
            this.VersionLabel_static.Size = new System.Drawing.Size(45, 13);
            this.VersionLabel_static.TabIndex = 1;
            this.VersionLabel_static.Text = "Version:";
            // 
            // VersionLabel_dynamic
            // 
            this.VersionLabel_dynamic.AutoSize = true;
            this.VersionLabel_dynamic.Location = new System.Drawing.Point(63, 32);
            this.VersionLabel_dynamic.Name = "VersionLabel_dynamic";
            this.VersionLabel_dynamic.Size = new System.Drawing.Size(0, 13);
            this.VersionLabel_dynamic.TabIndex = 2;
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(12, 56);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(0, 13);
            this.CopyrightLabel.TabIndex = 3;
            // 
            // LicenseBox
            // 
            this.LicenseBox.Location = new System.Drawing.Point(12, 72);
            this.LicenseBox.Multiline = true;
            this.LicenseBox.Name = "LicenseBox";
            this.LicenseBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LicenseBox.Size = new System.Drawing.Size(535, 304);
            this.LicenseBox.TabIndex = 4;
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(12, 382);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 5;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 417);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.LicenseBox);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.VersionLabel_dynamic);
            this.Controls.Add(this.VersionLabel_static);
            this.Controls.Add(this.TitleLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutWindow";
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLable;
        private System.Windows.Forms.Label VersionLabel_static;
        private System.Windows.Forms.Label VersionLabel_dynamic;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.TextBox LicenseBox;
        private System.Windows.Forms.Button OK_Button;
    }
}