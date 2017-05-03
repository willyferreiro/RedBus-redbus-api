namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Viagem")]
    public partial class Viagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Viagem()
        {
            Viagem_Filho = new HashSet<Viagem_Filho>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idViagem { get; set; }

        public DateTime dataInicioViagem { get; set; }

        public DateTime dataFimViagem { get; set; }

        public double posicaoInicio_latitude { get; set; }

        public double posicaoInicio_longitude { get; set; }

        public double? posicaoFim_latitude { get; set; }

        public double? posicaoFim_longitude { get; set; }

        public byte idStatusViagem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem_Filho> Viagem_Filho { get; set; }

        public virtual Viagem_Status Viagem_Status { get; set; }
    }
}
