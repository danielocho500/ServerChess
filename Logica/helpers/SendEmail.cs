/******************************************************************/
/* Archivo: SendEmail.cs                                          */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  18/Oct/2021                               */
/* Descripción: Envia codigo a correo                             */
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    public  class SendEmail
    {
        public static bool Send(string email, string code, string username)
        {

            if (email.Trim().EndsWith("."))
            {
                return false; 
            }
            try
            {
                new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                return false;
            }

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
