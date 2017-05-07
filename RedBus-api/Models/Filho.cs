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
        }

        [Key]
        public long idFilho { get; set; }

        public long idResponsavel { get; set; }

        public long idMotorista { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        public bool? emViagem { get; set; }

        public bool? embarcado { get; set; }

        public double? posicao_latitudeCasa { get; set; }

        public double? posicao_longitutdeCasa { get; set; }

        public double? posicao_latitudeEscola { get; set; }

        public double? posicao_longitutdeEscola { get; set; }

        public byte[] foto { get; set; }

        public byte[] fotoCompleta { get; set; }

        public virtual Motorista Motorista { get; set; }

        public virtual Responsavel Responsavel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viagem_Filho> Viagem_Filho { get; set; }
    }
}
