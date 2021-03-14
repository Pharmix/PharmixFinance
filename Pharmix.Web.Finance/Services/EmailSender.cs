using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Pharmix.Web.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.Run(() => { SendEmail(email, subject, message); });
        }

        /*
         *    return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
         */

        public bool SendEmail(string email, string subject, string message)
        {
            try
            {
                MailMessage msz = new MailMessage
                {
                    From = new MailAddress("contact.web@pharmix.co.uk", subject),//Email which you are getting from contact us page 
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                msz.To.Add(email);//Where mail will be sent  
                SmtpClient smtp = new SmtpClient
                {
                    Host = "send.one.com",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("contact.web@pharmix.co.uk", "Pharmix123#"),
                    EnableSsl = true
                };

                smtp.Send(msz);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
