using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsBanking.Models
{
    public partial class Servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicio()
        {
            this.Pago = new HashSet<Pago>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }
    }
}