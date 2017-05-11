using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBus_api.Models
{
    public class InicioViagemDTO
    {
        public long idMotorista { get; set; }
        public double posicaoInicio_latitude { get; set; }
        public double posicaoInicio_longitude { get; set; }
        public virtual ICollection<long> idFilhos { get; set; }
    }
}