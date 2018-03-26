using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            try
            {
                if (Properties.Settings.Default["EmailAddress"].ToString() == "" || Properties.Settings.Default["CustomerName"].ToString() == "")
                {
                    MessageBox.Show("Please Click On User Settings to Setup App Before Ordering", "Metro Order App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOrder.Enabled = false;
                }
                else
                {
                    btnOrder.Enabled = true;
                }
            } catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
