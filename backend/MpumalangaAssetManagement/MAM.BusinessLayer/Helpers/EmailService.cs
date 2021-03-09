using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MAM.BusinessLayer.Helpers
{
    public class EmailService
    {
        private AppSettings appSettings { get; set; }

        public EmailService(AppSettings settings)
        {
            appSettings = settings;
        }
        public void SendResertPasswordEmail(DataAccess.Tables.User user, string decriptedPassword)
        {
            string[] lines = { "First line", "Second line", "Third line" };
            System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", lines);
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            System.IO.File.WriteAllText(@"C:\Users\Public\WriteText.txt", text);
            using (System.IO.StreamWriter file =
       new System.IO.StreamWriter(@"C:\Users\Public\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = appSettings.EmailHost,
                Timeout = 100000,
                Port = appSettings.EmailPot,
                Credentials = new NetworkCredential(appSettings.EmailUserName, appSettings.EmailPassword),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage(appSettings.FromEmailAddress, user.Email);
            mail.Subject = "Password Reset : Asset Management.";
            string Body = string.Format("Hi {0} {1}, <br><br> Please note that your password has been reset by adminstrator. <br> Password: {2} <br> ", user.Name, user.Surname ,  decriptedPassword);
            mail.Body = Body;
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                string[] lines_ = { "Error" + ex.Message, "Second line" + ex.InnerException, "Third line" };
                System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", lines_);
                string text_ = "A class is the most powerful data type in C#. Like a structure, " +
                               "a class defines the data and behavior of the data type. ";
                System.IO.File.WriteAllText(@"C:\Users\Public\WriteText.txt", text_);
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\Public\WriteLines2.txt"))
                {
                    foreach (string line in lines)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file.
                        if (!line.Contains("Second"))
                        {
                            file.WriteLine(line);
                        }
                    }
                }
                throw ex;
            }
        }

        public void ForgotPasswordEmail(DataAccess.Tables.User user, string decriptedPassword)
        {
            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = appSettings.EmailHost,
                Timeout = 100000,
                Port = appSettings.EmailPot,
                Credentials = new NetworkCredential(appSettings.EmailUserName, appSettings.EmailPassword),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage(appSettings.FromEmailAddress, user.Email);
            mail.Subject = "Forgot Password : Asset Management.";
            string Body = string.Format("Hi {0} {1}, <br><br> Here is the temporary password. <br> Password: {2} <br> <br> Please change this password once logged in.", user.Name, user.Surname, decriptedPassword);
            mail.Body = Body;
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        public void NewUserEmail(DataAccess.Tables.User user, string realPassword)
        {
            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = appSettings.EmailHost,
                Timeout = 100000,
                Port = appSettings.EmailPot,
                Credentials = new NetworkCredential(appSettings.EmailUserName, appSettings.EmailPassword),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage(appSettings.FromEmailAddress, user.Email);
            mail.Subject = "New User : Asset Management.";
            string Body = string.Format("Hi {0} {1}, <br><br> Please note that you have been added to Assert Management System by adminstrator. <br> Username: {2}<br> Password: {3} <br>  Login URL: {4}", user.Name, user.Surname, user.Username, realPassword, appSettings.WebAppURL);
            mail.Body = Body;
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
}
