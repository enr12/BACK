using IES300.API.Domain.Entities;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Repositories
{
    public interface IFichaRepository : IRepositoryBase<Ficha>
    {
        List<Ficha> ObterTodasFichasComTema();
        Ficha ObterFichaPorIdComTema(int id, bool asNoTracking = true);
        List<Ficha> ObterFichasPorIdTema(int idTema);
    }
}
