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
    
    public partial class Abono
    {
        public int Codigo { get; set; }
        public Nullable<int> CodigoPrestamo { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
    
        public virtual Prestamo Prestamo { get; set; }
        public virtual Prestamo Prestamo1 { get; set; }
    }
}