using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddModelsViewModel
    {
        public List<CarDealership.Models.Tables.Models> Models { get; set; }
        public CarDealership.Models.Tables.Models CarModel { get; set; }
        public IEnumerable<SelectListItem> Makes{ get; set; }
    }
}