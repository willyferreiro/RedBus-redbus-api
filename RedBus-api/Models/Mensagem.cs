namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mensagem")]
    public partial class Mensagem
    {
        [Key]
        public long idMensagem { get; set; }

        public long idUsuarioDe { get; set; }

        public long idUsuarioPara { get; set; }

        public DateTime dataMensagem { get; set; }

        [Column("mensagem")]
        [Required]
        [StringLength(500)]
        public string mensagem1 { get; set; }

        public bool entregue { get; set; }

        public bool visualizada { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
