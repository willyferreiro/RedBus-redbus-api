using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBus_api.DTOs
{
    public class PassageiroDTO
    {
        public long idFilho { get; set; }
        public long idMotorista { get; set; }
        public string nome { get; set; }
        public short dddResponsavel { get; set; }
        public decimal telefoneResponsavel { get; set; }
        public string enderecoCasa { get; set; }
        public string enderecoEscola { get; set; }
        public double? posicao_latitudeCasa { get; set; }
        public double? posicao_longitutdeCasa { get; set; }
        public double? posicao_latitudeEscola { get; set; }
        public double? posicao_longitutdeEscola { get; set; }
        public byte[] foto { get; set; }
        public byte[] fotoCompleta { get; set; }
    }
}