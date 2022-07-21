using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailOption emailOptions { get; set; }
        public EmailSender(IOptions<EmailOption> _emailoptions) 
        {
            emailOptions = _emailoptions.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(emailOptions.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@spartk.com", "Spark Auto"),
                Subject = subject,
                PlainTextContent=htmlMessage,
                HtmlContent=htmlMessage

            };

            msg.AddTo(new EmailAddress(email));
            try
            {
                return client.SendEmailAsync(msg);
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
