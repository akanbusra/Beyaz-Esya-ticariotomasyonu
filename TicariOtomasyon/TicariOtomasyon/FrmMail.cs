using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TicariOtomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;
        private void FrmMaıl_Load(object sender, EventArgs e)
        {
            txtmail.Text = mail;
        }

        private void btngönder_Click(object sender, EventArgs e)
        {
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mail","şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = false;
            mesajım.To.Add(txtmail.Text);
            mesajım.From = new MailAddress("mail","Büşra");
            mesajım.Subject = txtkonu.Text;
            mesajım.Body = txtmesaj.Text;
            istemci.Send(mesajım);
        }
    }
}
