using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAppV2.Models
{
    public class EmailLog
    {
        public int EmailId { get; set; }
        public string SenderEmail { get; set; }
        public string Recipient { get; set; }
        public string EmailSubject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public bool SendStatus { get; set; }
    }
}
