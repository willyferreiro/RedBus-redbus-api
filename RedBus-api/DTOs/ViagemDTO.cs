using System;
using System.Collections.Generic;

namespace RedBus_api.DTOs
{
    public class ViagemDTO
    {
        public Nullable<long> idViagem;
        public long idMotorista { get; set; }
        public double posicao_latitude { get; set; }
        public double posicao_longitude { get; set; }
        public virtual ICollection<long> idFilhos { get; set; }
    }
}