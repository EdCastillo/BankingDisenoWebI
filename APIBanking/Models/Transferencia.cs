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
    
    public partial class Transferencia
    {
        public int Codigo { get; set; }
        public int CuentaOrigen { get; set; }
        public int CuentaDestino { get; set; }
        public System.DateTime FechaHora { get; set; }
        public string Descipcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
        public virtual Cuenta Cuenta1 { get; set; }
    }
}
