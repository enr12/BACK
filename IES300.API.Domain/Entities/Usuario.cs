using IES300.API.Domain.Enum;

namespace IES300.API.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario() { }

        public Usuario(int id, string nomeUsuario, string email, string senha, int numPar, int numVit, int numDer, int numEmp, ETipoUsuario tipo) : base(id)
        {
            this.NomeUsuario = nomeUsuario;
            this.Email = email;
            this.Senha = senha;
            this.NumeroPartidas = numPar;
            this.NumeroVitorias = numVit;
            this.NumeroDerrotas = numDer;
            this.NumeroEmpates = numEmp;
            this.TipoUsuario = tipo;
        }

        public string NomeUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public ETipoUsuario TipoUsuario { get; set; }

        public int NumeroPartidas { get; set; }

        public int NumeroVitorias { get; set; }

        public int NumeroDerrotas { get; set; }

        public int NumeroEmpates { get; set; }
    }
}
