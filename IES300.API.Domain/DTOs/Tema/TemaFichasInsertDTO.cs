using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Tema
{
    public class TemaFichasInsertDTO
    {
        [Required(ErrorMessage = "Campo Nome Tema é obrigatório")]
        public string NomeTema { get; set; }

        [Required(ErrorMessage = "Campo UrlTabuleiro é obrigatório")]
        public string UrlTabuleiro { get; set; }

        [Range(1, 9999999, ErrorMessage = "Campo IdPatrocinador obrigatório")]
        public int IdPatrocinador { get; set; }

        [Required(ErrorMessage = "Campo nome ficha 1 é obrigatório")]
        public string NomeFicha1 { get; set; }

        [Required(ErrorMessage = "Campo urlFicha 1 é obrigatório")]
        public string UrlFicha1 { get; set; }

        [Required(ErrorMessage = "Campo nome ficha 2 é obrigatório")]
        public string NomeFicha2 { get; set; }

        [Required(ErrorMessage = "Campo urlFicha 2 é obrigatório")]
        public string UrlFicha2 { get; set; }
    }
}
