using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Order_App
{
    public partial class Form3 : Form
    {
        WebClient webClient = new WebClient();

        //FORM INITIALIZATION WITH NO VARIABLES
        public Form3()
        {
            try
            {
                InitializeComponent();
                btnOpen.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FORM INITIALIZATION WITH BOOLEAN VARIABLES
        public Form3(bool update)
        {
            try
            {
                InitializeComponent();
                if (update == true)
                {
                    startUpdate();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD LATEST STOCK FILE FROM ONLINE DATABASE SERVER
        private void btnOpen_Click(object sender, EventArgs e)
        {
            startUpdate();
        }

        //START STOCK FILE LOAD THREAD LOGIC
        private void startUpdate()
        {
            try
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri(Properties.Settings.Default["WebStockFile"].ToString()), Properties.Settings.Default["XMLStockFile"].ToString());
                btnCancel.Text = "Cancel";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //If download is cancelled.
            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //If an error occurs.
            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to download file", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If everything went well and the file downloaded. 
            Properties.Settings.Default["LastStockUpdate"] = DateTime.Now;
            Properties.Settings.Default.Save();
            MessageBox.Show("Download Completed!", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnOpen.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Text = "Close";
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar.Value = (int)e.BytesReceived / 100;
            lblDownloadProgress.Text = string.Format("Download Progress [{0} MB / {1} MB]", (double)e.BytesReceived / 1000000, (double)e.TotalBytesToReceive / 1000000);
        }

        //CANCEL DOWNLOAD LOGIC
        private void cancelDownload()
        {
            webClient.CancelAsync();
            progressBar.Value = 0;
            lblDownloadProgress.Text = "Download Progress";
            btnCancel.Text = "Close";
        }

        //WRITE DATAGRIDVIEW TO XML DOCUMENT
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool update = checkUpdate(Properties.Settings.Default["WebStockFile"].ToString(), "LastStockUpdate");
                if(update == true)
                {
                    MessageBox.Show("Stock File Up-To-Date", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if (update == false)
                {
                    MessageBox.Show("Update Available", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOpen.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CLOSE FORM LOGIC
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(btnCancel.Text == "Close")
            {
                try
                {
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (btnCancel.Text == "Cancel")
            {
                cancelDownload();
            }
            
        }

        //CLOSING FORM LOGIC
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool startup = false;
                MainMenu mainMenu = new MainMenu(startup);
                mainMenu.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CHECK UPDATE METHOD
        public bool checkUpdate(string url, string type)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; // Important - Not interested in file contents

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (Convert.ToDateTime(Properties.Settings.Default[type]) >= response.LastModified)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
    }
}
