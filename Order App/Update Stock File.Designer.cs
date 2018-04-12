namespace Order_App
{
    partial class Form3
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDownloadProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Green;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(374, 77);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(175, 50);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Download Update";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(193, 77);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(175, 50);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Check For Updates";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 28);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(537, 30);
            this.progressBar.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(12, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 50);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDownloadProgress
            // 
            this.lblDownloadProgress.AutoSize = true;
            this.lblDownloadProgress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadProgress.Location = new System.Drawing.Point(220, 9);
            this.lblDownloadProgress.Name = "lblDownloadProgress";
            this.lblDownloadProgress.Size = new System.Drawing.Size(120, 16);
            this.lblDownloadProgress.TabIndex = 4;
            this.lblDownloadProgress.Text = "Download Progress";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 142);
            this.Controls.Add(this.lblDownloadProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnOpen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Stock File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDownloadProgress;
    }
}