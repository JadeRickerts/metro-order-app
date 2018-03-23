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
                tbxStockFile.Text = Properties.Settings.Default["XMLStockFile"].ToString();
                tbxAppSettingsPwd.Text = Properties.Settings.Default["SystemSettingPwd"].ToString();
                tbxServerName.Text = Properties.Settings.Default["ServerName"].ToString();
                tbxDatabase.Text = Properties.Settings.Default["DatabaseName"].ToString();
                tbxUserID.Text = Properties.Settings.Default["UserID"].ToString();
                tbxPassword.Text = Properties.Settings.Default["Password"].ToString();
                tbxSMTPServer.Text = Properties.Settings.Default["SMTPServerName"].ToString();
                tbxSMTPPort.Text = Properties.Settings.Default["SMTPPort"].ToString();
                tbxSMTPUsername.Text = Properties.Settings.Default["SMTPUsername"].ToString();
                tbxSMTPPassword.Text = Properties.Settings.Default["SMTPPassword"].ToString();

                if (Properties.Settings.Default["SMTPSSL"].Equals(true))
                {
                    cbxSSL.CheckState = CheckState.Checked;
                }
                else
                {
                    cbxSSL.CheckState = CheckState.Unchecked;
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
                //DATABASE FILE INFO
                Properties.Settings.Default["ServerName"] = tbxServerName.Text;
                Properties.Settings.Default["DatabaseName"] = tbxDatabase.Text;
                Properties.Settings.Default["UserID"] = tbxUserID.Text;
                Properties.Settings.Default["Password"] = tbxPassword.Text;
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
                Properties.Settings.Default["XMLStockFile"] = tbxStockFile.Text;
                Properties.Settings.Default["SystemSettingPwd"] = tbxAppSettingsPwd.Text;
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
    }
}
