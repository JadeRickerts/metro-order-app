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
    public partial class Form6 : Form
    {
        bool openSystemSettings;
        MySqlConnection connection;
        string connectionString;
        DialogResult result;
        DataTable table = new DataTable();
        string server = Properties.Settings.Default["ServerName"].ToString();
        string database = Properties.Settings.Default["DatabaseName"].ToString();
        string userID = Properties.Settings.Default["UserID"].ToString();
        string password = Properties.Settings.Default["Password"].ToString();

        public Form6()
        {
            InitializeComponent();
            openSystemSettings = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            tbxBusinessName.Text = Properties.Settings.Default["CustomerName"].ToString();
            tbxEmailAddress.Text = Properties.Settings.Default["EmailAddress"].ToString();
            tbxPreferredStore.Text = Properties.Settings.Default["PreferredStore"].ToString();
            if(Convert.ToBoolean(Properties.Settings.Default["CheckForUpdates"]) == true)
            {
                cbxAutoUpdateCheck.CheckState = CheckState.Checked;
            } else if(Convert.ToBoolean(Properties.Settings.Default["CheckForUpdates"]) == false)
            {
                cbxAutoUpdateCheck.CheckState = CheckState.Unchecked;
            }
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            connectionString = string.Format("server={0}; database={1}; uid={2}; pwd={3}", server, database, userID, password);
            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * FROM codebeta_orderapp.Store";
                mySqlDataAdapter.SelectCommand = new MySqlCommand(sqlSelectAll, connection);
                mySqlDataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                result = MessageBox.Show("Successfully Established Connection", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                tbxPreferredStore.Text = row.Cells[2].Value.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxAutoUpdateCheck.CheckState == CheckState.Checked)
            {
                DialogResult autoUpdateCheckResult = MessageBox.Show("Auto Check For Updates At Start Up might slow down the app's start up depending on Internet connection speed.\nAre You Sure?", "User Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (autoUpdateCheckResult == DialogResult.No)
                {
                    cbxAutoUpdateCheck.CheckState = CheckState.Unchecked;
                }
            }
            Properties.Settings.Default["CustomerName"] = tbxBusinessName.Text;
            Properties.Settings.Default["EmailAddress"] = tbxEmailAddress.Text;
            Properties.Settings.Default["PreferredStore"] = tbxPreferredStore.Text;
            if(cbxAutoUpdateCheck.CheckState == CheckState.Checked)
            {
                Properties.Settings.Default["CheckForUpdates"] = true;
            } else if (cbxAutoUpdateCheck.CheckState == CheckState.Unchecked)
            {
                Properties.Settings.Default["CheckForUpdates"] = false;
            }
            Properties.Settings.Default.Save();
            DialogResult result = MessageBox.Show("Settings Updated", "System Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CODE GOES HERE
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(openSystemSettings == false)
            {
                bool startup = false;
                MainMenu mainMenu = new MainMenu(startup);
                mainMenu.Show();
            }
        }

        private void lblHeading_DoubleClick(object sender, EventArgs e)
        {
            openSystemSettings = true;
            Form5 form5 = new Form5();
            form5.Show();
            this.Close();
        }

        private void cbxAutoUpdateCheck_CheckStateChanged(object sender, EventArgs e)
        {
            
        }
    }
}
