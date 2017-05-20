using System;

namespace RedBus_api.DTOs
{
    public class ViagemFilhoDTO
    {
        public long idViagem { get; set; }
        public DateTime? dataEmbarque { get; set; }
        public DateTime? dataDesembarque { get; set; }
        public double? posicaoEmbarque_latitude { get; set; }
        public double? posicaoEmbarque_longitude { get; set; }
        public double? posicaoDesembarque_latitude { get; set; }
        public double? posicaoDesembarque_longitude { get; set; }
    }
}