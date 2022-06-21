using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IES300.API.Repository.Repositories
{
    public class PatrocinadorRepository : RepositoryBase<Patrocinador>, IPatrocinadorRepository
    {
        public PatrocinadorRepository(ApiDbContext context) : base(context) { }

        public bool EmailExistenteDePatrocinador(string email, int id)
        {
            return _dbSet.Where(x => x.Id != id).Any(x => x.Email.ToUpper() == email.ToUpper());
        }

        public List<Patrocinador> ObterTodosPatrocinadoresComFichasETemas()
        {
            var query = _dbSet.Where(x => x.Ativado == true).Include(x => x.Temas.Where(x => x.Ativado == true)).ThenInclude(x => x.Fichas.Where(x => x.Ativado == true)).ToList();
            return query.Where(x => (x.Temas.Count() > 0) && (x.Temas.Select(x => x.Fichas.Count >= 2)).Any()).ToList();
        }
    }
}
