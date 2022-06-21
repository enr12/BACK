using IES300.API.Domain.Entities;
using IES300.API.Domain.Entities.Jogo;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Repositories
{
    public interface IPatrocinadorRepository : IRepositoryBase<Patrocinador>
    {
        bool EmailExistenteDePatrocinador(string email, int id);

        List<Patrocinador> ObterTodosPatrocinadoresComFichasETemas();
    }
}
