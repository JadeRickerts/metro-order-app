using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Order_App
{
    public partial class Promotions : Form
    {
        //Global variables
        WebClient webClient = new WebClient();
        string[] nameArray;
        string[] startDateArray;
        string[] endDateArray;
        string[] fileNameArray;

        //Initialize without parameters
        public Promotions()
        {
            InitializeComponent();
        }

        //Download new promotions
        private void btnDownload_Click(object sender, EventArgs e)
        {
            cbxPromotions.Enabled = false;
            startDownload();
        }

        //BACKGROUND WORKER DOWNLOAD COMPLETED LOGIC
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //If download is cancelled.
            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled", "Download Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //If an error occurs.
            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to download file", "Download Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If everything went well and the file downloaded. 
            Properties.Settings.Default["LastPromoUpdate"] = DateTime.Now;
            Properties.Settings.Default.Save();
            MessageBox.Show("Download Completed!", "Download Promotions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDownload.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Text = "Close";
            //string startPath = @"c:\example\start";
            string zipPath = @"C:\metro-order-app\promo.zip";
            string extractPath = @"C:\metro-order-app\promo";
            Directory.Delete(extractPath, recursive: true);
            //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            btnLoad.Enabled = true;
        }

        //BACKGROUND WORKER DOWNLOAD PROGRESS LOGIC
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 1000;
            progressBar1.Value = (int)e.BytesReceived / 1000;
            lblDownloadProgress.Text = string.Format("Download Progress [{0} MB / {1} MB]", (double)e.BytesReceived / 1000000, (double)e.TotalBytesToReceive / 1000000);
        }

        //CANCEL DOWNLOAD LOGIC
        private void cancelDownload()
        {
            webClient.CancelAsync();
            progressBar1.Value = 0;
            lblDownloadProgress.Text = "Download Progress";
            btnCancel.Text = "Close";
        }

        //START PROMO FILE LOAD THREAD LOGIC
        private void startDownload()
        {
            try
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri("http://www.code-beta.com/downloads/promo.zip"), @"C:\metro-order-app\promo.zip");
                btnCancel.Text = "Cancel";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Download Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Load current promotions available on local drive
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //string[] nameArray = XDocument.Load(@"C:\metro-order-app\promo.xml").Descendants("name").Select(promotion => promotion.Value).ToArray();
            //string[] startDateArray = XDocument.Load(@"C:\metro-order-app\promo.xml").Descendants("startDate").Select(promotion => promotion.Value).ToArray();
            //string[] endDateArray = XDocument.Load(@"C:\metro-order-app\promo.xml").Descendants("endDate").Select(promotion => promotion.Value).ToArray();
            //string[] fileNameArray = XDocument.Load(@"C:\metro-order-app\promo.xml").Descendants("filename").Select(promotion => promotion.Value).ToArray();

            //FILL COMBOBOX WITH PROMO DATA
            nameArray = XDocument.Load(@"C:\metro-order-app\promo\promo.xml").Descendants("name").Select(promotion => promotion.Value).ToArray();
            startDateArray = XDocument.Load(@"C:\metro-order-app\promo\promo.xml").Descendants("startDate").Select(promotion => promotion.Value).ToArray();
            endDateArray = XDocument.Load(@"C:\metro-order-app\promo\promo.xml").Descendants("endDate").Select(promotion => promotion.Value).ToArray();
            fileNameArray = XDocument.Load(@"C:\metro-order-app\promo\promo.xml").Descendants("filename").Select(promotion => promotion.Value).ToArray();
            cbxPromotions.Items.Clear();
            for (int i = 0; i < nameArray.Length; i++)
            {
                cbxPromotions.Items.Add(nameArray[i]);
            }
            cbxPromotions.Enabled = true;
        }

        //Check if local promo file exists or not
        private void Promotions_Load(object sender, EventArgs e)
        {
            cbxPromotions.Enabled = false;
            if (!File.Exists(@"C:\metro-order-app\promo\promo.xml"))
            {
                btnLoad.Enabled = false;
                MessageBox.Show("Download Promotions");
                btnDownload.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else if (File.Exists(@"C:\metro-order-app\promo\promo.xml"))
            {
                btnLoad.Enabled = true;
                btnDownload.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        //Change deadline dates and pdf view when combobox list changes
        private void cbxPromotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEndDate02.Text = endDateArray[cbxPromotions.SelectedIndex];
            lblStartDate02.Text = startDateArray[cbxPromotions.SelectedIndex];
            axAcroPDF1.src = string.Format(@"C:\metro-order-app\promo\promo{0}.pdf", cbxPromotions.SelectedIndex);
        }

        //Cancel download logic
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Close")
            {
                try
                {
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update Purchases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnCancel.Text == "Cancel")
            {
                cancelDownload();
            }
        }

        //Check for updates logic
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cbxPromotions.Enabled = false;
                string update = checkUpdate(Properties.Settings.Default["WebPromoFile"].ToString(), "LastPromoUpdate");
                if (update == "true")
                {
                    MessageBox.Show("Promotions Up-To-Date", "Update Promotions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (update == "false")
                {
                    MessageBox.Show("Update Available", "Update Promotions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDownload.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update method
        private string checkUpdate(string url, string type)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; // Important - Not interested in file contents

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (Convert.ToDateTime(Properties.Settings.Default[type]) >= response.LastModified)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "error";
            }
        }

        //Form closing logic
        private void Promotions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool startup = false;
                MainMenu mainMenu = new MainMenu(startup);
                mainMenu.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Promotions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
