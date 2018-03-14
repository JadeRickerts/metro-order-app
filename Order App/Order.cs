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
        
        //=======================================================================================================================//

        public class OrderClass
        {

            private List<OrderItem> list = new List<OrderItem>();

            internal List<OrderItem> List { get => list; set => list = value; }
        }

        public Order()
        {
            InitializeComponent();
        }

        //LOAD FORM WITH DEFAULT VALUES
        private void Order_Load(object sender, EventArgs e)
        {
            lblDescription02.Text = "Description";
            lblPackSize02.Text = "PackSize";
            lblStockCode02.Text = "StockCode";
        }

        //SELECTING STOCK ITEM LOGIC
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lblDescription02.Text = row.Cells[1].Value.ToString();
                lblPackSize02.Text = row.Cells[2].Value.ToString();
                lblStockCode02.Text = row.Cells[0].Value.ToString();
            }
        }

        //SAVING STOCK ITEM TO ORDER LOGIC
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

        //COMPLETE ORDERING PROCESS
        private void btnNext_MouseClick(object sender, MouseEventArgs e)
        {
            OrderClass orderClass = new OrderClass();
            orderClass.List = list;
            Form2 form2 = new Form2(orderClass);
            form2.Show();
            this.Close();
        }
        
        //SEARCH BY DESCRIPTION LOGIC
        private void searchByDescriptionToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.stockTableAdapter.SearchByDescription(this.stockListDataSet.Stock, descriptionToolStripTextBox.Text);
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        //CANCEL ORDERING PROCESS
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

        //LOAD STOCK FILE LOGIC
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = "C:\\metro-order-app\\stock.xml";
            DataSet ds = new DataSet();
            //Reading XML file and copying to dataset
            ds.ReadXml(path);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "StockTable";
        }

        //=======================================================================================================================//
        //UNUSED CODE THAT I CAN'T DELETE OR COMMENT OUT
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //CODE GOES HERE
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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }
        //=======================================================================================================================//

    }
}
