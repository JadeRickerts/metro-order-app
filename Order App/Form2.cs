﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;

namespace Order_App
{
    public partial class Form2 : Form
    {
        public Form2(Order.OrderClass orderClass)
        {
            InitializeComponent();
            dataGridView1.DataSource = orderClass.List;
            tbxTo.Enabled = false;
            tbxTo.Text = Properties.Settings.Default["PreferredStore"].ToString();
            checkBox1.CheckState = CheckState.Unchecked;
            if(Properties.Settings.Default["PreferredStore"].ToString() == "")
            {
                MessageBox.Show("You Can Set Your Preferred Store At Settings", "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.CheckState = CheckState.Checked;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Order As PDF";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "PDF Documents |*.pdf";
            saveFileDialog.FilterIndex = 2;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintPDF(saveFileDialog.FileName);
                MessageBox.Show("Order Saved As PDF", "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel.Text = "Close";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(tbxComment.Text == "Add Comment To Order")
            {
                tbxComment.Text = "";
            }
            try
            {
                string file = Directory.GetCurrentDirectory().ToString() + @"\Order.pdf";
                PrintPDF(file);
                string username = Properties.Settings.Default["SMTPUsername"].ToString();
                string password = Properties.Settings.Default["SMTPPassword"].ToString();
                string smtp = Properties.Settings.Default["SMTPServerName"].ToString();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(username);
                mail.To.Add(new MailAddress(tbxTo.Text));
                if (cbxSendCopy.CheckState == CheckState.Checked)
                {
                    mail.Bcc.Add(new MailAddress(Properties.Settings.Default["EmailAddress"].ToString()));
                }
                mail.Subject = "Metro Order App";
                mail.Body = string.Format("Good day\n\nPlease find attached order from {0}.\n\n{1}", Properties.Settings.Default["CustomerName"].ToString(), tbxComment.Text);
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
                tbxComment.Text = "Add Comment To Order";
                MessageBox.Show("Mail Sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Checked)
            {
                tbxTo.Enabled = true;
                tbxTo.Text = "";
            } else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                tbxTo.Enabled = false;
                if (Properties.Settings.Default["PreferredStore"].ToString() != "")
                {
                    tbxTo.Text = Properties.Settings.Default["PreferredStore"].ToString();
                }
            }
        }

        private void tbxComment_TextChanged(object sender, EventArgs e)
        {
            //CODE GOES HERE
        }
    }
}
