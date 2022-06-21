using System.ComponentModel.DataAnnotations;

namespace IES300.API.Domain.Enum
{
    public enum ETipoUsuario
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Jogador")]
        Jogador = 2
    }
}
