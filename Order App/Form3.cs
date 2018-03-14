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
            //using (OpenFileDialog ofd = new OpenFileDialog()
            //{
            //    Filter = "Excel Workbook|*.xls",
            //    ValidateNames = true
            //})
            //{
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
            //        IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
            //        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            //        {
            //            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            //            {
            //                UseHeaderRow = true
            //            }
            //        });
            //        dataGridView1.DataSource = result.Tables[0];
            //        reader.Close();
            //    }
            //}
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
                //BindingSource bindingSource = new BindingSource();
                //bindingSource.DataSource = table;
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
            //string stOutput = "";
            //// Export titles:
            //string sHeaders = "";
            //string filename = Directory.GetCurrentDirectory() + @"\stock.xlsx";

            //for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //    sHeaders = sHeaders.ToString() + Convert.ToString(dataGridView1.Columns[j].HeaderText) + "\t";
            //stOutput += sHeaders + "\r\n";
            //// Export data.
            //for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            //{
            //    string stLine = "";
            //    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
            //        stLine = stLine.ToString() + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "\t";
            //    stOutput += stLine + "\r\n";
            //}
            //Encoding utf16 = Encoding.GetEncoding(1254);
            //byte[] output = utf16.GetBytes(stOutput);
            //FileStream fs = new FileStream(filename, FileMode.Create);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(output, 0, output.Length); //write the encoded file
            //bw.Flush();
            //bw.Close();
            //fs.Close();
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
