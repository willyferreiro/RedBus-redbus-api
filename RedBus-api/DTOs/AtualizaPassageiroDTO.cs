namespace RedBus_api.DTOs
{
    public class AtualizaPassageiroDTO
    {
        public long idViagem { get; set; }
        public long idFilho { get; set; }
        public double posicao_latitude { get; set; }
        public double posicao_longitutde { get; set; }
        public bool embarcado { get; set; }
        
    }
}