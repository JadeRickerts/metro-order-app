namespace Order_App
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPackSize01 = new System.Windows.Forms.Label();
            this.lblDescription01 = new System.Windows.Forms.Label();
            this.btnLoadStockTable = new System.Windows.Forms.Button();
            this.lblPackSize02 = new System.Windows.Forms.Label();
            this.lblDescription02 = new System.Windows.Forms.Label();
            this.lblStockCode02 = new System.Windows.Forms.Label();
            this.lblStockCode01 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(860, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataMember = "Stock";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(215, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(280, 26);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add to Order";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Green;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(700, 599);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(172, 50);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Finish Ordering";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNext_MouseClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(519, 599);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel Order";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.tbxQuantity.Location = new System.Drawing.Point(169, 91);
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(40, 26);
            this.tbxQuantity.TabIndex = 1;
            this.tbxQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxQuantity_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.lblPackSize01);
            this.groupBox1.Controls.Add(this.lblDescription01);
            this.groupBox1.Controls.Add(this.btnLoadStockTable);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblPackSize02);
            this.groupBox1.Controls.Add(this.tbxQuantity);
            this.groupBox1.Controls.Add(this.lblDescription02);
            this.groupBox1.Controls.Add(this.lblStockCode02);
            this.groupBox1.Controls.Add(this.lblStockCode01);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Order Information";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(7, 92);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(79, 23);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblPackSize01
            // 
            this.lblPackSize01.AutoSize = true;
            this.lblPackSize01.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackSize01.Location = new System.Drawing.Point(7, 66);
            this.lblPackSize01.Name = "lblPackSize01";
            this.lblPackSize01.Size = new System.Drawing.Size(87, 23);
            this.lblPackSize01.TabIndex = 0;
            this.lblPackSize01.Text = "Pack Size:";
            // 
            // lblDescription01
            // 
            this.lblDescription01.AutoSize = true;
            this.lblDescription01.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription01.Location = new System.Drawing.Point(7, 43);
            this.lblDescription01.Name = "lblDescription01";
            this.lblDescription01.Size = new System.Drawing.Size(102, 23);
            this.lblDescription01.TabIndex = 0;
            this.lblDescription01.Text = "Description:";
            // 
            // btnLoadStockTable
            // 
            this.btnLoadStockTable.BackColor = System.Drawing.Color.Green;
            this.btnLoadStockTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadStockTable.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadStockTable.Location = new System.Drawing.Point(574, 92);
            this.btnLoadStockTable.Name = "btnLoadStockTable";
            this.btnLoadStockTable.Size = new System.Drawing.Size(280, 26);
            this.btnLoadStockTable.TabIndex = 5;
            this.btnLoadStockTable.Text = "Load Stock Table";
            this.btnLoadStockTable.UseVisualStyleBackColor = false;
            this.btnLoadStockTable.Visible = false;
            this.btnLoadStockTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnLoadStockTable_MouseClick);
            // 
            // lblPackSize02
            // 
            this.lblPackSize02.AutoSize = true;
            this.lblPackSize02.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackSize02.Location = new System.Drawing.Point(165, 69);
            this.lblPackSize02.Name = "lblPackSize02";
            this.lblPackSize02.Size = new System.Drawing.Size(72, 20);
            this.lblPackSize02.TabIndex = 0;
            this.lblPackSize02.Text = "99x9999aa";
            // 
            // lblDescription02
            // 
            this.lblDescription02.AutoSize = true;
            this.lblDescription02.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.lblDescription02.Location = new System.Drawing.Point(165, 46);
            this.lblDescription02.Name = "lblDescription02";
            this.lblDescription02.Size = new System.Drawing.Size(194, 20);
            this.lblDescription02.TabIndex = 0;
            this.lblDescription02.Text = "Product Description Goes here";
            // 
            // lblStockCode02
            // 
            this.lblStockCode02.AutoSize = true;
            this.lblStockCode02.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockCode02.Location = new System.Drawing.Point(165, 23);
            this.lblStockCode02.Name = "lblStockCode02";
            this.lblStockCode02.Size = new System.Drawing.Size(44, 20);
            this.lblStockCode02.TabIndex = 0;
            this.lblStockCode02.Text = "99999";
            // 
            // lblStockCode01
            // 
            this.lblStockCode01.AutoSize = true;
            this.lblStockCode01.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockCode01.Location = new System.Drawing.Point(7, 20);
            this.lblStockCode01.Name = "lblStockCode01";
            this.lblStockCode01.Size = new System.Drawing.Size(102, 23);
            this.lblStockCode01.TabIndex = 0;
            this.lblStockCode01.Text = "Stock Code:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.tbxSearch);
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(860, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Stock";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(574, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(280, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.tbxSearch.Location = new System.Drawing.Point(169, 16);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(399, 26);
            this.tbxSearch.TabIndex = 1;
            this.tbxSearch.Text = "Search by Description";
            this.tbxSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxSearch_MouseClick);
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(7, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 599);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(175, 50);
            this.progressBar.TabIndex = 6;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Order";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        //private StockListDataSet stockListDataSet;
        private System.Windows.Forms.BindingSource stockBindingSource;
        //private StockListDataSetTableAdapters.StockTableAdapter stockTableAdapter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPackSize01;
        private System.Windows.Forms.Label lblDescription01;
        private System.Windows.Forms.Label lblPackSize02;
        private System.Windows.Forms.Label lblDescription02;
        private System.Windows.Forms.Label lblStockCode02;
        private System.Windows.Forms.Label lblStockCode01;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnLoadStockTable;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}