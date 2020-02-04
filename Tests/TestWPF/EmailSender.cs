using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    public class EmailSender
    {
        public string ServerAddress { get; set; }

        public int ServerPort { get; set; }

        public string User { get; set; }

        public SecureString Password { get; set; }

        public EmailSender(string serverAddress, int serverPort, string user, SecureString password)
        {
            ServerAddress = serverAddress;
            ServerPort = serverPort;
            User = user;
            Password = password;
        }

        public void Send(string from, string to, Message message)
        {
            using (var mailMessage = new MailMessage(from, to))
            {
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;

                using (var client = new SmtpClient(YandexServer.Address, YandexServer.Port))
                {
                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential(User, Password);

                    client.Send(mailMessage);
                }
            }
        }
    }
}
