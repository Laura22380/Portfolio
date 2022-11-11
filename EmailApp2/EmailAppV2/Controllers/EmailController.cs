using EmailAppV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web;
using EmailAppV2.Data;

namespace EmailAppV2.Controllers
{
    public class EmailController : ApiController
    {
        public void SendEmail()
        {
            throw new NotImplementedException();
            
        }

        [Route("api/SendEmail")]
        [HttpPost]
        public string SendEmail(EmailLog email)
        {
            var repo = new EmailRepository();
            for (int i = 0; i < 3; i++)
            {
                email.SendStatus = true;
                try
                {
                    repo.Create(email);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return "Email sent successfully.";
        }
    }
}
