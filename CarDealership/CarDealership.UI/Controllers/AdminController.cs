using CarDealership.Data.ADO;
using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(Vehicles vehicle)
        {
            var model = new AddEditViewModel();

            var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
            var bodyStylesRepo = new BodyStylesRepositoryADO();
            var colorsRepo = new ColorsRepositoryADO();
            var interiorsRepo = new InteriorsRepositoryADO();
            var transmissionsRepo = new TransmissionsRepositoryADO();
            var makesRepo = new MakesRepositoryADO();
            var modelsRepo = new ModelsRepositoryADO();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.Colors = new SelectList(colorsRepo.GetAll(), "ColorId", "ColorName");
            model.Interiors = new SelectList(interiorsRepo.GetAll(), "InteriorId", "InteriorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionId", "TransmissionName");
            model.Vehicle = new Vehicles();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images/");
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        string fileName = "Inventory-" + model.Vehicle.VIN;


                        var filePath = Path.Combine(savepath, fileName + extension);


                        model.ImageUpload.SaveAs(filePath);

                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);
                    }

                    repo.Create(model.Vehicle);

                    return RedirectToAction("Edit", "Admin", new { VIN = model.Vehicle.VIN });
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
            var bodyStylesRepo = new BodyStylesRepositoryADO();
            var colorsRepo = new ColorsRepositoryADO();
            var interiorsRepo = new InteriorsRepositoryADO();
            var transmissionsRepo = new TransmissionsRepositoryADO();
            var makesRepo = new MakesRepositoryADO();
            var modelsRepo = new ModelsRepositoryADO();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.Colors = new SelectList(colorsRepo.GetAll(), "ColorId", "ColorName");
            model.Interiors = new SelectList(interiorsRepo.GetAll(), "InteriorId", "InteriorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionId", "TransmissionName");
            model.Vehicle = new Vehicles();

            return View(model);

        }

        public ActionResult AddUser(Users user)
        {
            var repo = new UsersRepositoryADO();
            var model = new AddEditUserModel();
            model.User = new Users();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddUser(AddEditUserModel model)
        {
            var repo = new UsersRepositoryADO();

            if (ModelState.IsValid)
            {
                try
                {
                    
                    model.User.Role = model.Role;
                    repo.Create(model.User);

                    return RedirectToAction("Users", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.User = repo.GetById(model.User.UserId);
            return View(model);

        }

        [HttpPost]
        public ActionResult Delete(string VIN)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var vehicle = repo.GetById(VIN);
            var savepath = Server.MapPath("~/Images/");
            var oldPath = Path.Combine(savepath, vehicle.ImageFileName);
            System.IO.File.Delete(oldPath);

            repo.Delete(VIN);

            return RedirectToAction("Vehicles", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteSpecial(int specialId)
        {
                var repo = new SpecialsRepository();
                repo.Delete(specialId);
                return RedirectToAction("Specials", "Admin");
        }
        public ActionResult Edit(string VIN)
        {
            var model = new AddEditViewModel();

            var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
            var bodyStylesRepo = new BodyStylesRepositoryADO();
            var colorsRepo = new ColorsRepositoryADO();
            var interiorsRepo = new InteriorsRepositoryADO();
            var transmissionsRepo = new TransmissionsRepositoryADO();
            var makesRepo = new MakesRepositoryADO();
            var modelsRepo = new ModelsRepositoryADO();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.Colors = new SelectList(colorsRepo.GetAll(), "ColorId", "ColorName");
            model.Interiors = new SelectList(interiorsRepo.GetAll(), "InteriorId", "InteriorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionId", "TransmissionName");
            model.Vehicle = vehiclesRepo.GetById(VIN);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AddEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    var oldVehicle = repo.GetById(model.Vehicle.VIN);

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images/");

                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        string fileName = "Inventory-" + model.Vehicle.VIN;
                        

                        var filePath = Path.Combine(savepath, fileName + extension);

                        //int counter = 1;
                        //while (System.IO.File.Exists(filePath))
                        //{
                        //    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                        //    counter++;
                        //}

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageFileName = Path.GetFileName(filePath);

                    }
                    else
                    {
                        // keep old file bc they did not upload a new image
                        model.Vehicle.ImageFileName = oldVehicle.ImageFileName;
                    }

                    repo.Update(model.Vehicle);

                    return RedirectToAction("Edit", "Admin", new { VIN = model.Vehicle.VIN });
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            var vehiclesRepo = VehicleRepositoryFactory.GetRepository();
            var bodyStylesRepo = new BodyStylesRepositoryADO();
            var colorsRepo = new ColorsRepositoryADO();
            var interiorsRepo = new InteriorsRepositoryADO();
            var transmissionsRepo = new TransmissionsRepositoryADO();
            var makesRepo = new MakesRepositoryADO();
            var modelsRepo = new ModelsRepositoryADO();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylesRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.Colors = new SelectList(colorsRepo.GetAll(), "ColorId", "ColorName");
            model.Interiors = new SelectList(interiorsRepo.GetAll(), "InteriorId", "InteriorName");
            model.Transmissions = new SelectList(transmissionsRepo.GetAll(), "TransmissionId", "TransmissionName");
            model.Vehicle = new Vehicles();

            return View(model);

        }

        public ActionResult EditUser(int id)
        {
            var repo = new UsersRepositoryADO();
            var model = new AddEditUserModel();
            model.User = repo.GetById(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(AddEditUserModel model)
        {
            var repo = new UsersRepositoryADO();

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(model.Role))
                    {
                        var oldInfo = repo.GetById(model.User.UserId);
                        model.User.Role = oldInfo.Role;
                    }
                    model.User.Role = model.Role;

                    repo.Edit(model.User);

                    return RedirectToAction("Users", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.User = repo.GetById(model.User.UserId);
            return View(model);

        }

        public ActionResult Specials()
        {
            var repo = new SpecialsRepository();
            var model = new SpecialsAddViewModel();

            model.Specials = repo.GetAll();
            model.Special = new Specials();

            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(SpecialsAddViewModel model)
        {
            var repo = new SpecialsRepository();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Create(model.Special);

                    return RedirectToAction("Specials", "Admin");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.Specials = repo.GetAll();
            model.Special = new Specials();
            return View(model);

        }
        public ActionResult Users()
        {
            var repo = new UsersRepositoryADO();
            var model = repo.GetAll();

            return View(model);
        }
        public ActionResult Vehicles()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
        public ActionResult Makes()
        {
            var repo = new MakesRepositoryADO();
            var model = new AddMakesViewModel();
            model.Makes = repo.GetAll();
            model.Make = new CarDealership.Models.Tables.Makes();

            return View(model);
        }
        [HttpPost]
        public ActionResult Makes(AddMakesViewModel model)
        {
            var repo = new MakesRepositoryADO();

            if (ModelState.IsValid)
            {
                try
                {
                    var userEmail = User.Identity.Name;
                    switch (userEmail)
                    {
                        case "ahill@guildcars.com":
                            model.Make.UserId = 1;
                            break;
                        case "cmarch@guildcars.com":
                            model.Make.UserId = 2;
                            break;
                        case "vpudelski@guildcars.com":
                            model.Make.UserId = 3;
                            break;
                        case "eward@guildcars.com":
                            model.Make.UserId = 4;
                            break;
                        case "ewise@guildcars.com":
                            model.Make.UserId = 5;
                            break;
                        default:
                            model.Make.UserId = 5;
                            break;
                    }
                    repo.Create(model.Make);

                    return RedirectToAction("Makes", "Sales");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.Makes = repo.GetAll();
            model.Make = new CarDealership.Models.Tables.Makes();
            return View(model);

        }
        public ActionResult Models()
        {
            var repo = new ModelsRepositoryADO();
            var model = new AddModelsViewModel();
            var makesRepo = new MakesRepositoryADO();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = repo.GetAll();
            model.CarModel = new CarDealership.Models.Tables.Models();

            return View(model);
        }
        [HttpPost]
        public ActionResult Models(AddModelsViewModel model)
        {
            var repo = new ModelsRepositoryADO();

            if (ModelState.IsValid)
            {
                try
                {
                    var userEmail = User.Identity.Name;
                    switch (userEmail)
                    {
                        case "ahill@guildcars.com":
                            model.CarModel.UserId = 1;
                            break;
                        case "cmarch@guildcars.com":
                            model.CarModel.UserId = 2;
                            break;
                        case "vpudelski@guildcars.com":
                            model.CarModel.UserId = 3;
                            break;
                        case "eward@guildcars.com":
                            model.CarModel.UserId = 4;
                            break;
                        case "ewise@guildcars.com":
                            model.CarModel.UserId = 5;
                            break;
                        default:
                            model.CarModel.UserId = 5;
                            break;
                    }
                    model.CarModel.ModelDateAdded = DateTime.Today;
                    repo.Create(model.CarModel);

                    return RedirectToAction("Models", "Sales");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            model.Models = repo.GetAll();
            model.CarModel = new CarDealership.Models.Tables.Models();
            var makesRepo = new MakesRepositoryADO();
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            return View(model);

        }
    }
}