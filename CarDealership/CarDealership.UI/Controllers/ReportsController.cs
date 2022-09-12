using CarDealership.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles ="admin")]
    public class ReportsController : Controller
    {
        public ActionResult Inventory()
        {
            var repo = new VehiclesRepositoryADO();
            var model = repo.GetAllInventory();

            return View(model);
        }
        public ActionResult Sales()
        {
            var repo = new SalesRepositoryADO();
            var model = repo.GetAll();

            return View(model);
        }
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}