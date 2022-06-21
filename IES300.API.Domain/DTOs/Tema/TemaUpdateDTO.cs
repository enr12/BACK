using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Tema
{
    public class TemaUpdateDTO
    {
        [Range(1, 9999999, ErrorMessage = "Campo Id obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo UrlTabuleiro é obrigatório")]
        public string UrlTabuleiro { get; set; }

        [Range(1, 9999999, ErrorMessage = "Campo IdPatrocinador obrigatório")]
        public int IdPatrocinador { get; set; }
    }
}
