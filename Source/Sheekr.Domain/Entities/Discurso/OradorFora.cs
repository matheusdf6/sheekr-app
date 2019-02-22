namespace Sheekr.Domain.Entities
{
    public class OradorFora
    {
        public int OradorId { get; set; }
        public int CongregacaoId { get; set; }

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }       
        public EscolhaContato EscolhaContato { get; set; }

        // Navegação
        public Congregacao Congregacao { get; set; }
    }
}
