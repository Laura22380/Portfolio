using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAppV2.Models
{
    public class EmailViewModel
    {
        public EmailLog EmailLog { get; set; }
        public string CarbonCopies { get; set; }
        public string BlindCarbonCopies { get; set; }
        public bool IsBodyHtml { get; set; }
        public string AttachmentName { get; set; }
        public string ReplyToEmail { get; set; }
    }
}
