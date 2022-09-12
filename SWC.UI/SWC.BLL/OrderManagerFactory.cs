using SWC.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.BLL
{
    public static class OrderManagerFactory
    {
        private static string _filePath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWCCorp\SWCCorp.Data\OrderFiles";
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleOrder":
                    return new OrderManager(new SampleOrderTestRepository());
                case "FileTest":
                    return new OrderManager(new OrderRepository(_filePath));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
