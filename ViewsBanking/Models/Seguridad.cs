using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Seguridad
    {

        public int codigo { get; set; }

        public int CodigoUsuario { get; set; }

        public string Lllamada { get; set; }

        public string Token { get; set; }

        public string OTP { get; set; }

    }
}


