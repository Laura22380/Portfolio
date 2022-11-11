using EmailAppV2.Data;
using EmailAppV2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;

namespace EmailAppV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SaveEmail(EmailLog email)
        {
            var model = new EmailViewModel();
            var repo = new EmailRepository();

            model.EmailLog = new EmailLog();

            return View(model);
        }
        [HttpPost]
        public ActionResult SaveEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new EmailRepository();
                model.EmailLog.SendDate = DateTime.Now;
                model.EmailLog.SendStatus = true;
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                model.EmailLog.SenderEmail = smtpSection.From;
                try
                {
                    repo.Create(model.EmailLog);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return RedirectToAction("Index", "Home");
            }

            model.EmailLog = new EmailLog();
            return View(model);
        }
    }
}
