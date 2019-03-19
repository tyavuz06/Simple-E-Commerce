using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SimpleLogin.Common
{
    public class MailOperations
    {



        public static bool sendMailFORapp(string subject, string body, string to)
        {
            string[] tof = to.Split(',');

            string smtpClient = "smtp-mail.outlook.com";
            int smtpPort = 587;
            string displayName = "Wissen Destek";

            string SmtpCredentialUserName = CommonContant.SmtpCredentialUserName;
            string SmtpCredentialPassword = CommonContant.SmtpCredentialPassword;


            return sendMail(smtpClient, smtpPort, new System.Net.NetworkCredential(SmtpCredentialUserName, SmtpCredentialPassword), displayName, tof, subject, body);
        }

        public static bool sendMail(string host, int port, NetworkCredential senderInfo, string senderdisplayName,
                             string[] to, string subject, string body)
        {


            var mail = new MailMessage();
            //MailAddress bcc = new MailAddress("urenkanaatli@hotmail.com");
            //mail.Bcc.Add(bcc);

            mail.From = new MailAddress(senderInfo.UserName, senderdisplayName);


            foreach (var item in to)
            {
                mail.To.Add(item);
            }

            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            mail.IsBodyHtml = true;

            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderInfo.UserName, senderInfo.Password)
            };


            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}