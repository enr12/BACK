using IES300.API.Domain.Enum;

namespace IES300.API.Domain.DTOs.Usuario
{
    public class UsuarioOutputDTO
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }

        public string Email { get; set; }

        public bool Ativado { get; set; }

        public int NumeroPartidas { get; set; }

        public int NumeroVitorias { get; set; }

        public int NumeroDerrotas { get; set; }

        public int NumeroEmpates { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }
    }
}
