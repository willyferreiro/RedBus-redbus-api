using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBus_api.Models
{
    public class FilhoDTO
    {
        public long idFilho { get; set; }
        public long idResponsavel { get; set; }
        public long idMotorista { get; set; }
        public string nome { get; set; }
        public Nullable<bool> emViagem { get; set; }
        public Nullable<bool> embarcado { get; set; }
        public Nullable<double> posicao_latitudeCasa { get; set; }
        public Nullable<double> posicao_longitutdeCasa { get; set; }
        public Nullable<double> posicao_latitudeEscola { get; set; }
        public Nullable<double> posicao_longitutdeEscola { get; set; }
        public byte[] foto { get; set; }
        public byte[] fotoCompleta { get; set; }
    }
}