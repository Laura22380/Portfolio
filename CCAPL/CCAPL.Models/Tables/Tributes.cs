using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCAPL.Models.Tables
{
    public class Tributes
    {
        public int TributeId { get; set; }
        public string TributeMessage { get; set; }
        public decimal DonationAmount { get; set; }
        public int MemberId { get; set; }
        public Members Member { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
