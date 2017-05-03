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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idMotorista { get; set; }

        public bool emViagem { get; set; }

        public double? posicao_Latitude { get; set; }

        public double? posicao_longitude { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
