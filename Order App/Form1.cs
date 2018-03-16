using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Order_App
{
    public partial class MainMenu : Form
    {
        //FORM VARIABLES
        MySqlConnection connection;
        DateTime modifiedDate;
        string connectionString;
        bool startup;
        //DATABASE SERVER VARIABLES FROM APP SETTINGS
        string server = Properties.Settings.Default["ServerName"].ToString();
        string database = Properties.Settings.Default["DatabaseName"].ToString();
        string uid = Properties.Settings.Default["UserID"].ToString();
        string pwd = Properties.Settings.Default["Password"].ToString();

        //FORM START WITH NO VARIABLES
        public MainMenu()
        {
            InitializeComponent();
            startup = true;           
        }

        //FORM START WITH START BOOL
        public MainMenu(bool start)
        {
            InitializeComponent();
            startup = start;
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

        //EXIT APPLICATION
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Close Application", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //OPEN UPDATE STOCK FILE FORM
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            startup = false;
            this.Hide();
        }

        //OPEN USER SETTINGS FORM
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            startup = false;
            this.Hide();
        }

        //CHECK FOR STOCK FILE UPDATE METHOD
        private void checkUpdate()
        {
            connectionString = string.Format("server={0}; database={1}; uid={2}; pwd={3}", server, database, uid, pwd);
            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlCommand mySqlCommand;
                MySqlDataReader mySqlDataReader;
                string mySqlCommandString = "SELECT * FROM codebeta_orderapp.StockUpdated WHERE codebeta_orderapp.StockUpdated.id = 1";
                mySqlCommand = new MySqlCommand(mySqlCommandString, connection);
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    modifiedDate = mySqlDataReader.GetDateTime("ModifiedDate");
                }
                connection.Close();

                if (modifiedDate == Convert.ToDateTime(Properties.Settings.Default["LastStockUpdate"]))
                {
                    MessageBox.Show("Stock File Up-to-date", "Stock File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("New Stock File Available For Update.\nWould You Like To Update Now?", "Stock File Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        bool update = true;
                        Form3 form3 = new Form3(update);
                        form3.Show();
                        this.Hide();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MAIN MENU FORM STARTUP CONFIG
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if(startup == true && Convert.ToBoolean(Properties.Settings.Default["CheckForUpdates"]) == true)
            {
                checkUpdate();
            }
            if (Properties.Settings.Default["EmailAddress"].ToString() == "" || Properties.Settings.Default["CustomerName"].ToString() == "")
            {
                MessageBox.Show("Please Click On User Settings to Setup App Before Ordering", "Metro Order App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrder.Enabled = false;
            } else
            {
                btnOrder.Enabled = true;
            }
        }
    }
}
