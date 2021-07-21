using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIBanking.Models
{
    public class Amount
    {
        public string currency_code { get; set; }
        public int value { get; set; }
    }
}