using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace StudentEnrolment
{
    public class Components
    {
        // Generate random ids
        public static string GenerateRandomIds()
        {
            string generatedId = string.Empty;
            string idStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int idLength = 15;
            string finalId = "";
            int getIndex;

            for (int i = 0; i <= idLength; i++)
            {
                do
                {
                    getIndex = new Random().Next(0, idStr.Length);
                    finalId = idStr.ToCharArray()[getIndex].ToString();
                } while (generatedId.IndexOf(finalId) != -1);
                generatedId += finalId;
            }

            return generatedId.ToLower();
        }

        // Send email alerts
        public static void SendEmailAlerts(string recipient, string subject, string body)
        {
            string senderEmailAddress = "wanjala.n.joel@gmail.com";
            string senderEmailPassword = "sjxo tphf xoxg zsgx";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmailAddress);
            message.Subject = subject;
            message.To.Add(new MailAddress(recipient));
            message.Body = $"<html><body>{body}</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 25;
            smtpClient.Credentials = new NetworkCredential(senderEmailAddress, senderEmailPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }

        // Check for valid names
        public static bool ValidateNames(string name)
        {
            bool isValid = false;

            string charRegex = @"^[a-zA-Z]+$";
            if (Regex.IsMatch(name, charRegex))
            {
                isValid = true;
            }

            return isValid;
        }

        // Check for valid phone numbers
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            bool isValid = false;

            string charRegex = "^[0-9]+$";
            if (Regex.IsMatch(phoneNumber, charRegex))
            {
                isValid = true;
            }

            return isValid;
        }
        // Check for valid email
        public static bool ValidateEmail(string email)
        {
            bool isValid = false;

            return isValid;
        }
    }
}