using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBus_api.Models
{
    public class ViagemDTO
    {
        public long idViagem { get; set; }
        public long idMotorista { get; set; }
        public DateTime dataInicioViagem { get; set; }
        public Nullable<System.DateTime> dataFimViagem { get; set; }
        public double posicaoInicio_latitude { get; set; }
        public double posicaoInicio_longitude { get; set; }
        public Nullable<double> posicaoFim_latitude { get; set; }
        public Nullable<double> posicaoFim_longitude { get; set; }
        public decimal statusViagem { get; set; }

        public virtual Motorista Motorista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViagemFilho> ViagemFilho { get; set; }
    }
}