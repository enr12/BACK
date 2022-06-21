namespace IES300.API.Domain.DTOs.Ficha
{
    public class FichaOutputDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string UrlFicha { get; set; }

        public int IdTema { get; set; }

        public string NomeTema { get; set; }

        public bool Ativado { get; set; }
    }
}
