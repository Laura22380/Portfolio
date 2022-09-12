using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SIS_Models
{
    public class Major
    {
        [Required(ErrorMessage = "Select a major")]
        public int MajorId { get; set; }
        public string MajorName { get; set; }
    }
}
