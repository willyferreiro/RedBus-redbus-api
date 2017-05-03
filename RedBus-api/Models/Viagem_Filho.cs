namespace RedBus_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Viagem_Filho
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idVIagem { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idFilho { get; set; }

        public DateTime? dataEmbarque { get; set; }

        public DateTime? dataDesembarque { get; set; }

        public double? posicaoEmbarque_latitude { get; set; }

        public double? posicaoEmbarque_longitude { get; set; }

        public double? posicaoDesembarque_latitude { get; set; }

        public double? posicaoDesembarque_longitude { get; set; }

        public virtual Filho Filho { get; set; }

        public virtual Viagem Viagem { get; set; }
    }
}
