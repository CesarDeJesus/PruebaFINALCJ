using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJMusic.Models
{
    public class SMTPemail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}