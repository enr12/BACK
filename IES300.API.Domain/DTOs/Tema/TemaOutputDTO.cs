namespace IES300.API.Domain.DTOs.Tema
{
    public class TemaOutputDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string UrlTabuleiro { get; set; }

        public int IdPatrocinador { get; set; }

        public string NomePatrocinador { get; set; }

        public bool Ativado { get; set; }       
    }
}
