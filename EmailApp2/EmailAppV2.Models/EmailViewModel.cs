using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmailAppV2.Models
{
    //In an app that's been deployed, I would validate the form (either here or in the html view) so nothing is blank & it handles bad data
    public class EmailViewModel
    {
        public EmailLog EmailLog { get; set; }
        public string CarbonCopies { get; set; }
        public string BlindCarbonCopies { get; set; }
        public bool IsBodyHtml { get; set; }
        //In a real app, this will be a list of all files attached rather than only one file option
        public HttpPostedFileBase Attachment { get; set; }
        public string AttachmentName { get; set; }
        public string ReplyToEmail { get; set; }
    }
}
