using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IES300.API.Repository.Repositories
{
    public class FichaRepository : RepositoryBase<Ficha>, IFichaRepository
    {
        public FichaRepository(ApiDbContext context) : base(context) { }

        public Ficha ObterFichaPorIdComTema(int id, bool asNoTracking = true)
        {
            IQueryable<Ficha> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.Include(x => x.Tema).FirstOrDefault(x => x.Id == id);
        }

        public List<Ficha> ObterFichasPorIdTema(int idTema)
        {
            return _dbSet.Where(x => x.IdTema == idTema).AsNoTracking().ToList();
        }

        public List<Ficha> ObterTodasFichasComTema()
        {
            return _dbSet.Include(x => x.Tema).ToList();
        }
    }
}
