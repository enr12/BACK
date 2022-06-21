using IES300.API.Domain.DTOs.Usuario;
using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IES300.API.Repository.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApiDbContext context) : base(context) { }

        public bool EmailExistenteDeUsuario(string email, int id)
        {
            return _dbSet.Where(x => x.Id != id).Any(x => x.Email.ToUpper() == email.ToUpper());
        }

        public string ObterSenhaEncriptadaPeloId(int id)
        {
            return _dbSet.Where(x => x.Id == id).Select(x => x.Senha).FirstOrDefault();
        }

        public Usuario UsuarioExistente(string nomeUsuario, string senha)
        {
            return _dbSet.Where(x => x.NomeUsuario == nomeUsuario && x.Senha == senha && x.Ativado == true).FirstOrDefault();
        }
    }
}
