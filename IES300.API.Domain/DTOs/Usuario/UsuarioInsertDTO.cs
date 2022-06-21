using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Usuario
{
    public class UsuarioInsertDTO
    {
        [Required(ErrorMessage = "Campo NomeUsuario é obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo Email obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
