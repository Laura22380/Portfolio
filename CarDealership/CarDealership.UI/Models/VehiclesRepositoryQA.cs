using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class VehiclesRepositoryQA : IVehiclesRepository
    { 

        private List<Vehicles> _vehicles = new List<Vehicles>
        {
            new Vehicles
            {VIN="1", Year=2021, Make="Make", Model="Model", BodyStyleId=1, TransmissionId=1, ColorId=1, InteriorId=1, Mileage="100,000", SalePrice=10000, MSRP=11000, VehicleDescription="Test vehicle number one.", ImageFileName="TestCar1.png"},
            new Vehicles
            {VIN="2", Year=2022, Make="Make2", Model="Model2", BodyStyleId=2, TransmissionId=2, ColorId=2, InteriorId=2, Mileage="200,000", SalePrice=20000, MSRP=22000, VehicleDescription="Second test vehicle.", ImageFileName="TestCar2.png"},
            new Vehicles
            {VIN="3", Year=2023, Make="Make3", Model="Model3", BodyStyleId=3, TransmissionId=3, ColorId=3, InteriorId=3, Mileage="300,000", SalePrice=30000, MSRP=33000, VehicleDescription="Third test vehicle.", ImageFileName="TestCar3.png"}
        };

        public IEnumerable<Vehicles> GetAll()
        {
            return _vehicles;
        }

        public Vehicles GetById(string VIN)
        {
            return _vehicles.FirstOrDefault(v => v.VIN == VIN);
        }

        public IEnumerable<Vehicles> GetAllByYear(int year)
        {
            return _vehicles.TakeWhile(v => v.Year == (year));
        }

        public IEnumerable<Vehicles> GetAllByMake(string make)
        {
            return _vehicles.TakeWhile(v => v.Make.Contains(make));
        }


        public IEnumerable<Vehicles> GetAllByModel(string model)
        {
            return _vehicles.TakeWhile(v => v.Model.Contains(model));
        }

        public IEnumerable<Vehicles> GetAllByPrice(decimal salePrice)
        {
            return _vehicles.TakeWhile(s => s.SalePrice <= (salePrice));
        }

        public void Create(Vehicles vehicle)
        {

            vehicle.VIN = _vehicles.Max(v => v.VIN) + 1;
            _vehicles.Add(vehicle);
        }

        public void Delete(string VIN)
        {
            _vehicles.RemoveAll(v => v.VIN == VIN);
        }

        public void Update(Vehicles vehicle)
        {
            var found = _vehicles.FirstOrDefault(v => v.VIN == vehicle.VIN);
            if (found != null)
            {
                found = vehicle;
            }

            //_vehicles.RemoveAll(v=>v.VIN == vehicle.VIN);
            //_vehicles.Add(vehicle);
        }

        public IEnumerable<VehicleFeaturedItem> GetFeatured()
        {
            throw new NotImplementedException();
        }

        public VehicleItem GetDetails(string VIN)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleShortItem> Search(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleShortItem> GetAllNew()
        {
            return (IEnumerable<VehicleShortItem>)_vehicles.TakeWhile(v => v.Year == 2022);
        }

        public IEnumerable<VehicleShortItem> GetAllUsed()
        {
            return (IEnumerable<VehicleShortItem>)_vehicles.TakeWhile(v => v.Year < 2022);
        }

        IEnumerable<VehicleItem> IVehiclesRepository.GetAll()
        {
            return (IEnumerable<VehicleItem>)_vehicles;
        }
    }
}