namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Motorista")]
    public partial class Motorista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motorista()
        {
            Viagem = new HashSet<Viagem>();
        }

        [Key]
        public long idMotorista { get; set; }

        public bool emViagem { get; set; }

        public double? posicao_Latitude { get; set; }

        public double? posicao_longitude { get; set; }

        public byte[] foto { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem> Viagem { get; set; }
    }
}
