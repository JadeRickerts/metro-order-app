using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Order_App
{
    public partial class MainMenu : Form
    {
        DialogResult result;

        public MainMenu()
        {
            InitializeComponent();
            if(Properties.Settings.Default["EmailAddress"].ToString() == "" || Properties.Settings.Default["CustomerName"].ToString() == "")
            {
                btnOrder.Visible = false;
                btnUpdate.Visible = false;
                tbxClientName.Visible = true;
                tbxEmailAddress.Visible = true;
                btnSave.Visible = true;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Close Application", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["EmailAddress"] = tbxEmailAddress.Text;
                Properties.Settings.Default["CustomerName"] = tbxClientName.Text;
                Properties.Settings.Default.Save();
                result = MessageBox.Show("User Settings Saved", "Save User Preferences", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(result == DialogResult.OK)
                {
                    btnOrder.Visible = true;
                    tbxClientName.Visible = false;
                    tbxEmailAddress.Visible = false;
                    btnSave.Visible = false;
                }
            } catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Save User Preferences", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void MainMenu_DoubleClick(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
