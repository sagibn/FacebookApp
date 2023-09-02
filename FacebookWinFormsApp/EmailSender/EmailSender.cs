using System;
using System.Net;
using System.Net.Mail;

namespace BasicFacebookFeatures.EmailSender
{
    public sealed class EmailSender
    {
        private static EmailSender s_Instance = null;
        private readonly string r_SmtpServer;
        private readonly string r_SenderEmail;
        private readonly string r_SenderPassword;
        private readonly int r_smtpPort;
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }

        private EmailSender()
        {
            r_SmtpServer = "smtp.gmail.com";
            r_smtpPort = 587;
            r_SenderEmail = "desigpatter57@gmail.com";
            r_SenderPassword = "qeoizhtqipjlywyv";
        }

        public static EmailSender Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new EmailSender();
                }

                return s_Instance;
            }
        }
        public string SendEmail(string i_Body)
        {
            string message;

            try
            {
                MailMessage mail = new MailMessage(r_SenderEmail, RecipientEmail, Subject, i_Body);
                SmtpClient client = new SmtpClient(r_SmtpServer, r_smtpPort)
                {
                    Credentials = new NetworkCredential(r_SenderEmail, r_SenderPassword),
                    EnableSsl = true
                };

                client.Send(mail);
                message = $"Email sent successfully to {RecipientEmail}.";
            }
            catch (Exception ex)
            {
                message = $"Failed to send email: {ex.Message}";
            }

            return message;
        }
    }
}
