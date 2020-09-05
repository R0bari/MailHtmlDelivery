using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Finances.ServiceLayer.Helpers
{
    public class MailDelivery
    {
        /// <summary>
        /// Your mail address before '@'
        /// </summary>
        public string Login { get; private set; }
        /// <summary>
        /// Your mail address password
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// Html file to send
        /// </summary>
        public string HtmlPath { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlPath">Html file path</param>
        /// <param name="login">Your mail address before '@'</param>
        /// <param name="password">Your mail address password</param>
        public MailDelivery(string htmlPath, string login, string password)
        {
            HtmlPath = htmlPath;
            Login = login;
            Password = password;
        }
        /// <summary>
        /// Sends html file.
        /// Throws Exception if authentification failed
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void Send(string from, string to)
        {
            MailAddress addressFrom = new MailAddress(from);
            MailAddress addressTo = new MailAddress(to);
            MailMessage message = new MailMessage(addressFrom, addressTo)
            {
                Subject = "Письмо от MailDelivery",
                Body = GetMessageBodyFromHtml(),
                IsBodyHtml = true
            };
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587)
            {
                Credentials = new NetworkCredential(Login, Password),
                EnableSsl = true
            };
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }

        }
        public string GetMessageBodyFromHtml() => new StreamReader(HtmlPath).ReadToEnd();
    }

}