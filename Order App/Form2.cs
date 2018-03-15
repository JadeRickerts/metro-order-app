using System;
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
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            try
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream("Order.pdf", FileMode.Create));
                document.Open();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message, "PDF Writer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Header
            Paragraph heading = new Paragraph();
            heading.Alignment = Element.ALIGN_LEFT;
            heading.Add("Date: 13/12/2017");
            heading.Add("\nCustomer Name: ABC Stationers");
            heading.Add("\nCustomer Email: abc@stationers.com\n");
            heading.Add("\n");
            document.Add(heading);

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string username = "metro-order-app@code-beta.com";
            const string password = "sefalana216009";
            string smtp = "mail.code-beta.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("metro-order-app@code-beta.com");
            mail.To.Add(new MailAddress("jade.rickerts@gmail.com"));
            mail.Subject = "testing";
            mail.Body = "this is a metro order app test mail";
            mail.Attachments.Add(new Attachment(@"c:\\metro-order-app\stock.xml"));

            SmtpClient smtpClient = new SmtpClient(smtp);
            smtpClient.Port = 26;
            smtpClient.Credentials = new System.Net.NetworkCredential(username, password);
            smtpClient.EnableSsl = false;
            smtpClient.Send(mail);
            MessageBox.Show("Mail Sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
