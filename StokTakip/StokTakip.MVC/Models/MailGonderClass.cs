using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace StokTakip.MVC.Models
{
    public class MailGonderClass
    {
        public static string MailGonder(string mail, string subject, string body)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("erendenemehesabi@hotmail.com", "aishklmnuoE");
            istemci.Port = 587;
            istemci.Host = "smtp.outlook.com";
            istemci.EnableSsl = true;
            mesajim.IsBodyHtml = true;
            mesajim.To.Add(mail);
            mesajim.From = new MailAddress("erendenemehesabi@hotmail.com");
            mesajim.Subject = subject;
            mesajim.Body = body;
            istemci.Send(mesajim);

            return mesajim.ToString();
        }
    }
}