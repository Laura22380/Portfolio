using CarDealership.Data.ADO;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        //[SetUp]
        //public void Init()
        //{
        //    using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        var cmd = new SqlCommand();
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.CommandText = "GuildCarsDbReset";

        //        cmd.Connection = cn;
        //        cn.Open();

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();
            var states = repo.GetAll();

            Assert.AreEqual(71, states.Count);

            Assert.AreEqual("AL", states[0].StateId);
            Assert.AreEqual("AK", states[1].StateId);
            Assert.AreEqual("ALABAMA", states[0].StateName);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStylesRepositoryADO();
            var bodyStyles = repo.GetAll();

            Assert.AreEqual(3, bodyStyles.Count);

            Assert.AreEqual("SUV", bodyStyles[0].BodyStyleName);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new ColorsRepositoryADO();
            var colors = repo.GetAll();


            Assert.AreEqual("black", colors[0].ColorName);
        }

        [Test]
        public void CanLoadInteriors()
        {
            var repo = new InteriorsRepositoryADO();
            var interiors = repo.GetAll();

            Assert.AreEqual("black", interiors[0].InteriorName);
        }


        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new TransmissionsRepositoryADO();
            var transmissions = repo.GetAll();


            Assert.AreEqual("automatic", transmissions[0].TransmissionName);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehiclesRepositoryADO();
            var vehicle = repo.GetById("V1234TEST");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle.BodyStyleId, 1);
            Assert.AreEqual(vehicle.ColorId, 8);
            Assert.AreEqual(vehicle.Make, "Ford");
            Assert.AreEqual(vehicle.Model, "Escape");
            Assert.AreEqual(vehicle.SalePrice, 1800M);
            Assert.AreEqual(vehicle.MSRP, 6800M);
            Assert.AreEqual(vehicle.Mileage, "189000");
            Assert.AreEqual(vehicle.InteriorId, 1);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehiclesRepositoryADO();
            var vehicle = repo.GetById("V1234567890G0");

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanCreateVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.VIN = "V5678TEST2";
            vehicleToAdd.Year = 2012;
            vehicleToAdd.Make = "Subaru";
            vehicleToAdd.Model = "Forrester";
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.ColorId = 2;
            vehicleToAdd.InteriorId = 1;
            vehicleToAdd.Mileage = "100000";
            vehicleToAdd.SalePrice = 5000M;
            vehicleToAdd.MSRP = 6000M;
            vehicleToAdd.VehicleDescription = "Test vehicle to test create function.";
            vehicleToAdd.ImageFileName = "suv.png";

            repo.Create(vehicleToAdd);

            Assert.AreEqual("V5678TEST2", vehicleToAdd.VIN);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.VIN = "V1357TEST3";
            vehicleToAdd.Year = 2012;
            vehicleToAdd.Make = "Subaru";
            vehicleToAdd.Model = "Forrester";
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.ColorId = 2;
            vehicleToAdd.InteriorId = 1;
            vehicleToAdd.Mileage = "100000";
            vehicleToAdd.SalePrice = 5000M;
            vehicleToAdd.MSRP = 6000M;
            vehicleToAdd.VehicleDescription = "Test vehicle to test update function.";
            vehicleToAdd.ImageFileName = "suv.png";

            repo.Create(vehicleToAdd);

            vehicleToAdd.VIN = "V1357TEST3";
            vehicleToAdd.Year = 2022;
            vehicleToAdd.Make = "Subaru";
            vehicleToAdd.Model = "Forrester";
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.TransmissionId = 2;
            vehicleToAdd.ColorId = 2;
            vehicleToAdd.InteriorId = 1;
            vehicleToAdd.Mileage = "100000";
            vehicleToAdd.SalePrice = 9000M;
            vehicleToAdd.MSRP = 11000M;
            vehicleToAdd.VehicleDescription = "Test vehicle to test update function.";
            vehicleToAdd.ImageFileName = "suv.png";

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetById("V1357TEST3");
            Assert.AreEqual(2022, updatedVehicle.Year);
        }

        [Test]
        public void CanLoadFeatured()
        {
            var repo = new VehiclesRepositoryADO();
            List<VehicleFeaturedItem> vehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(1, vehicles.Count);
            Assert.AreEqual(2022, vehicles[0].Year);
        }

        [Test]
        public void CanLoadVehicleDetails()
        {
            var repo = new VehiclesRepositoryADO();
            var vehicle = repo.GetDetails("V1234TEST");

            Assert.IsNotNull(vehicle);
            Assert.AreEqual(vehicle.BodyStyleId, 1);
            Assert.AreEqual(vehicle.BodyStyleName, "SUV");
            Assert.AreEqual(vehicle.ColorId, 8);
            Assert.AreEqual(vehicle.ColorName, "silver");
            Assert.AreEqual(vehicle.Make, "Ford");
            Assert.AreEqual(vehicle.Model, "Escape");
            Assert.AreEqual(vehicle.SalePrice, 1800M);
            Assert.AreEqual(vehicle.MSRP, 6800M);
            Assert.AreEqual(vehicle.Mileage, "189000");
            Assert.AreEqual(vehicle.InteriorId, 1);
            Assert.AreEqual(vehicle.InteriorName, "black");
            Assert.AreEqual(vehicle.TransmissionName, "automatic");
        }

        [Test]
        public void CanLoadUsers()
        {
            var repo = new AccountRepositoryADO();
            var users = repo.GetUsers().ToList();

            Assert.AreEqual(5, users.Count());
            Assert.AreEqual("Hill", users[0].LastName);
        }

        [Test]
        public void CanLoadNewVehicles()
        {
            var repo = new VehiclesRepositoryADO();
            var vehicles = repo.GetAllNew().ToList();

            Assert.AreEqual(2022, vehicles[0].Year);
        }

        [Test]
        public void CanSearchOnPrice()
        {
            var repo = new VehiclesRepositoryADO();
            var found = repo.Search(new VehicleSearchParameters { MinPrice = 10000M }).ToList();

            Assert.IsTrue(found[0].SalePrice > 10000M);
        }

        [Test]
        public void CanSearchOnMake()
        {
            var repo = new VehiclesRepositoryADO();
            var found = repo.Search(new VehicleSearchParameters { MakeModelYear = "Dodge" }).ToList();

            Assert.AreEqual("Dodge", found[0].Make);
        }

        [Test]
        public void CanSearchOnYear()
        {
            var repo = new VehiclesRepositoryADO();
            var found = repo.Search(new VehicleSearchParameters { MinYear = 2021 }).ToList();

            Assert.IsTrue(found[0].Year >= 2021);
        }

        [Test]
        public void CanSearchReportOnDate()
        {
            var repo = new SalesRepositoryADO();
            var found = repo.Search(new SalesSearchParameters { FromDate = DateTime.Today }).ToList();

            Assert.IsTrue(found.Count == 0);
        }
    }

}
