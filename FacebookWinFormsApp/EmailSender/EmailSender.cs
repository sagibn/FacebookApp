using System;
using System.Net;
using System.Net.Mail;

namespace BasicFacebookFeatures.EmailSender
{
    public class EmailSender
    {
        static public string SendEmail(string i_RecipientEmail, string i_Subject, string i_Body)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string senderEmail = "sagi838@gmail.com";
            string senderPassword = "hqygllrzkyeewtmy";
            string message;

            try
            {
                MailMessage mail = new MailMessage(senderEmail, i_RecipientEmail, i_Subject, i_Body);
                SmtpClient client = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };

                client.Send(mail);
                message = "Email sent successfully.";
            }
            catch (Exception ex)
            {
                message = $"Failed to send email: {ex.Message}";
            }

            return message;
        }
    }
}
