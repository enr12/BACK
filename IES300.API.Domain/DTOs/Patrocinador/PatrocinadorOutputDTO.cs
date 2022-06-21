namespace IES300.API.Domain.DTOs.Patrocinador
{
    public class PatrocinadorOutputDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string UrlLogo { get; set; }

        public bool Ativado { get; set; }
    }
}
