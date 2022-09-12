using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialsAddViewModel
    {
        public List<Specials> Specials { get; set; }
        public Specials Special { get; set; }
    }
}