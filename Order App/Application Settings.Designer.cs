namespace Order_App
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxDatabaseInfo = new System.Windows.Forms.GroupBox();
            this.tbxStoreURL = new System.Windows.Forms.TextBox();
            this.tbxStockURL = new System.Windows.Forms.TextBox();
            this.tbxStoreLoc = new System.Windows.Forms.TextBox();
            this.lblStoreURL = new System.Windows.Forms.Label();
            this.tbxStockLoc = new System.Windows.Forms.TextBox();
            this.lblStockURL = new System.Windows.Forms.Label();
            this.lblStoreLoc = new System.Windows.Forms.Label();
            this.lblStockLoc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxStartUp = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxAppSettingsPwd = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxSSL = new System.Windows.Forms.CheckBox();
            this.tbxSMTPPassword = new System.Windows.Forms.TextBox();
            this.tbxSMTPUsername = new System.Windows.Forms.TextBox();
            this.tbxSMTPPort = new System.Windows.Forms.TextBox();
            this.lblSSL = new System.Windows.Forms.Label();
            this.lblSMTPPassword = new System.Windows.Forms.Label();
            this.tbxSMTPServer = new System.Windows.Forms.TextBox();
            this.lblSMTPUsername = new System.Windows.Forms.Label();
            this.lblSMTPPort = new System.Windows.Forms.Label();
            this.lblSMTPServer = new System.Windows.Forms.Label();
            this.lblLastStockUpdate1 = new System.Windows.Forms.Label();
            this.lblLastStoreUpdate1 = new System.Windows.Forms.Label();
            this.lblLastStockUpdate2 = new System.Windows.Forms.Label();
            this.lblLastStoreUpdate2 = new System.Windows.Forms.Label();
            this.gbxDatabaseInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application Settings";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(216, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 50);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(397, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 50);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxDatabaseInfo
            // 
            this.gbxDatabaseInfo.Controls.Add(this.tbxStoreURL);
            this.gbxDatabaseInfo.Controls.Add(this.tbxStockURL);
            this.gbxDatabaseInfo.Controls.Add(this.tbxStoreLoc);
            this.gbxDatabaseInfo.Controls.Add(this.lblStoreURL);
            this.gbxDatabaseInfo.Controls.Add(this.tbxStockLoc);
            this.gbxDatabaseInfo.Controls.Add(this.lblStockURL);
            this.gbxDatabaseInfo.Controls.Add(this.lblStoreLoc);
            this.gbxDatabaseInfo.Controls.Add(this.lblStockLoc);
            this.gbxDatabaseInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatabaseInfo.Location = new System.Drawing.Point(16, 36);
            this.gbxDatabaseInfo.Name = "gbxDatabaseInfo";
            this.gbxDatabaseInfo.Size = new System.Drawing.Size(656, 142);
            this.gbxDatabaseInfo.TabIndex = 4;
            this.gbxDatabaseInfo.TabStop = false;
            this.gbxDatabaseInfo.Text = "Application File Information";
            // 
            // tbxStoreURL
            // 
            this.tbxStoreURL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStoreURL.Location = new System.Drawing.Point(320, 112);
            this.tbxStoreURL.Name = "tbxStoreURL";
            this.tbxStoreURL.Size = new System.Drawing.Size(330, 22);
            this.tbxStoreURL.TabIndex = 4;
            // 
            // tbxStockURL
            // 
            this.tbxStockURL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStockURL.Location = new System.Drawing.Point(320, 84);
            this.tbxStockURL.Name = "tbxStockURL";
            this.tbxStockURL.Size = new System.Drawing.Size(330, 22);
            this.tbxStockURL.TabIndex = 3;
            // 
            // tbxStoreLoc
            // 
            this.tbxStoreLoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStoreLoc.Location = new System.Drawing.Point(320, 56);
            this.tbxStoreLoc.Name = "tbxStoreLoc";
            this.tbxStoreLoc.Size = new System.Drawing.Size(330, 22);
            this.tbxStoreLoc.TabIndex = 2;
            // 
            // lblStoreURL
            // 
            this.lblStoreURL.AutoSize = true;
            this.lblStoreURL.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreURL.Location = new System.Drawing.Point(6, 115);
            this.lblStoreURL.Name = "lblStoreURL";
            this.lblStoreURL.Size = new System.Drawing.Size(89, 16);
            this.lblStoreURL.TabIndex = 3;
            this.lblStoreURL.Text = "Store File URL:";
            // 
            // tbxStockLoc
            // 
            this.tbxStockLoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStockLoc.Location = new System.Drawing.Point(320, 28);
            this.tbxStockLoc.Name = "tbxStockLoc";
            this.tbxStockLoc.Size = new System.Drawing.Size(330, 22);
            this.tbxStockLoc.TabIndex = 1;
            // 
            // lblStockURL
            // 
            this.lblStockURL.AutoSize = true;
            this.lblStockURL.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockURL.Location = new System.Drawing.Point(6, 87);
            this.lblStockURL.Name = "lblStockURL";
            this.lblStockURL.Size = new System.Drawing.Size(91, 16);
            this.lblStockURL.TabIndex = 4;
            this.lblStockURL.Text = "Stock File URL:";
            // 
            // lblStoreLoc
            // 
            this.lblStoreLoc.AutoSize = true;
            this.lblStoreLoc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreLoc.Location = new System.Drawing.Point(6, 59);
            this.lblStoreLoc.Name = "lblStoreLoc";
            this.lblStoreLoc.Size = new System.Drawing.Size(148, 16);
            this.lblStoreLoc.TabIndex = 5;
            this.lblStoreLoc.Text = "Local Store File Location: ";
            // 
            // lblStockLoc
            // 
            this.lblStockLoc.AutoSize = true;
            this.lblStockLoc.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLoc.Location = new System.Drawing.Point(6, 31);
            this.lblStockLoc.Name = "lblStockLoc";
            this.lblStockLoc.Size = new System.Drawing.Size(150, 16);
            this.lblStockLoc.TabIndex = 6;
            this.lblStockLoc.Text = "Local Stock File Location: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxStartUp);
            this.groupBox1.Controls.Add(this.lblLastStoreUpdate2);
            this.groupBox1.Controls.Add(this.lblLastStoreUpdate1);
            this.groupBox1.Controls.Add(this.lblLastStockUpdate2);
            this.groupBox1.Controls.Add(this.lblLastStockUpdate1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxAppSettingsPwd);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Information";
            // 
            // cbxStartUp
            // 
            this.cbxStartUp.AutoSize = true;
            this.cbxStartUp.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStartUp.Location = new System.Drawing.Point(318, 98);
            this.cbxStartUp.Name = "cbxStartUp";
            this.cbxStartUp.Size = new System.Drawing.Size(65, 20);
            this.cbxStartUp.TabIndex = 12;
            this.cbxStartUp.Text = "Start Up";
            this.cbxStartUp.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Application Settings Password: ";
            // 
            // tbxAppSettingsPwd
            // 
            this.tbxAppSettingsPwd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAppSettingsPwd.Location = new System.Drawing.Point(318, 25);
            this.tbxAppSettingsPwd.Name = "tbxAppSettingsPwd";
            this.tbxAppSettingsPwd.Size = new System.Drawing.Size(332, 22);
            this.tbxAppSettingsPwd.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxSSL);
            this.groupBox2.Controls.Add(this.tbxSMTPPassword);
            this.groupBox2.Controls.Add(this.tbxSMTPUsername);
            this.groupBox2.Controls.Add(this.tbxSMTPPort);
            this.groupBox2.Controls.Add(this.lblSSL);
            this.groupBox2.Controls.Add(this.lblSMTPPassword);
            this.groupBox2.Controls.Add(this.tbxSMTPServer);
            this.groupBox2.Controls.Add(this.lblSMTPUsername);
            this.groupBox2.Controls.Add(this.lblSMTPPort);
            this.groupBox2.Controls.Add(this.lblSMTPServer);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 169);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Information";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cbxSSL
            // 
            this.cbxSSL.AutoSize = true;
            this.cbxSSL.Location = new System.Drawing.Point(318, 144);
            this.cbxSSL.Name = "cbxSSL";
            this.cbxSSL.Size = new System.Drawing.Size(58, 22);
            this.cbxSSL.TabIndex = 9;
            this.cbxSSL.Text = "SSL";
            this.cbxSSL.UseVisualStyleBackColor = true;
            // 
            // tbxSMTPPassword
            // 
            this.tbxSMTPPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSMTPPassword.Location = new System.Drawing.Point(320, 115);
            this.tbxSMTPPassword.Name = "tbxSMTPPassword";
            this.tbxSMTPPassword.Size = new System.Drawing.Size(330, 22);
            this.tbxSMTPPassword.TabIndex = 8;
            // 
            // tbxSMTPUsername
            // 
            this.tbxSMTPUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSMTPUsername.Location = new System.Drawing.Point(320, 87);
            this.tbxSMTPUsername.Name = "tbxSMTPUsername";
            this.tbxSMTPUsername.Size = new System.Drawing.Size(330, 22);
            this.tbxSMTPUsername.TabIndex = 7;
            // 
            // tbxSMTPPort
            // 
            this.tbxSMTPPort.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSMTPPort.Location = new System.Drawing.Point(320, 59);
            this.tbxSMTPPort.Name = "tbxSMTPPort";
            this.tbxSMTPPort.Size = new System.Drawing.Size(330, 22);
            this.tbxSMTPPort.TabIndex = 6;
            // 
            // lblSSL
            // 
            this.lblSSL.AutoSize = true;
            this.lblSSL.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSL.Location = new System.Drawing.Point(7, 140);
            this.lblSSL.Name = "lblSSL";
            this.lblSSL.Size = new System.Drawing.Size(74, 16);
            this.lblSSL.TabIndex = 3;
            this.lblSSL.Text = "SSL Enable:";
            // 
            // lblSMTPPassword
            // 
            this.lblSMTPPassword.AutoSize = true;
            this.lblSMTPPassword.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMTPPassword.Location = new System.Drawing.Point(6, 115);
            this.lblSMTPPassword.Name = "lblSMTPPassword";
            this.lblSMTPPassword.Size = new System.Drawing.Size(63, 16);
            this.lblSMTPPassword.TabIndex = 3;
            this.lblSMTPPassword.Text = "Password:";
            // 
            // tbxSMTPServer
            // 
            this.tbxSMTPServer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSMTPServer.Location = new System.Drawing.Point(320, 31);
            this.tbxSMTPServer.Name = "tbxSMTPServer";
            this.tbxSMTPServer.Size = new System.Drawing.Size(330, 22);
            this.tbxSMTPServer.TabIndex = 5;
            // 
            // lblSMTPUsername
            // 
            this.lblSMTPUsername.AutoSize = true;
            this.lblSMTPUsername.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMTPUsername.Location = new System.Drawing.Point(6, 87);
            this.lblSMTPUsername.Name = "lblSMTPUsername";
            this.lblSMTPUsername.Size = new System.Drawing.Size(64, 16);
            this.lblSMTPUsername.TabIndex = 4;
            this.lblSMTPUsername.Text = "Username:";
            // 
            // lblSMTPPort
            // 
            this.lblSMTPPort.AutoSize = true;
            this.lblSMTPPort.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMTPPort.Location = new System.Drawing.Point(6, 59);
            this.lblSMTPPort.Name = "lblSMTPPort";
            this.lblSMTPPort.Size = new System.Drawing.Size(41, 16);
            this.lblSMTPPort.TabIndex = 5;
            this.lblSMTPPort.Text = "PORT:";
            // 
            // lblSMTPServer
            // 
            this.lblSMTPServer.AutoSize = true;
            this.lblSMTPServer.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMTPServer.Location = new System.Drawing.Point(6, 31);
            this.lblSMTPServer.Name = "lblSMTPServer";
            this.lblSMTPServer.Size = new System.Drawing.Size(114, 16);
            this.lblSMTPServer.TabIndex = 6;
            this.lblSMTPServer.Text = "SMTP Server Name: ";
            // 
            // lblLastStockUpdate1
            // 
            this.lblLastStockUpdate1.AutoSize = true;
            this.lblLastStockUpdate1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastStockUpdate1.Location = new System.Drawing.Point(7, 54);
            this.lblLastStockUpdate1.Name = "lblLastStockUpdate1";
            this.lblLastStockUpdate1.Size = new System.Drawing.Size(162, 16);
            this.lblLastStockUpdate1.TabIndex = 3;
            this.lblLastStockUpdate1.Text = "Last Stock File Update Date: ";
            // 
            // lblLastStoreUpdate1
            // 
            this.lblLastStoreUpdate1.AutoSize = true;
            this.lblLastStoreUpdate1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastStoreUpdate1.Location = new System.Drawing.Point(7, 79);
            this.lblLastStoreUpdate1.Name = "lblLastStoreUpdate1";
            this.lblLastStoreUpdate1.Size = new System.Drawing.Size(161, 16);
            this.lblLastStoreUpdate1.TabIndex = 3;
            this.lblLastStoreUpdate1.Text = "Last Store FIle Update Date: ";
            // 
            // lblLastStockUpdate2
            // 
            this.lblLastStockUpdate2.AutoSize = true;
            this.lblLastStockUpdate2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastStockUpdate2.Location = new System.Drawing.Point(317, 54);
            this.lblLastStockUpdate2.Name = "lblLastStockUpdate2";
            this.lblLastStockUpdate2.Size = new System.Drawing.Size(143, 16);
            this.lblLastStockUpdate2.TabIndex = 3;
            this.lblLastStockUpdate2.Text = "Last Stock File Update Date: ";
            // 
            // lblLastStoreUpdate2
            // 
            this.lblLastStoreUpdate2.AutoSize = true;
            this.lblLastStoreUpdate2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastStoreUpdate2.Location = new System.Drawing.Point(317, 79);
            this.lblLastStoreUpdate2.Name = "lblLastStoreUpdate2";
            this.lblLastStoreUpdate2.Size = new System.Drawing.Size(144, 16);
            this.lblLastStoreUpdate2.TabIndex = 3;
            this.lblLastStoreUpdate2.Text = "Last Store FIle Update Date: ";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxDatabaseInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.gbxDatabaseInfo.ResumeLayout(false);
            this.gbxDatabaseInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxDatabaseInfo;
        private System.Windows.Forms.TextBox tbxStoreURL;
        private System.Windows.Forms.TextBox tbxStockURL;
        private System.Windows.Forms.TextBox tbxStoreLoc;
        private System.Windows.Forms.Label lblStoreURL;
        private System.Windows.Forms.TextBox tbxStockLoc;
        private System.Windows.Forms.Label lblStockURL;
        private System.Windows.Forms.Label lblStoreLoc;
        private System.Windows.Forms.Label lblStockLoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxAppSettingsPwd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxSMTPPassword;
        private System.Windows.Forms.TextBox tbxSMTPUsername;
        private System.Windows.Forms.TextBox tbxSMTPPort;
        private System.Windows.Forms.Label lblSMTPPassword;
        private System.Windows.Forms.TextBox tbxSMTPServer;
        private System.Windows.Forms.Label lblSMTPUsername;
        private System.Windows.Forms.Label lblSMTPPort;
        private System.Windows.Forms.Label lblSMTPServer;
        private System.Windows.Forms.CheckBox cbxSSL;
        private System.Windows.Forms.Label lblSSL;
        private System.Windows.Forms.CheckBox cbxStartUp;
        private System.Windows.Forms.Label lblLastStoreUpdate2;
        private System.Windows.Forms.Label lblLastStoreUpdate1;
        private System.Windows.Forms.Label lblLastStockUpdate2;
        private System.Windows.Forms.Label lblLastStockUpdate1;
    }
}