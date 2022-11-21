using EmailAppV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Services;

namespace EmailAppV2
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        //make this an async Task to avoid wait times
        public string SendEmail(EmailViewModel email)
        {
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            using (MailMessage mm = new MailMessage(smtpSection.From, email.EmailLog.Recipient))
            { //put a foreach loop in here to handle multiple Recipients & change Recipient to an IEnumerable in the model to handle lists.
                mm.Subject = email.EmailLog.EmailSubject;
                mm.Body = email.EmailLog.Body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpSection.Network.Host;
                smtp.EnableSsl = smtpSection.Network.EnableSsl;
                NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                smtp.Credentials = networkCred;
                smtp.Port = smtpSection.Network.Port;

                //Attachments are not coming through, so this will have to be updated.
                if (email.Attachment != null && email.Attachment.ContentLength > 0)
                {
                    var attachment = new Attachment(email.AttachmentName, MediaTypeNames.Image.Jpeg);
                    mm.Attachments.Add(attachment);
                }
                
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception)
                {
                    email.EmailLog.SendStatus = false;
                    return "Email send failed.";
                }
            }
            email.EmailLog.SendStatus = true;
            return "Email sent successfully.";
        }
    }
}
