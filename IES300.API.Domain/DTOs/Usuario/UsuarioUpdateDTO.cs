using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Range(1, 9999999, ErrorMessage = "Campo Id obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo NomeUsuario é obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo Email obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
