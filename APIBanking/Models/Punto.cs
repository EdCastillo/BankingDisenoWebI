//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIBanking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Punto
    {
        public int Codigo { get; set; }
        public int CodigoCuenta { get; set; }
        public int CantidadPuntos { get; set; }
        public string Estado { get; set; }
        public System.DateTime UltimoIngreso { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
    }
}