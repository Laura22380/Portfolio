using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SIS_Models
{
    public class State
    {
        [StringLength(2, ErrorMessage ="State Abbreviation must be 2 letters.")]
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
    }
}
