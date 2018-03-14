using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Order_App
{
    public partial class Form3 : Form
    {
        MySqlConnection connection;
        string connectionString;
        DialogResult result;
        DataTable table = new DataTable();

        public Form3()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            connectionString = "server=code-beta.com; database=codebeta_orderapp; uid=codebeta_admin; pwd=root123";
            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * FROM codebeta_orderapp.Stock";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(result == DialogResult.OK)
            {
                table = (DataTable)dataGridView1.DataSource;
                table.TableName = "StockTable";
                table.WriteXml(@"C:\\metro-order-app\\stock.xml", XmlWriteMode.WriteSchema, true);
                MessageBox.Show("Stock File Successfully Updated", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Please Load Latest Stock File First", "Update Stock File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
