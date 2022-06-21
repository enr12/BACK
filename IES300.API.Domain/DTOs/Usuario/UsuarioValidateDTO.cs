using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.DTOs.Usuario
{
    public class UsuarioValidateDTO
    {
        [Required(ErrorMessage = "Campo NomeUsuario é obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
