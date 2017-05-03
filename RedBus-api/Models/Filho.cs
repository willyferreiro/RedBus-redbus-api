namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Filho")]
    public partial class Filho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filho()
        {
            Viagem_Filho = new HashSet<Viagem_Filho>();
            Responsavel = new HashSet<Responsavel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idFilho { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        public bool? emViagem { get; set; }

        public bool? embarcado { get; set; }

        public double? posicao_latitude { get; set; }

        public double? posicao_longitutde { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem_Filho> Viagem_Filho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Responsavel> Responsavel { get; set; }
    }
}
