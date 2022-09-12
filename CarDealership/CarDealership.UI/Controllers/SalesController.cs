using CarDealership.Data.ADO;
using CarDealership.Data.Factories;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "sales,admin")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Vehicles()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Purchase(string VIN)
        {
            var statesRepo = new StatesRepositoryADO();
            PurchaseViewModel model = new PurchaseViewModel();
            model.Vehicle = VehicleRepositoryFactory.GetRepository().GetDetails(VIN);
            model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateId");
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var repo = new SalesRepositoryADO();
            var vehicleRepo = new VehiclesRepositoryADO();
            var buyerRepo = new BuyerRepositoryADO();

            try
            {
                var userEmail = User.Identity.Name;
                switch (userEmail)
                {
                    case "ahill@guildcars.com":
                        model.VehicleSale.UserId = 1;
                        break;
                    case "cmarch@guildcars.com":
                        model.VehicleSale.UserId = 2;
                        break;
                    case "vpudelski@guildcars.com":
                        model.VehicleSale.UserId = 3;
                        break;
                    case "eward@guildcars.com":
                        model.VehicleSale.UserId = 4;
                        break;
                    case "ewise@guildcars.com":
                        model.VehicleSale.UserId = 5;
                        break;
                    default:
                        model.VehicleSale.UserId = 5;
                        break;
                }

                if (buyerRepo.GetByName(model.Buyer.BuyerName) == null)
                {
                    buyerRepo.Create(model.Buyer);
                }

                var buyer = buyerRepo.GetByName(model.Buyer.BuyerName);

                model.VehicleSale.BuyerId = buyer.BuyerId;
                model.VehicleSale.VIN = model.Vehicle.VIN;
                model.VehicleSale.PurchaseType = model.PurchaseType;

                repo.Create(model.VehicleSale);

                var vehicleToUpdate = vehicleRepo.GetById(model.Vehicle.VIN);
                vehicleToUpdate.IsPurchased = true;
                vehicleRepo.Update(vehicleToUpdate);

                return RedirectToAction("Index", "Sales");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}