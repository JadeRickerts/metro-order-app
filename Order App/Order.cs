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

namespace Order_App
{
    public partial class Order : Form
    {
        List<OrderItem> list = new List<OrderItem>();
        DataSet dataset;

        public class OrderClass
        {

            private List<OrderItem> list = new List<OrderItem>();

            internal List<OrderItem> List { get => list; set => list = value; }
        }

        public Order()
        {
            InitializeComponent();
            
        }

        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockListDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.stockListDataSet.Stock);
            lblDescription02.Text = "Description";
            lblPackSize02.Text = "PackSize";
            lblStockCode02.Text = "StockCode";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //CODE GOES HERE
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CODE GOES HERE
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lblDescription02.Text = row.Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString();
                lblPackSize02.Text = row.Cells["packSizeDataGridViewTextBoxColumn"].Value.ToString();
                lblStockCode02.Text = row.Cells["stockCodeDataGridViewTextBoxColumn"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblDescription02.Text == "Description" || lblPackSize02.Text == "PackSize" || lblStockCode02.Text == "StockCode" || tbxQuantity.Text == "")
            {
                MessageBox.Show("You Must Select A Stock Item From The Table First", "Error: Stock Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (Int32.Parse(tbxQuantity.Text) <= 0)
            {
                MessageBox.Show("Quantity Ordered Should Be More Than Zero", "Error: Stock Ordered Negative or Zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                OrderItem orderItem = new OrderItem
                {
                    description = lblDescription02.Text,
                    packSize = lblPackSize02.Text,
                    quantity = Int32.Parse(tbxQuantity.Text),
                    stockCode = lblStockCode02.Text
                };

                list.Add(orderItem);
                tbxQuantity.Text = "";
                lblDescription02.Text = "Description";
                lblPackSize02.Text = "PackSize";
                lblStockCode02.Text = "StockCode";
            }

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            

        }

        private void btnNext_MouseClick(object sender, MouseEventArgs e)
        {
            OrderClass orderClass = new OrderClass();
            orderClass.List = list;
            Form2 form2 = new Form2(orderClass);
            form2.Show();
            this.Close();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stockTableAdapter.FillBy(this.stockListDataSet.Stock);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void searchByDescriptionToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stockTableAdapter.SearchByDescription(this.stockListDataSet.Stock, descriptionToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to cancel order?", "Cancel Order", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.stockTableAdapter.DeleteQuery();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter="Excel Workbook|*.xls", ValidateNames=true
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    dataset = reader.AsDataSet();
                    reader.Close();
                }
            }
        }
    }
}
