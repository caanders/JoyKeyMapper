using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JoyKeyMapper
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            ActionStatus statusReturn = MainController.Start_stop_mapping();

            switch(statusReturn)
            {
                case ActionStatus.starting:
                    ShowMessageBox("Mapping is starting up. Please wait until action is finished.", "Warning");
                    break;
                case ActionStatus.stopping:
                    ShowMessageBox("Mapping is shutting down. Please wait until action is finished.", "Warning");
                    break;
                case ActionStatus.startingError:
                    ShowMessageBox("Error during shutdown. Please try again or restart application.", "Error");
                    break;
                case ActionStatus.stoppingError:
                    ShowMessageBox("Error during shutdown. Please restart application.", "Error");
                    break;
                case ActionStatus.running:
                    StatusBox.Text = "Online";
                    StatusBox.BackColor = Color.Green;
                    break;
                case ActionStatus.stopped:
                    StatusBox.Text = "Offline";
                    StatusBox.BackColor = Color.Red;
                    break;
                default:
                    ShowMessageBox("Unknown action requested. Please restart application", "Error");
                    break;
            }
        }

        private void ShowMessageBox(string v, string title)
        {
            MessageBox.Show(v, title, MessageBoxButtons.OK);
        }

        private void Config_Button_Click(object sender, EventArgs e)
        {
            (new ConfigWindow()).ShowDialog();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainController.StopOnClose();
            Properties.Settings.Default.Save();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autoStartup)
                this.StartStopButton_Click(sender, e);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.minimizeTray)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    this.ShowInTaskbar = false;
                    this.notifyIcon.Visible = true;
                    this.notifyIcon.ShowBalloonTip(3000);
                }
                else
                {
                    this.ShowInTaskbar = true;
                    this.notifyIcon.Visible = false;
                }
            }
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.WindowState = FormWindowState.Normal;
        }

        private void JoyKeyMapperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = ((AssemblyTitleAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false))[0]).Title;
            string copyright = ((AssemblyCopyrightAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false))[0]).Copyright;
            string test = ((AssemblyDescriptionAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false))[0]).Description;
            string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }
    }
}
