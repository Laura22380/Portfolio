using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IVehiclesRepository
    {
        IEnumerable<VehicleItem> GetAll();
        IEnumerable<VehicleShortItem> GetAllNew();
        IEnumerable<VehicleShortItem> GetAllUsed();
        Vehicles GetById(string VIN);
        void Create(Vehicles vehicle);
        void Update(Vehicles vehicle);
        void Delete(string VIN);
        IEnumerable<VehicleFeaturedItem> GetFeatured();
        VehicleItem GetDetails(string VIN);
        IEnumerable<VehicleShortItem> Search(VehicleSearchParameters parameters);
    }
}
