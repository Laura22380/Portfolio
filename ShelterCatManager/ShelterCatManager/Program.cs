using ShelterCatManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            ShelterCatController controller = new ShelterCatController();
            controller.Run();
        }

    }
}
