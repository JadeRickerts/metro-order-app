using System;
using System.Windows.Forms;

namespace Order_App
{
    public partial class Form4 : Form
    {
        //INITIAL FORM WITH NO VARIABLES
        public Form4()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD SAVED APPLICATION SETTINGS
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                //Populate the textboxes with the saved values in the user.config file
                
                //File information
                tbxStockLoc.Text = Properties.Settings.Default["XMLStockFile"].ToString();
                tbxStoreLoc.Text = Properties.Settings.Default["XMLStoreFile"].ToString();
                tbxStockURL.Text = Properties.Settings.Default["WebStockFile"].ToString();
                tbxStoreURL.Text = Properties.Settings.Default["WebStoreFile"].ToString();
                tbxPromoLoc.Text = Properties.Settings.Default["XMLPromoFile"].ToString();
                tbxPromoURL.Text = Properties.Settings.Default["WebPromoFile"].ToString();
                //SMTP Server Information
                tbxSMTPServer.Text = Properties.Settings.Default["SMTPServerName"].ToString();
                tbxSMTPPort.Text = Properties.Settings.Default["SMTPPort"].ToString();
                tbxSMTPUsername.Text = Properties.Settings.Default["SMTPUsername"].ToString();
                tbxSMTPPassword.Text = Properties.Settings.Default["SMTPPassword"].ToString();
                //Other Information
                lblLastStoreUpdate2.Text = Properties.Settings.Default["LastStoreUpdate"].ToString();
                lblLastStockUpdate2.Text = Properties.Settings.Default["LastStockUpdate"].ToString();
                lblLastPromoUpdate2.Text = Properties.Settings.Default["LastPromoUpdate"].ToString();
                tbxAppSettingsPwd.Text = Properties.Settings.Default["SystemSettingPwd"].ToString();

                //Populate tickboxes. True = ticked, false = unticked.
                if (Properties.Settings.Default["SMTPSSL"].Equals(true))
                {
                    cbxSSL.CheckState = CheckState.Checked;
                }
                else
                {
                    cbxSSL.CheckState = CheckState.Unchecked;
                }

                if (Properties.Settings.Default["StartUp"].Equals(true))
                {
                    cbxStartUp.CheckState = CheckState.Checked;
                }
                else
                {
                    cbxStartUp.CheckState = CheckState.Unchecked;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SAVE APPLICATION SETTINGS
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Save values in the textboxes to user.config file. 
                //All settings are user settings (user scope) because it allows for it to be saved during runtime.
                
                //File Information
                Properties.Settings.Default["XMLStockFile"] = tbxStockLoc.Text;
                Properties.Settings.Default["XMLStoreFile"] = tbxStoreLoc.Text;
                Properties.Settings.Default["WebStockFile"] = tbxStockURL.Text;
                Properties.Settings.Default["WebStoreFile"] = tbxStoreURL.Text;
                Properties.Settings.Default["XMLPromoFile"] = tbxPromoLoc.Text;
                Properties.Settings.Default["WebPromoFile"] = tbxPromoURL.Text;
                //SMTP Server Information
                Properties.Settings.Default["SMTPServerName"] = tbxSMTPServer.Text;
                Properties.Settings.Default["SMTPPort"] = Int32.Parse(tbxSMTPPort.Text);
                Properties.Settings.Default["SMTPUsername"] = tbxSMTPUsername.Text;
                Properties.Settings.Default["SMTPPassword"] = tbxSMTPPassword.Text;
                if (cbxSSL.CheckState == CheckState.Checked)
                {
                    Properties.Settings.Default["SMTPSSL"] = true;
                }
                else
                {
                    Properties.Settings.Default["SMTPSSL"] = false;
                }
                //Other Information
                Properties.Settings.Default["SystemSettingPwd"] = tbxAppSettingsPwd.Text;
                if (cbxStartUp.CheckState == CheckState.Checked)
                {
                    Properties.Settings.Default["StartUp"] = true;
                }
                else
                {
                    Properties.Settings.Default["StartUp"] = false;
                }
                //SAVE
                Properties.Settings.Default.Save();
                DialogResult result = MessageBox.Show("Settings Updated", "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //EXIT APPLICATION SETTINGS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Close System Settings?", "Application Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CLOSING FORM LOGIC
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool startup = false;
                MainMenu mainMenu = new MainMenu(startup);
                mainMenu.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Application Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
