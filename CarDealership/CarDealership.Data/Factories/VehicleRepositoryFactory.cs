using CarDealership.Data.ADO;
using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public static class VehicleRepositoryFactory
    {
        public static IVehiclesRepository GetRepository()
        {
            switch (Settings.GetRepositoryMode())
            {
                case "QA":
                    return new VehiclesRepositoryADO();
                case "PROD":
                    return new VehiclesRepositoryADO();
                default:
                    throw new Exception("Could not find valid repository type configuration value.");
            }
        }
    }
}
