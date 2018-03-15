using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_App
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tbxStockFile.Text = Properties.Settings.Default["XMLStockFile"].ToString();
            tbxStoreFile.Text = Properties.Settings.Default["XMLStoreFile"].ToString();
            tbxServerName.Text = Properties.Settings.Default["ServerName"].ToString();
            tbxDatabase.Text = Properties.Settings.Default["DatabaseName"].ToString();
            tbxUserID.Text = Properties.Settings.Default["UserID"].ToString();
            tbxPassword.Text = Properties.Settings.Default["Password"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["XMLStockFile"] = tbxStockFile.Text;
            Properties.Settings.Default["XMLStoreFile"] = tbxStoreFile.Text;
            Properties.Settings.Default["ServerName"] = tbxServerName.Text;
            Properties.Settings.Default["DatabaseName"] = tbxDatabase.Text;
            Properties.Settings.Default["UserID"] = tbxUserID.Text;
            Properties.Settings.Default["Password"] = tbxPassword.Text;
            Properties.Settings.Default.Save();
            DialogResult result =  MessageBox.Show("Settings Updated", "System Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Close System Settings?", "System Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            } else if(result == DialogResult.No)
            {
                
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
