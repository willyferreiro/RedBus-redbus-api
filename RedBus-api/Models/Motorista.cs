//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Motorista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motorista()
        {
            this.adimplente = false;
            this.Filho = new HashSet<Filho>();
            this.Viagem = new HashSet<Viagem>();
        }
    
        public long idUsuario { get; set; }
        public bool emViagem { get; set; }
        public Nullable<double> posicao_Latitude { get; set; }
        public Nullable<double> posicao_longitude { get; set; }
        public bool adimplente { get; set; }
        public byte[] foto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Filho> Filho { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
