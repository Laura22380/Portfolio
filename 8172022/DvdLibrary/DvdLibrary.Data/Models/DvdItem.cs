using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdItem
    {
        public int DvdId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Director { get; set; }

        public Ratings Rating { get; set; }
    }
}