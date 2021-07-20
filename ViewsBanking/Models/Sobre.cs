using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Sobre
    {
        public int Codigo { get; set; }
        public int CodigoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int CodigoMoneda { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int Descripcion { get; set; }
        public string Estado { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
        public virtual Moneda Moneda { get; set; }
    
    }
}