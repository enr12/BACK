using IES300.API.Domain.DTOs.Patrocinador;
using IES300.API.Domain.Entities.Jogo;
using System.Collections.Generic;

namespace IES300.API.Domain.Interfaces.Services
{
    public interface IPatrocinadorService
    {
        List<PatrocinadorOutputDTO> ObterTodosPatrocinadores(bool ativado = true);
        PatrocinadorOutputDTO ObterPatrocinadorPorId(int id);
        PatrocinadorOutputDTO InserirPatrocinador(PatrocinadorInsertDTO patrocinadorInsert);
        PatrocinadorOutputDTO AlterarPatrocinador(PatrocinadorUpdatetDTO patrocinadorUpdate);
        void DeletarPatrocinador(int id);
        DadosPatrocinador ObterPatrocinadorComFichaseTemaAleatorio();
    }
}
