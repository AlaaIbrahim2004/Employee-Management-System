using System.Net;
using System.Net.Mail;

namespace Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("alaamelk5@gmail.com", "bsxz wteb qqif gaor");
            client.Send("alaamelk5@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
