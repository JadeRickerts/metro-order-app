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

        //MAIN MENU FORM STARTUP CONFIG
        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        //OPEN ORDER FORM
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

        //OPEN UPDATE STOCK FILE FORM
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

        //OPEN USER SETTINGS FORM
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

        //EXIT APPLICATION
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
                //Check if stock and store startup files were copied
                if((bool)Properties.Settings.Default["StartUp"] == true)
                {
                    copyStartUpFiles();
                    resetUserSettings();
                }
                else
                {
                    //DO NOTHING
                }
                //Check if basic info has been submitted otherwise user can't order
                if (Properties.Settings.Default["EmailAddress"].ToString() == "" || Properties.Settings.Default["CustomerName"].ToString() == "")
                {
                    MessageBox.Show("Please Click On User Settings to Setup App Before Ordering", "Metro Order App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOrder.Enabled = false;
                }
                else
                {
                    btnOrder.Enabled = true;
                }

                //Check if "check for updates" user setting is active. 
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
                        else if (dialogResult == DialogResult.No)
                        {
                            //DO NOTHING
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetUserSettings()
        {
            DateTime value = new DateTime(2018, 3, 1);
            
            Properties.Settings.Default["ContactNumber"] = "";
            Properties.Settings.Default["CustomerName"] = "";
            Properties.Settings.Default["PreferredStore"] = "";
            Properties.Settings.Default["EmailAddress"] = "";
            Properties.Settings.Default["LastStockUpdate"] = value;
            Properties.Settings.Default["LastStoreUpdate"] = value;
            Properties.Settings.Default.Save();
        }

        private void copyStartUpFiles()
        {
            string fileName = "stock.xml";
            string sourcePath = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory().ToString(), "resources");
            string targetPath = string.Format(@"C:\metro-order-app\");

            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
            Properties.Settings.Default["StartUp"] = false;
            Properties.Settings.Default.Save();
        }
    }
}
