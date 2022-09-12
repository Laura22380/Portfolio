using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterCatManager.Models
{
    public class ShelterCat
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
        public string CatColor { get; set; }
        public double CatAge { get; set; }
        public bool IsReadyForAdoption { get; set; }

    }
}
