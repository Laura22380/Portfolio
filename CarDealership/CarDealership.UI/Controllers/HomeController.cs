using CarDealership.Data.ADO;
using CarDealership.Data.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetFeatured();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string VIN)
        {
            ViewBag.Message = "Your contact page.";
            var model = new ContactsViewModel();
            
            model.VIN = VIN;

            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(ContactsViewModel contact)
        {
            var repo = new ContactsRepositoryADO();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.AddContact(contact.Person);

                    return RedirectToAction("Contact", "Home");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            ViewBag.Message = "Your contact page.";
            var model = new ContactsViewModel();
            if (contact.VIN != null)
            {
                model.VIN = contact.VIN;
            }
            return View(model);
        }
        public ActionResult Specials()
        {
            ViewBag.Message = "Specials";
            var repo = new SpecialsRepository();
            var model = repo.GetAll();
            return View(model);
        }
    }
}