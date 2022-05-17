using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace Shop
{
    public class EmailService
    {
        private readonly ILogger<EmailService> logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this.logger = logger;
        }

        public void SendEmail(string email, string subject, string message)
        {
            try
            {
                MimeMessage Message = new MimeMessage();

                Message.From.Add(new MailboxAddress("Бот русмет", "islam.ibrai33@gmail.com"));
                //emailMessage.To.Add(new MailboxAddress("", email));
                Message.To.Add(new MailboxAddress("","rokudenas@bk.ru"));
                Message.Subject = subject;
                Message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.ru", 465, true);
                    client.Authenticate("islam.ibrai33@gmail.com", "Yumn0klu");
                    client.Send(Message);

                    client.DisconnectAsync(true);
                    logger.LogInformation("Сообщение успешно отправлено");
                }                
            }
            catch(Exception ex)
            {
                logger.LogError(ex.GetBaseException().Message);
            }
        }


    }
}