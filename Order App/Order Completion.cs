using System;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.ComponentModel;

namespace Order_App
{
    public partial class Form2 : Form
    {
        //FORM VARIABLES
        Order.OrderClass oc = new Order.OrderClass();
        BackgroundWorker emailBackgroundWorker = new BackgroundWorker();
        BackgroundWorker printBackgroundWorker = new BackgroundWorker();

        //FORM INITIALIZATION
        public Form2(Order.OrderClass orderClass)
        {
            try
            {
                InitializeComponent();
                oc = orderClass;
                dataGridView1.DataSource = orderClass.List;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 500;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                tbxTo.Enabled = false;
                tbxTo.Text = Properties.Settings.Default["PreferredStore"].ToString();
                checkBox1.CheckState = CheckState.Unchecked;
                if((bool)Properties.Settings.Default["SendOrderCopy"] == true)
                {
                    cbxSendCopy.CheckState = CheckState.Checked;
                } else
                {
                    cbxSendCopy.CheckState = CheckState.Unchecked;
                }
                btnCancel.Text = "Go Back";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Completion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PRINT PDF LOGIC
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save Order As PDF";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.Filter = "PDF Documents |*.pdf";
                saveFileDialog.FilterIndex = 2;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    printBackgroundWorker.DoWork += new DoWorkEventHandler(printBackgroundWorker_DoWork);
                    printBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(printBackgroundWorker_ProgressChanged);
                    printBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printBackgroundWorker_RunWorkerCompleted);
                    printBackgroundWorker.RunWorkerAsync(saveFileDialog.FileName);
                    progressBar.Visible = true;
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progressBar.MarqueeAnimationSpeed = 50;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Completion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CLOSE FORM OR GO BACK TO ORDER LOGIC
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCancel.Text == "Go Back")
                {
                    Order order = new Order(oc);
                    order.Show();
                    this.Close();
                }
                else if (btnCancel.Text == "Close")
                {
                    bool startup = false;
                    this.Close();
                    MainMenu mainMenu = new MainMenu(startup);
                    mainMenu.Show();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Completion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SEND EMAIL LOGIC
        private void SendEmail()
        {
            try
            {
                //SMTP MAIL SERVER SETTINGS
                string file = @"C:\metro-order-app\Order.pdf";
                printBackgroundWorker.RunWorkerAsync(file);
                string username = Properties.Settings.Default["SMTPUsername"].ToString();
                string password = Properties.Settings.Default["SMTPPassword"].ToString();
                string smtp = Properties.Settings.Default["SMTPServerName"].ToString();
                string message;
                if (tbxComment.Text == "Add Comment To Order")
                {
                    message = "";
                }
                else
                {
                    message = tbxComment.Text;
                }
                //MAIL MESSAGE CONFIG
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(username);
                mail.To.Add(new MailAddress(tbxTo.Text));
                if (cbxSendCopy.CheckState == CheckState.Checked)
                {
                    mail.Bcc.Add(new MailAddress(Properties.Settings.Default["EmailAddress"].ToString()));
                }
                mail.Subject = "Metro Order App";
                mail.Body = string.Format("Good day\n\nPlease find attached order from {0}.\n\n{1}", Properties.Settings.Default["CustomerName"].ToString(), message);
                mail.Attachments.Add(new Attachment(file));
                SmtpClient smtpClient = new SmtpClient(smtp);
                smtpClient.Port = Int32.Parse(Properties.Settings.Default["SMTPPort"].ToString());
                smtpClient.Credentials = new System.Net.NetworkCredential(username, password);
                if (Properties.Settings.Default["SMTPSSL"].Equals(true))
                {
                    smtpClient.EnableSsl = true;
                }
                else
                {
                    smtpClient.EnableSsl = false;
                }
                smtpClient.Send(mail);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            emailBackgroundWorker.DoWork += new DoWorkEventHandler(emailBackgroundWorker_DoWork);
            emailBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(emailBackgroundWorker_ProgressChanged);
            emailBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(emailBackgroundWorker_RunWorkerCompleted);
            emailBackgroundWorker.RunWorkerAsync();
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 50;
        }

        private void emailBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SendEmail();
        }

        private void emailBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void emailBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            btnCancel.Text = "Close";
            MessageBox.Show("Mail Sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //PRINT PDF SETUP LOGIC METHOD
        private void PrintPDF(string file)
        {
            try
            {
                Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                try
                {
                    PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));
                    document.Open();
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message, "PDF Writer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                iTextSharp.text.Font arialBig = FontFactory.GetFont("Arial", 18);
                iTextSharp.text.Font arialSmall = FontFactory.GetFont("Arial", 12);

                //TITLE
                Paragraph title = new Paragraph();
                title.Alignment = Element.ALIGN_CENTER;
                title.Add(new Chunk("Metro Order App", arialBig));
                document.Add(title);

                //LINE
                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_CENTER, 0.0F)));
                line.Add(new Chunk("\n "));
                document.Add(line);

                //HEADER
                Paragraph heading = new Paragraph();
                heading.Alignment = Element.ALIGN_LEFT;
                heading.Add(new Chunk(string.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy")), arialSmall));
                heading.Add(new Chunk(string.Format("\nCustomer Name: {0}", Properties.Settings.Default["CustomerName"].ToString()), arialSmall));
                heading.Add(new Chunk(string.Format("\nCustomer Number: {0}", Properties.Settings.Default["ContactNumber"].ToString()), arialSmall));
                heading.Add(new Chunk(string.Format("\nCustomer Email: {0}", Properties.Settings.Default["EmailAddress"].ToString()), arialSmall));
                document.Add(heading);
                document.Add(line);

                PdfPTable pdfPTable = new PdfPTable(dataGridView1.Columns.Count);
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    pdfPTable.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
                }

                pdfPTable.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1[j, i].Value != null)
                        {
                            pdfPTable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));
                        }
                    }
                }
                document.Add(pdfPTable);
                document.Close();
                btnCancel.Text = "Close";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void printBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = (string)e.Argument;
            PrintPDF(file);
        }

        private void printBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void printBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
            btnCancel.Text = "Close";
            MessageBox.Show("Order Saved As PDF", "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //EMAIL TO SELECTION LOGIC
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    tbxTo.Enabled = true;
                    tbxTo.Text = "";
                }
                else if (checkBox1.CheckState == CheckState.Unchecked)
                {
                    tbxTo.Enabled = false;
                    if (Properties.Settings.Default["PreferredStore"].ToString() != "")
                    {
                        tbxTo.Text = Properties.Settings.Default["PreferredStore"].ToString();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Completion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
