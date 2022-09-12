using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Data.Repositories.Interfaces;

namespace DvdLibrary.Data.Factories
{
    public class DvdRepositoryFactory
    {
        public IDvdRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Could not find valid repository type configuration value.");
            }
        }
    }
}
