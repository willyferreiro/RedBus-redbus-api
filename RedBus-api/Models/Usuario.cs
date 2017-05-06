namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            MensagensDe = new HashSet<Mensagem>();
            MensagensPara = new HashSet<Mensagem>();
        }

        [Key]
        public long idUsuario { get; set; }

        [Column(TypeName = "numeric")]
        public decimal telefone { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(10)]
        public string senha { get; set; }

        [Required]
        [StringLength(1)]
        public string tipoUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensagem> MensagensDe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mensagem> MensagensPara { get; set; }

        public virtual Motorista Motorista { get; set; }

        public virtual Responsavel Responsavel { get; set; }
    }
}
