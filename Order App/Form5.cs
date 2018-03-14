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
    public partial class Form5 : Form
    {
        bool OpenNewForm;
        public Form5()
        {
            InitializeComponent();
            OpenNewForm = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbxLogin.Text == "sefalana216009")
            {
                Form4 form4 = new Form4();
                form4.Show();
                OpenNewForm = true;
                this.Close();
            } else
            {
                MessageBox.Show("Incorrect Login Password", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(OpenNewForm == false)
            {
                MainMenu form = new MainMenu();
                form.Show();
            }
            
        }
    }
}
