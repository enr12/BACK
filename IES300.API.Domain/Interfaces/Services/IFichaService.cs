using IES300.API.Domain.DTOs.Ficha;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Services
{
    public interface IFichaService
    {
        List<FichaOutputDTO> ObterTodosFichas(bool ativado = true);
        FichaOutputDTO ObterFichaPorId(int id);
        FichaOutputDTO InserirFicha(FichaInsertDTO fichaInsert);
        FichaOutputDTO AlterarFicha(FichaUpdateDTO fichaUpdate);
        void DeletarFicha(int id);
    }
}