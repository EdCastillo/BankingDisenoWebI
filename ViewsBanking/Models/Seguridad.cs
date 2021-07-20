using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Seguridad
    {

        public int Codigo { get; set; }

        public int CodigoUsuario { get; set; }

        public string Llamada { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }

    }
}


