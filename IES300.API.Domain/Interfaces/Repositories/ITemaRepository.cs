using IES300.API.Domain.DTOs.Tema;
using IES300.API.Domain.Entities;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Repositories
{
    public interface ITemaRepository : IRepositoryBase<Tema>
    {
        List<Tema> ObterTodosTemasComPatrocinador();
        Tema ObterTemaPorIdComPatrocinador(int id, bool asNoTracking = true);
        List<Tema> ObterTemasPorIdPatrocinador(int idPatrocinador);
    }
}
