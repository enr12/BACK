using IES300.API.Domain.DTOs.Tema;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Services
{
    public interface ITemaService
    {
        TemaOutputDTO InserirTema(TemaInsertDTO TemaInput);
        List<TemaOutputDTO> ObterTodosTemas(bool ativado = true);
        TemaOutputDTO ObterTemaPorId(int id);
        void DeletarTema(int id);
        TemaOutputDTO AlterarTema(TemaUpdateDTO temaInput);
        TemaFichaOutputDTO InserirTemaComFichas(TemaFichasInsertDTO temaFichasDTO);
    }
}
