namespace IES300.API.Domain.DTOs.Tema
{
    public class TemaFichaOutputDTO
    {
        public int IdTema { get; set; }

        public string NomeTema { get; set; }

        public string UrlTabuleiro { get; set; }

        public int IdPatrocinador { get; set; }

        public bool AtivadoTema { get; set; }

        public int IdFicha1 { get; set; }

        public string NomeFicha1 { get; set; }

        public string UrlFicha1 { get; set; }

        public bool AtivadoFicha1 { get; set; }

        public int IdFicha2 { get; set; }

        public string NomeFicha2 { get; set; }

        public string UrlFicha2 { get; set; }

        public bool AtivadoFicha2 { get; set; }
    }
}
