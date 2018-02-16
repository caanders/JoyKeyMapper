namespace JoyKeyMapper
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.StartStopButton = new System.Windows.Forms.Button();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.config_Button = new System.Windows.Forms.Button();
            this.minimizeChecker = new System.Windows.Forms.CheckBox();
            this.startupChecker = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joyKeyMapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(12, 27);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(130, 23);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "Start/Stop Mapping";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.BackColor = System.Drawing.Color.Red;
            this.StatusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.StatusBox.Location = new System.Drawing.Point(148, 27);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.Size = new System.Drawing.Size(124, 23);
            this.StatusBox.TabIndex = 1;
            this.StatusBox.Text = "Offline";
            this.StatusBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // config_Button
            // 
            this.config_Button.Location = new System.Drawing.Point(12, 56);
            this.config_Button.Name = "config_Button";
            this.config_Button.Size = new System.Drawing.Size(130, 23);
            this.config_Button.TabIndex = 3;
            this.config_Button.Text = "Configuration";
            this.config_Button.UseVisualStyleBackColor = true;
            this.config_Button.Click += new System.EventHandler(this.Config_Button_Click);
            // 
            // minimizeChecker
            // 
            this.minimizeChecker.AutoSize = true;
            this.minimizeChecker.Checked = global::JoyKeyMapper.Properties.Settings.Default.minimizeTray;
            this.minimizeChecker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JoyKeyMapper.Properties.Settings.Default, "minimizeTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minimizeChecker.Location = new System.Drawing.Point(148, 60);
            this.minimizeChecker.Name = "minimizeChecker";
            this.minimizeChecker.Size = new System.Drawing.Size(97, 17);
            this.minimizeChecker.TabIndex = 4;
            this.minimizeChecker.Text = "minimize to tray";
            this.minimizeChecker.UseVisualStyleBackColor = true;
            // 
            // startupChecker
            // 
            this.startupChecker.AutoSize = true;
            this.startupChecker.Checked = global::JoyKeyMapper.Properties.Settings.Default.autoStartup;
            this.startupChecker.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JoyKeyMapper.Properties.Settings.Default, "autoStartup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startupChecker.Location = new System.Drawing.Point(148, 83);
            this.startupChecker.Name = "startupChecker";
            this.startupChecker.Size = new System.Drawing.Size(82, 17);
            this.startupChecker.TabIndex = 5;
            this.startupChecker.Text = "auto startup";
            this.startupChecker.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "JoyKeyMapper";
            this.notifyIcon.BalloonTipTitle = "JoyKeyMapper";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "JoyKeyMapper";
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joyKeyMapperToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // joyKeyMapperToolStripMenuItem
            // 
            this.joyKeyMapperToolStripMenuItem.Name = "joyKeyMapperToolStripMenuItem";
            this.joyKeyMapperToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.joyKeyMapperToolStripMenuItem.Text = "JoyKeyMapper";
            this.joyKeyMapperToolStripMenuItem.Click += new System.EventHandler(this.JoyKeyMapperToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 108);
            this.Controls.Add(this.startupChecker);
            this.Controls.Add(this.minimizeChecker);
            this.Controls.Add(this.config_Button);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "JoyKeyMapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Button config_Button;
        private System.Windows.Forms.CheckBox minimizeChecker;
        private System.Windows.Forms.CheckBox startupChecker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joyKeyMapperToolStripMenuItem;
    }
}

