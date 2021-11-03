using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;  
using System.Threading.Tasks;

namespace CorsacTechTask.Helpers
{
    public static class MailHelper
    {
        public static async Task Send(MailSendModel model)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("System", "system@test.com"));
            emailMessage.To.Add(new MailboxAddress(model.NameTo, model.EmailTo));
            emailMessage.Subject = model.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = model.HtmlBody;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                var secureSocketOptions = SecureSocketOptions.None;
                client.Connect("localhost", 25, secureSocketOptions);
                await client.SendAsync(emailMessage);
                client.Disconnect(true);
            }
        }
    }
    public class MailSendModel
    {
        public string EmailTo { get; set; }
        public string NameTo { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
    }
}
