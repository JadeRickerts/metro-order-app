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
    //APPLICATION SETTINGS LOGIN FORM
    public partial class Form5 : Form
    {
        //FORM VARIABLES
        bool OpenNewForm;

        //FORM INITIALIZATION WITH NO VARIABLES
        public Form5()
        {
            try
            {
                InitializeComponent();
                OpenNewForm = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //APPLICATION SETTINGS LOGIN LOGIC
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxLogin.Text == Properties.Settings.Default["SystemSettingPwd"].ToString())
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    OpenNewForm = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Login Password", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Settings Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CLOSE FORM LOGIC
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (OpenNewForm == false)
                {
                    bool startup = false;
                    MainMenu form = new MainMenu(startup);
                    form.Show();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
