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
        //FORM VARIABLES
        BindingSource bindingSource = new BindingSource();
        OrderClass orderClass = new OrderClass();

        //ORDER CLASS DEFINITION
        public class OrderClass
        {

            private List<OrderItem> list = new List<OrderItem>();

            internal List<OrderItem> List { get => list; set => list = value; }
        }

        //FORM INITIALIZATION WITH NO PARAMETERS
        public Order()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FORM INITIALIZATION WITH PARAMETERS
        public Order(OrderClass order)
        {
            try
            {
                InitializeComponent();
                orderClass = order;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD FORM WITH DEFAULT VALUES
        private void Order_Load(object sender, EventArgs e)
        {
            lblDescription02.Text = "Description";
            lblPackSize02.Text = "PackSize";
            lblStockCode02.Text = "StockCode";

            try
            {
                string path = Properties.Settings.Default["XMLStockFile"].ToString();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dataTable = new DataTable();
                dataTable = dataSet.Tables[0];

                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 500;
                dataGridView1.Columns[3].Width = 100;
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SELECTING STOCK ITEM LOGIC
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    lblDescription02.Text = row.Cells[2].Value.ToString();
                    lblPackSize02.Text = row.Cells[3].Value.ToString();
                    lblStockCode02.Text = row.Cells[1].Value.ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //SAVING STOCK ITEM TO ORDER LOGIC
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDescription02.Text == "Description" || lblPackSize02.Text == "PackSize" || lblStockCode02.Text == "StockCode" || tbxQuantity.Text == "")
                {
                    MessageBox.Show("You Must Select A Stock Item From The Table First", "Error: Stock Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Int32.Parse(tbxQuantity.Text) <= 0)
                {
                    MessageBox.Show("Quantity Ordered Should Be More Than Zero", "Error: Stock Ordered Negative or Zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OrderItem orderItem = new OrderItem
                    {
                        description = lblDescription02.Text,
                        packSize = lblPackSize02.Text,
                        quantity = Int32.Parse(tbxQuantity.Text),
                        stockCode = lblStockCode02.Text
                    };
                    orderClass.List.Add(orderItem);
                    btnNext.Visible = true;
                    tbxQuantity.Text = "";
                    lblDescription02.Text = "Description";
                    lblPackSize02.Text = "PackSize";
                    lblStockCode02.Text = "StockCode";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //COMPLETE ORDERING PROCESS
        private void btnNext_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Form2 form2 = new Form2(orderClass);
                form2.Show();
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //SEARCH BY DESCRIPTION LOGIC
        private void searchByDescriptionToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        //CANCEL ORDERING PROCESS
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to cancel order?", "Cancel Order", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool startup = false;
                    this.Close();
                    MainMenu mainMenu = new MainMenu(startup);
                    mainMenu.Show();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LOAD STOCK FILE LOGIC
        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void tbxSearch_MouseClick(object sender, MouseEventArgs e)
        {
            tbxSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.Filter = string.Format("Description like '%{0}%'", tbxSearch.Text);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
