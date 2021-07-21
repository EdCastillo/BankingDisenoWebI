using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Punto
    {
        public int Codigo { get; set; }
        public int CodigoCuenta { get; set; }
        public int CantidadPuntos { get; set; }
        public string Estado { get; set; }
        public System.DateTime UltimoIngreso { get; set; }
    }
}