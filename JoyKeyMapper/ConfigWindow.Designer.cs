namespace JoyKeyMapper
{
    partial class ConfigWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWindow));
            this.ok_Button = new System.Windows.Forms.Button();
            this.cancel_Button = new System.Windows.Forms.Button();
            this.ConfigGridView = new System.Windows.Forms.DataGridView();
            this.readbutton_button = new System.Windows.Forms.Button();
            this.readkey_button = new System.Windows.Forms.Button();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ok_Button
            // 
            this.ok_Button.Location = new System.Drawing.Point(455, 298);
            this.ok_Button.Name = "ok_Button";
            this.ok_Button.Size = new System.Drawing.Size(46, 23);
            this.ok_Button.TabIndex = 0;
            this.ok_Button.Text = "OK";
            this.ok_Button.UseVisualStyleBackColor = true;
            this.ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // cancel_Button
            // 
            this.cancel_Button.Location = new System.Drawing.Point(507, 298);
            this.cancel_Button.Name = "cancel_Button";
            this.cancel_Button.Size = new System.Drawing.Size(51, 23);
            this.cancel_Button.TabIndex = 1;
            this.cancel_Button.Text = "Cancel";
            this.cancel_Button.UseVisualStyleBackColor = true;
            this.cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ConfigGridView
            // 
            this.ConfigGridView.AllowUserToAddRows = false;
            this.ConfigGridView.AllowUserToDeleteRows = false;
            this.ConfigGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ConfigGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ConfigGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfigGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ConfigGridView.Location = new System.Drawing.Point(12, 12);
            this.ConfigGridView.Name = "ConfigGridView";
            this.ConfigGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConfigGridView.Size = new System.Drawing.Size(546, 280);
            this.ConfigGridView.TabIndex = 2;
            // 
            // readbutton_button
            // 
            this.readbutton_button.Location = new System.Drawing.Point(12, 298);
            this.readbutton_button.Name = "readbutton_button";
            this.readbutton_button.Size = new System.Drawing.Size(75, 23);
            this.readbutton_button.TabIndex = 3;
            this.readbutton_button.Text = "Read Button";
            this.readbutton_button.UseVisualStyleBackColor = true;
            this.readbutton_button.Click += new System.EventHandler(this.Readbutton_button_Click);
            // 
            // readkey_button
            // 
            this.readkey_button.Location = new System.Drawing.Point(93, 298);
            this.readkey_button.Name = "readkey_button";
            this.readkey_button.Size = new System.Drawing.Size(75, 23);
            this.readkey_button.TabIndex = 4;
            this.readkey_button.Text = "Read Keys";
            this.readkey_button.UseVisualStyleBackColor = true;
            this.readkey_button.Click += new System.EventHandler(this.Readkey_button_Click);
            // 
            // KeyLabel
            // 
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyLabel.Location = new System.Drawing.Point(174, 298);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(222, 30);
            this.KeyLabel.TabIndex = 5;
            this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(402, 298);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(47, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 333);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.readkey_button);
            this.Controls.Add(this.readbutton_button);
            this.Controls.Add(this.ConfigGridView);
            this.Controls.Add(this.cancel_Button);
            this.Controls.Add(this.ok_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ConfigWindow";
            this.Text = "Configuration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigWindow_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok_Button;
        private System.Windows.Forms.Button cancel_Button;
        private System.Windows.Forms.DataGridView ConfigGridView;
        private System.Windows.Forms.Button readbutton_button;
        private System.Windows.Forms.Button readkey_button;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}