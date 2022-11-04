using CCAPL.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCAPL.UI.Models
{
    public class AddEditTributesViewModel
    {
        public Tributes Tribute { get; internal set; }
        public IEnumerable<SelectListItem> Members { get; set; }
    }
}