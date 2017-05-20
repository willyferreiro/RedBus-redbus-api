namespace RedBus_api.DTOs
{
    public class FilhoDTO
    {
        public long idFilho { get; set; }
        public long idResponsavel { get; set; }
        public long idMotorista { get; set; }
        public string nome { get; set; }
        public bool? emViagem { get; set; }
        public bool? embarcado { get; set; }
        public double? posicao_latitudeCasa { get; set; }
        public double? posicao_longitutdeCasa { get; set; }
        public double? posicao_latitudeEscola { get; set; }
        public double? posicao_longitutdeEscola { get; set; }
        public byte[] foto { get; set; }
        public byte[] fotoCompleta { get; set; }
        public ViagemFilhoDTO viagemFilho { get; set; }
    }
}