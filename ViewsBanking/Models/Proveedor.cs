using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public class Proveedor
    {
        public int Codigo { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string Descripcion { get; set; }
    }
}