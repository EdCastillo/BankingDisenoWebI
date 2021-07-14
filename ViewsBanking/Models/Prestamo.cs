using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Prestamo
    {

        public int Codigo { get; set; }

        public int CodigoMoneda { get; set; }

        public int CodigoUsuario { get; set; }

        public decimal MontoTotal { get; set; }

        public decimal TasaInteres { get; set; }

        public int NumeroCuotas { get; set; }

        public System.DateTime FechaEmision { get; set; }

        public int CodigoTipo { get; set; }


        public virtual Usuario Usuario { get; set; }

        public virtual Moneda Moneda { get; set; }

    }
}