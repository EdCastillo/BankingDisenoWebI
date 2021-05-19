using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIBanking.Models
{
    public class Usuario
    {
        public int US_ID { get; set; }
        public string US_USERNAME { get; set; }
        public string US_PASSWORD { get; set; }
        public string TOKEN { get; set; }
    }
}