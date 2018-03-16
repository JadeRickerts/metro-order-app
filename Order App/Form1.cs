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
        MySqlConnection connection;
        string connectionString;
        string server = Properties.Settings.Default["ServerName"].ToString();
        string database = Properties.Settings.Default["DatabaseName"].ToString();
        string uid = Properties.Settings.Default["UserID"].ToString();
        string pwd = Properties.Settings.Default["Password"].ToString();
        DateTime modifiedDate;
        bool startup;

        public MainMenu()
        {
            InitializeComponent();
            startup = true;           
        }

        public MainMenu(bool start)
        {
            InitializeComponent();
            startup = start;

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
            startup = false;
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
            startup = false;
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMenu_DoubleClick(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            startup = false;
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            startup = false;
            this.Hide();
        }

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
