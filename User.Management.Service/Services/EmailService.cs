using MimeKit;
using MailKit.Net.Smtp;
using User.Management.Service.Models;
using NETCore.MailKit;


namespace User.Management.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        private readonly IMailKitProvider _mailKitProvider;

        public EmailService(EmailConfiguration emailConfig, IMailKitProvider mailKitProvider)
        {
            _emailConfig = emailConfig;
            _mailKitProvider = mailKitProvider ?? throw new ArgumentNullException(nameof(mailKitProvider));
        }


        public void SendEmail(Message message)
        {
           var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text=message.Content };
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();

            }

        }

    }
}
