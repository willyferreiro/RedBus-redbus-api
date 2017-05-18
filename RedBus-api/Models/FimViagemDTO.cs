using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBus_api.Models
{
    public class FimViagemDTO
    {
        public long idViagem { get; set; }
        public long idMotorista { get; set; }
        public double posicaoFim_latitude { get; set; }
        public double posicaoFim_longitude { get; set; }
        public virtual ICollection<long> idFilhos { get; set; }
    }
}