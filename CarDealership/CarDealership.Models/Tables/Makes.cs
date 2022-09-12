using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Makes
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime MakeDateAdded { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
