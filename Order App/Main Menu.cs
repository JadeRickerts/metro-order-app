using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Order_App
{
    public partial class MainMenu : Form
    {
        bool startup;
        Form3 form3 = new Form3();

        //FORM INITIALIZATION WITH NO PARAMETERS
        public MainMenu()
        {
            try
            {
                InitializeComponent();
                startup = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        //FORM INITIALIZATION WITH START BOOL
        public MainMenu(bool start)
        {
            try
            {
                InitializeComponent();
                startup = start;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FORMS
        //1. OPEN ORDER FORM
        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                order.Show();
                startup = false;
                this.Hide();
            } catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //2. OPEN UPDATE STOCK FILE FORM
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 form3 = new Form3();
                form3.Show();
                startup = false;
                this.Hide();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //3. OPEN USER SETTINGS FORM
        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Form6 form6 = new Form6();
                form6.Show();
                startup = false;
                this.Hide();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //4. EXIT APPLICATION
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CHECK FOR UPDATES IF USER SETTING IS SELECTED
        private void MainMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                //Check if metro-order-app folder exists, reset user settings and copy files over if it does not exist. 
                if (!Directory.Exists(@"C:\metro-order-app"))
                {
                    copyStartUpFiles();
                    resetUserSettings();
                }

                //Check if basic info has been submitted otherwise user can't order
                if (Properties.Settings.Default["EmailAddress"].ToString() == "" || Properties.Settings.Default["CustomerName"].ToString() == "")
                {
                    MessageBox.Show("Please Click On User Settings to Setup App Before Ordering. \nPlease Enter Business Name and Email Address to Create Orders.", "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOrder.Enabled = false;
                }
                else
                {
                    btnOrder.Enabled = true;
                }

                //Check if "check for updates" user setting is active. If active, check for updates. If update is available, ask user how to proceed. 
                if ((bool)Properties.Settings.Default["CheckForUpdates"] == true)
                {
                    bool update = form3.checkUpdate(Properties.Settings.Default["WebStockFile"].ToString(), type: "LastStockUpdate");
                    if (update == true)
                    {
                        MessageBox.Show("Stock File Up-To-Date!", "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (update == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("Update Available! \nWould You Like To Update?", "Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            bool startUpdate = true;
                            Form3 form = new Form3(startUpdate);
                            this.Hide();
                            form.Show();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FUNCTIONS
        //Set user settings to default if metro-order-app folder doesn't exist. 
        private void resetUserSettings()
        {
            //SET DEFAULT VALUES
            //This is the date when the final stock file is uploaded to the host server.
            DateTime value = new DateTime(2018, 3, 1);
            
            //user settings
            Properties.Settings.Default["ContactNumber"] = "";
            Properties.Settings.Default["CustomerName"] = "";
            Properties.Settings.Default["PreferredStore"] = "";
            Properties.Settings.Default["EmailAddress"] = "";
            Properties.Settings.Default["CheckForUpdates"] = false;
            Properties.Settings.Default["SendOrderCopy"] = true;
            
            //file settings - setup before going live!
            Properties.Settings.Default["LastStockUpdate"] = value;
            Properties.Settings.Default["LastStoreUpdate"] = value;
            Properties.Settings.Default["XMLStockFile"] = @"C:\metro-order-app\stock.xml";
            Properties.Settings.Default["XMLStoreFile"] = @"C:\metro-order-app\store.xml";
            Properties.Settings.Default["WebStockFile"] = "http://www.code-beta.com/metro-order-app/stock.xml";
            Properties.Settings.Default["WebStoreFile"] = "http://www.code-beta.com/metro-order-app/store.xml";
            //mail settings - setup before going live!
            Properties.Settings.Default["SMTPServerName"] = "mail.code-beta.com";
            Properties.Settings.Default["SMTPUsername"] = "metro-order-app@code-beta.com";
            Properties.Settings.Default["SMTPPassword"] = "sefalana216009";
            Properties.Settings.Default["SMTPPort"] = 25;
            Properties.Settings.Default["SMTPSSL"] = false;
            //application settings - setup before going live!
            Properties.Settings.Default["SystemSettingPwd"] = "sefalana216009";

            Properties.Settings.Default.Save();
        }

        //Copy files in resources folder in Program Files to metro-order-app folder on C: drive.
        private void copyStartUpFiles()
        {
            string fileName = "stock.xml";
            string resourcesPath = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory().ToString(), "resources");
            string metroOrderAppFolderPath = string.Format(@"C:\metro-order-app\");

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(resourcesPath, fileName);
            string destFile = Path.Combine(metroOrderAppFolderPath, fileName);

            // Copy resources folder content to metro-order-app folder:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(metroOrderAppFolderPath))
            {
                Directory.CreateDirectory(metroOrderAppFolderPath);
            }
            if (Directory.Exists(resourcesPath))
            {
                string[] files = Directory.GetFiles(resourcesPath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(metroOrderAppFolderPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                MessageBox.Show("Resources Folder Does Not Exist!", "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Properties.Settings.Default["StartUp"] = false;
            Properties.Settings.Default.Save();
        }
    }
}
