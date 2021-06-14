using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuenta()
        {
            this.Pago = new HashSet<Pago>();
            this.Transferencia = new HashSet<Transferencia>();
            this.Transferencia1 = new HashSet<Transferencia>();
        }

        public int Codigo { get; set; }
        public int CodigoUsuario { get; set; }
        public string Descripcion { get; set; }
        public string IBAN { get; set; }
        public int CodigoMoneda { get; set; }
        public decimal Saldo { get; set; }
        public string Estado { get; set; }

        public virtual Moneda Moneda { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transferencia> Transferencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transferencia> Transferencia1 { get; set; }
    }
}