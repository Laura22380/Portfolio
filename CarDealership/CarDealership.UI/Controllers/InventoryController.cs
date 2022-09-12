using CarDealership.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Vehicles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAllNew();
            return View(model);
        }
        public ActionResult Used()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAllUsed();
            return View(model);
        }

        public ActionResult Details(string VIN)
        {
            var model = VehicleRepositoryFactory.GetRepository().GetDetails(VIN);
            return View(model);
        }
    }
}