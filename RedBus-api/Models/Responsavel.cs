namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Responsavel")]
    public partial class Responsavel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Responsavel()
        {
            Filhos = new HashSet<Filho>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Filho> Filhos { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
