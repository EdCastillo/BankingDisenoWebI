using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Sesion
    {
        public int Codigo { get; set; }
        public int CodigoUsuario { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaExpiracion { get; set; }
        public string Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}