using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Tarjeta
    {

        public int Codigo { get; set; }

        public int NumeroTarjeta { get; set; }

        public int CodigoCuenta { get; set; }


        public System.DateTime FechaEmision { get; set; }
        public System.DateTime FechaExpiracion { get; set; }

        public int CVC { get; set; }

        public string Tipo { get; set; }

    }
}