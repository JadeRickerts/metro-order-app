using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Net;

namespace Order_App
{
    //USER SETTINGS FORM
    public partial class Form6 : Form
    {
        //FORM VARIABLES
        BindingSource bindingSource = new BindingSource();
        Form3 form3 = new Form3();
        bool openSystemSettings;
        DataTable table = new DataTable();

        //FORM INITIALIZATION WITH NO VARIABLES
        public Form6()
        {
            try
            {
                InitializeComponent();
                openSystemSettings = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD USER SETTINGS SAVED VALUES
        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                lblDownloadProgress.Visible = false;
                progressBar.Visible = false;
                tbxBusinessName.Text = Properties.Settings.Default["CustomerName"].ToString();
                tbxEmailAddress.Text = Properties.Settings.Default["EmailAddress"].ToString();
                tbxContactNumber.Text = Properties.Settings.Default["ContactNumber"].ToString();
                tbxPreferredStore.Text = Properties.Settings.Default["PreferredStore"].ToString();

                if (Convert.ToBoolean(Properties.Settings.Default["CheckForUpdates"]) == true)
                {
                    cbxAutoUpdateCheck.CheckState = CheckState.Checked;
                }
                else if (Convert.ToBoolean(Properties.Settings.Default["CheckForUpdates"]) == false)
                {
                    cbxAutoUpdateCheck.CheckState = CheckState.Unchecked;
                }

                string path = Properties.Settings.Default["XMLStoreFile"].ToString();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dataTable = new DataTable();
                dataTable = dataSet.Tables[0];

                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 120;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD STORE CONTACT LIST DATA GRID VIEW LOGIC
        private void btnLoad_Click(object sender, EventArgs e)
        {
            bool updated = form3.checkUpdate(Properties.Settings.Default["WebStoreFile"].ToString(), "LastStoreUpdate");
            if(updated == false)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(new Uri(Properties.Settings.Default["WebStoreFile"].ToString()), Properties.Settings.Default["XMLStoreFile"].ToString());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (updated == true)
            {
                MessageBox.Show("Store File Up-To-Date!", "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Properties.Settings.Default["LastStoreUpdate"] = DateTime.Now;
            Properties.Settings.Default.Save();
            MessageBox.Show("Update Completed!", "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLoad.Enabled = false;
            progressBar.Visible = false;
            lblDownloadProgress.Visible = false;
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar.Value = (int)e.BytesReceived / 100;
            lblDownloadProgress.Visible = true;
            lblDownloadProgress.Text = string.Format("Download Progress [{0} KB / {1} KB]", (double)e.BytesReceived / 1000, (double)e.TotalBytesToReceive / 1000);
        }

        //SELECTING CONTACT FROM DATA GRID VIEW LOGIC
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    tbxPreferredStore.Text = row.Cells[2].Value.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //SAVE USER SETTINGS LOGIC
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxAutoUpdateCheck.CheckState == CheckState.Checked)
                {
                    DialogResult autoUpdateCheckResult = MessageBox.Show("Auto Check For Updates At Start Up might slow down the app's start up depending on Internet connection speed.\nAre You Sure?", "User Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (autoUpdateCheckResult == DialogResult.No)
                    {
                        cbxAutoUpdateCheck.CheckState = CheckState.Unchecked;
                    }
                }
                Properties.Settings.Default["CustomerName"] = tbxBusinessName.Text;
                Properties.Settings.Default["EmailAddress"] = tbxEmailAddress.Text;
                Properties.Settings.Default["ContactNumber"] = tbxContactNumber.Text;
                Properties.Settings.Default["PreferredStore"] = tbxPreferredStore.Text;
                if (cbxAutoUpdateCheck.CheckState == CheckState.Checked)
                {
                    Properties.Settings.Default["CheckForUpdates"] = true;
                }
                else if (cbxAutoUpdateCheck.CheckState == CheckState.Unchecked)
                {
                    Properties.Settings.Default["CheckForUpdates"] = false;
                }
                Properties.Settings.Default.Save();
                DialogResult result = MessageBox.Show("Settings Updated", "System Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CLOSE FORM
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FORM CLOSING LOGIC
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (openSystemSettings == false)
                {
                    bool startup = false;
                    MainMenu mainMenu = new MainMenu(startup);
                    mainMenu.Show();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //OPEN APPLICATION SETTINGS LOGIN FORM LOGIC
        private void lblHeading_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                openSystemSettings = true;
                Form5 form5 = new Form5();
                form5.Show();
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
