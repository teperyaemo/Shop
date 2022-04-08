using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace SocialApp.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Бот русмет", "zakharova-liudmila.917@mail.ru"));
            //emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.To.Add(new MailboxAddress("", "rokudenas@bk.ru"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, false);
                await client.AuthenticateAsync("zakharova-liudmila.917@mail.ru", "Yumn0klu");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}