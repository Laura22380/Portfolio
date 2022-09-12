using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Models
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public DateTime ModelDateAdded { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int MakeId { get; set; }
        public string Make { get; set; }
    }
}
