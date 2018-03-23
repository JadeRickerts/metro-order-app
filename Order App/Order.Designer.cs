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
            this.lblPackSize02 = new System.Windows.Forms.Label();
            this.lblDescription02 = new System.Windows.Forms.Label();
            this.lblStockCode02 = new System.Windows.Forms.Label();
            this.lblStockCode01 = new System.Windows.Forms.Label();
            this.searchByDescriptionToolStrip = new System.Windows.Forms.ToolStrip();
            this.descriptionToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.descriptionToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchByDescriptionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.searchByDescriptionToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(860, 385);
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
            this.btnAdd.Location = new System.Drawing.Point(185, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(310, 26);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add To Order";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Green;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(700, 499);
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
            this.btnCancel.Location = new System.Drawing.Point(519, 499);
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
            this.tbxQuantity.Location = new System.Drawing.Point(123, 92);
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(40, 26);
            this.tbxQuantity.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.lblPackSize01);
            this.groupBox1.Controls.Add(this.lblDescription01);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblPackSize02);
            this.groupBox1.Controls.Add(this.tbxQuantity);
            this.groupBox1.Controls.Add(this.lblDescription02);
            this.groupBox1.Controls.Add(this.lblStockCode02);
            this.groupBox1.Controls.Add(this.lblStockCode01);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 130);
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
            // lblPackSize02
            // 
            this.lblPackSize02.AutoSize = true;
            this.lblPackSize02.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackSize02.Location = new System.Drawing.Point(119, 69);
            this.lblPackSize02.Name = "lblPackSize02";
            this.lblPackSize02.Size = new System.Drawing.Size(72, 20);
            this.lblPackSize02.TabIndex = 0;
            this.lblPackSize02.Text = "99x9999aa";
            // 
            // lblDescription02
            // 
            this.lblDescription02.AutoSize = true;
            this.lblDescription02.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.lblDescription02.Location = new System.Drawing.Point(119, 46);
            this.lblDescription02.Name = "lblDescription02";
            this.lblDescription02.Size = new System.Drawing.Size(194, 20);
            this.lblDescription02.TabIndex = 0;
            this.lblDescription02.Text = "Product Description Goes here";
            // 
            // lblStockCode02
            // 
            this.lblStockCode02.AutoSize = true;
            this.lblStockCode02.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockCode02.Location = new System.Drawing.Point(119, 23);
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
            // searchByDescriptionToolStrip
            // 
            this.searchByDescriptionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptionToolStripLabel,
            this.descriptionToolStripTextBox,
            this.searchByDescriptionToolStripButton});
            this.searchByDescriptionToolStrip.Location = new System.Drawing.Point(0, 0);
            this.searchByDescriptionToolStrip.Name = "searchByDescriptionToolStrip";
            this.searchByDescriptionToolStrip.Size = new System.Drawing.Size(884, 25);
            this.searchByDescriptionToolStrip.TabIndex = 5;
            this.searchByDescriptionToolStrip.Text = "searchByDescriptionToolStrip";
            // 
            // descriptionToolStripLabel
            // 
            this.descriptionToolStripLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionToolStripLabel.Name = "descriptionToolStripLabel";
            this.descriptionToolStripLabel.Size = new System.Drawing.Size(142, 22);
            this.descriptionToolStripLabel.Text = "Search By Description:";
            // 
            // descriptionToolStripTextBox
            // 
            this.descriptionToolStripTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.descriptionToolStripTextBox.Name = "descriptionToolStripTextBox";
            this.descriptionToolStripTextBox.Size = new System.Drawing.Size(600, 25);
            // 
            // searchByDescriptionToolStripButton
            // 
            this.searchByDescriptionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchByDescriptionToolStripButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.searchByDescriptionToolStripButton.Name = "searchByDescriptionToolStripButton";
            this.searchByDescriptionToolStripButton.Size = new System.Drawing.Size(53, 22);
            this.searchByDescriptionToolStripButton.Text = "Search";
            this.searchByDescriptionToolStripButton.Click += new System.EventHandler(this.searchByDescriptionToolStripButton_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Orange;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Location = new System.Drawing.Point(519, 428);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(353, 65);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Stock File";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.searchByDescriptionToolStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoad);
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
            this.searchByDescriptionToolStrip.ResumeLayout(false);
            this.searchByDescriptionToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStrip searchByDescriptionToolStrip;
        private System.Windows.Forms.ToolStripLabel descriptionToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox descriptionToolStripTextBox;
        private System.Windows.Forms.ToolStripButton searchByDescriptionToolStripButton;
        private System.Windows.Forms.Button btnLoad;
    }
}