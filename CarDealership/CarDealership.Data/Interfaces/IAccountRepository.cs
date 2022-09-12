using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IAccountRepository
    {
        void AddMake(Makes make);
        void AddModel(Models.Tables.Models model);
        void AddUser(Users user);
        void EditUser(Users user);
        IEnumerable<SalesItem> GetSalesReport();
        IEnumerable<Users> GetUsers();
        IEnumerable<VehicleItem> GetVehiclesInventory();
        void RemoveUser(int userId);
    }
}
