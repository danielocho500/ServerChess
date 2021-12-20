using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    public class SendEmail
    {
        public static bool Send(string email, string code, string username)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("superchess351@gmail.com");
            mail.Sender = new MailAddress("superchess351@gmail.com");
            mail.To.Add(email);
            mail.IsBodyHtml = true;
            mail.Subject = "Account Code for SuperChess";
            mail.Body = "Congratulations " + username +  ", it is only one step to play superchess, put this code in the application: \n"+ code;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("superchess351@gmail.com", "ifyv4W4W1nuQ");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            smtp.Timeout = 30000;
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
