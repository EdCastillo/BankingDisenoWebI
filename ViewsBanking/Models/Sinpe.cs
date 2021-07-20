using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Sinpe
    {
        public int Codigo { get; set; }
        public string TelefonoSinpe { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public int CodigoCuenta { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
    }
}