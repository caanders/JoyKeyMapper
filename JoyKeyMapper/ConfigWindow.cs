using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace JoyKeyMapper
{
    public partial class ConfigWindow : Form
    {
        private bool readKeyStatus = false;
        private List<int> keys;
        private Thread readButtonThread;
        private List<string[]> button = new List<string[]>();
        private bool configChanged = false;

        public ConfigWindow()
        {
            InitializeComponent();
            this.ConfigGridView.DataSource = ConfigController.GetConfigData(false);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            if (this.readButtonThread != null)
            {
                MessageBox.Show("Button input is still  active. Please press \"Read  Button\" first!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                ConfigController.CancelChanges();
                this.Close();
            }
        }

        private void Readbutton_button_Click(object sender, EventArgs e)
        {
            if (this.readButtonThread == null)
            {
                ConfigController.Poll = true;
                this.KeyLabel.Text = "Waiting for controller input.\nClick \"Read Button\" again to obtain input.";
                readButtonThread = new Thread(new ThreadStart(delegate
                {
                    this.button = ConfigController.GetChanges();
                }));
                this.readButtonThread.Start();
            }
            else
            {
                ConfigController.Poll = false;
                this.readButtonThread.Join();
                this.readButtonThread = null;
                this.KeyLabel.Text = String.Empty;

                string displayString = string.Empty;

                this.ConfigGridView.ClearSelection();
                this.ConfigGridView.Invalidate();
                this.ConfigGridView.MultiSelect = true;

                for (int i = 0; i < button.Count; i++)
                {
                    foreach (DataGridViewRow row in this.ConfigGridView.Rows)
                    {
                        DataRow tempRow = ((DataRowView)row.DataBoundItem).Row;
                        if ((string)tempRow[0] == button[i][0] && (string)tempRow[1] == button[i][1])
                        {
                            row.Selected = true;
                        }
                    }

                    if (displayString != string.Empty)
                    {
                        displayString += "\n";
                    }
                    displayString += "Found control: " + button[i][0] + "->" + button[i][1];
                }

                if (displayString == string.Empty)
                    displayString = "No Input found";

                MessageBox.Show(displayString, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
                
                this.ConfigGridView.AutoResizeColumns();
                this.ConfigGridView.Invalidate();
            }            
        }

        private void Readkey_button_Click(object sender, EventArgs e)
        {
            if (!this.readKeyStatus)
            {
                this.KeyLabel.Text = "Waiting for key input.\nClick \"Read Key\" again to obtain input.";
                this.keys = new List<int>();
                this.readKeyStatus = true;

            }
            else
            {
                List<DataRow> rowList = new List<DataRow>();

                foreach (DataGridViewRow row in this.ConfigGridView.SelectedRows)
                {
                    rowList.Add(((DataRowView)row.DataBoundItem).Row);
                }

                ConfigController.ModifyKeysOnRows(this.keys, rowList);
                this.ConfigGridView.Invalidate();
                this.KeyLabel.Text = String.Empty;
                this.readKeyStatus = false;
            }
        }

        private void ConfigWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(this.readKeyStatus)
            {
                keys.Add(e.KeyValue);
            }
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            bool  checkFlag = ConfigController.SaveChanges();
            this.configChanged = checkFlag;

            if (checkFlag)
            {
                AutoClosingMessageBox.Show("Changes saved. Configuration will  be closed", "",3000, MessageBoxButtons.OK);
                //MessageBox.Show("Changes saved. Configuration will  be closed", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            else
            {
                MessageBox.Show("Can not save changes. Changes discarded", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            List<DataRow> selectedRows = new List<DataRow>();

            foreach (DataGridViewRow selectedViewRow in this.ConfigGridView.SelectedRows)
            {
                selectedRows.Add(((DataRowView)selectedViewRow.DataBoundItem).Row);
            }
            
            bool deleted = ConfigController.DeleteSelectedRows(selectedRows);

            if(deleted)
            {
                MessageBox.Show("Rows deleted", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Can not delete rows. ALL changes discarded", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void ConfigWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainController.Start_stop_mapping(this.configChanged);
        }
    }
}
