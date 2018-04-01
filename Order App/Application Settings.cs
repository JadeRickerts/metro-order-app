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
                tbxAppSettingsPwd.Text = Properties.Settings.Default["SystemSettingPwd"].ToString();
                tbxStockLoc.Text = Properties.Settings.Default["XMLStockFile"].ToString();
                tbxStoreLoc.Text = Properties.Settings.Default["XMLStoreFile"].ToString();
                tbxStockURL.Text = Properties.Settings.Default["WebStockFile"].ToString();
                tbxStoreURL.Text = Properties.Settings.Default["WebStoreFile"].ToString();
                tbxSMTPServer.Text = Properties.Settings.Default["SMTPServerName"].ToString();
                tbxSMTPPort.Text = Properties.Settings.Default["SMTPPort"].ToString();
                tbxSMTPUsername.Text = Properties.Settings.Default["SMTPUsername"].ToString();
                tbxSMTPPassword.Text = Properties.Settings.Default["SMTPPassword"].ToString();
                lblLastStoreUpdate2.Text = Properties.Settings.Default["LastStoreUpdate"].ToString();
                lblLastStockUpdate2.Text = Properties.Settings.Default["LastStockUpdate"].ToString();

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
                //FILE INFORMATION
                Properties.Settings.Default["XMLStockFile"] = tbxStockLoc.Text;
                Properties.Settings.Default["XMLStoreFile"] = tbxStoreLoc.Text;
                Properties.Settings.Default["WebStockFile"] = tbxStockURL.Text;
                Properties.Settings.Default["WebStoreFile"] = tbxStoreURL.Text;
                //SMTP SERVER INFO
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
                //OTHER INFO
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
                DialogResult result = MessageBox.Show("Settings Updated", "System Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult result = MessageBox.Show("Are You Sure You Want To Close System Settings?", "System Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
