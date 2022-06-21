using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Patrocinador
{
    public class PatrocinadorInsertDTO
    {
        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo website obrigatório")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Campo email obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo celular obrigatório")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo urlLogo obrigatório")]
        public string UrlLogo { get; set; }
    }
}
