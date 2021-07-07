using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Abono
    {
        public int Codigo { get; set; }
        public int CodigoPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
    }
}