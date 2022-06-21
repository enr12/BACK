using IES300.API.Domain.DTOs.Tema;
using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using IES300.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IES300.API.Services.Services
{
    public class TemaService : ITemaService
    {
        private readonly ITemaRepository _temaRepository;
        private readonly IFichaRepository _fichaRepository;

        public TemaService(ITemaRepository temaRepository, IFichaRepository fichaRepository)
        {
            _temaRepository = temaRepository;
            _fichaRepository = fichaRepository;
        }

        public TemaOutputDTO AlterarTema(TemaUpdateDTO temaUpdate)
        {
            var temaOutput = this.ObterTemaPorId(temaUpdate.Id);

            var tema = new Tema()
            {
                Id = temaUpdate.Id,
                Nome = temaUpdate.Nome,
                IdPatrocinador = temaUpdate.IdPatrocinador,
                UrlTabuleiro = temaUpdate.UrlTabuleiro,
                Ativado = temaOutput.Ativado
            };

            _temaRepository.Alterar(tema);

            return new TemaOutputDTO()
            {
                Ativado = tema.Ativado,
                Id = tema.Id,
                IdPatrocinador = tema.IdPatrocinador,
                Nome = tema.Nome,
                UrlTabuleiro = tema.UrlTabuleiro,
                NomePatrocinador = temaOutput.NomePatrocinador
            };
        }

        public void DeletarTema(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var retorno = _temaRepository.Deletar(id);

            if (!retorno)
                throw new KeyNotFoundException($"Tema com Id: {id} não encontrado");

            var fichasTema = _fichaRepository.ObterFichasPorIdTema(id).Where(x => x.Ativado == true);

            foreach (var ficha in fichasTema)
            {
                _fichaRepository.Deletar(ficha.Id);
            }
        }

        public TemaOutputDTO InserirTema(TemaInsertDTO TemaInput)
        {
            var tema = new Tema()
            {
                Ativado = true,
                IdPatrocinador = TemaInput.IdPatrocinador,
                Nome = TemaInput.Nome,
                UrlTabuleiro = TemaInput.UrlTabuleiro
            };

            _temaRepository.Inserir(tema);

            if (tema.Id == 0)
                throw new NullReferenceException("Falha ao inserir Tema");

            return new TemaOutputDTO()
            {
                Nome = tema.Nome,
                IdPatrocinador = tema.IdPatrocinador,
                UrlTabuleiro = tema.UrlTabuleiro,
                Ativado = tema.Ativado,
                Id = tema.Id
            };
        }

        public TemaOutputDTO ObterTemaPorId(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var tema = _temaRepository.ObterTemaPorIdComPatrocinador(id);

            if (tema == null || !tema.Ativado)
                throw new KeyNotFoundException($"Tema com Id: {id} não encontrado");

            return new TemaOutputDTO()
            {
                Id = tema.Id,
                Nome = tema.Nome,
                UrlTabuleiro = tema.UrlTabuleiro,
                IdPatrocinador = tema.IdPatrocinador,
                Ativado = tema.Ativado,
                NomePatrocinador = tema.Patrocinador.Nome
            };
        }

        public List<TemaOutputDTO> ObterTodosTemas(bool ativado)
        {
            var listaTemas = _temaRepository.ObterTodosTemasComPatrocinador().Where(x => x.Ativado == ativado);

            return listaTemas.Select(x =>
            {
                return new TemaOutputDTO()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Ativado = x.Ativado,
                    UrlTabuleiro = x.UrlTabuleiro,
                    IdPatrocinador = x.Patrocinador.Id,
                    NomePatrocinador = x.Patrocinador.Nome,
                };
            }).ToList();
        }

        public TemaFichaOutputDTO InserirTemaComFichas(TemaFichasInsertDTO temaFichasDTO)
        {
            var ficha1 = new Ficha()
            {
                Nome = temaFichasDTO.NomeFicha1,
                UrlFicha = temaFichasDTO.UrlFicha1,
                Ativado = true
            };

            var ficha2 = new Ficha()
            {
                Nome = temaFichasDTO.NomeFicha2,
                UrlFicha = temaFichasDTO.UrlFicha2,
                Ativado = true
            };

            var listaFicha = new List<Ficha>();

            listaFicha.Add(ficha1);
            listaFicha.Add(ficha2);

            var tema = new Tema()
            {
                Ativado = true,
                IdPatrocinador = temaFichasDTO.IdPatrocinador,
                Nome = temaFichasDTO.NomeTema,
                UrlTabuleiro = temaFichasDTO.UrlTabuleiro,
                Fichas = listaFicha
            };

            _temaRepository.Inserir(tema);

            if (tema.Id == 0)
                throw new NullReferenceException("Falha ao inserir Tema");

            ficha1 = tema.Fichas.FirstOrDefault(x => x.Id == ficha1.Id);
            ficha2 = tema.Fichas.FirstOrDefault(x => x.Id == ficha2.Id);

            if(ficha1.Id == 0)
                throw new NullReferenceException("Falha ao inserir Ficha 1");

            if (ficha2.Id == 0)
                throw new NullReferenceException("Falha ao inserir Ficha 2");

            return new TemaFichaOutputDTO()
            {
                IdTema = tema.Id,
                NomeTema = tema.Nome,
                IdPatrocinador = tema.IdPatrocinador,
                UrlTabuleiro = tema.UrlTabuleiro,
                AtivadoTema = tema.Ativado,
                IdFicha1 = ficha1.Id,
                NomeFicha1 = ficha1.Nome,
                UrlFicha1 = ficha1.UrlFicha,
                AtivadoFicha1 = ficha1.Ativado,
                IdFicha2 = ficha2.Id,
                NomeFicha2 = ficha2.Nome,
                UrlFicha2 = ficha2.UrlFicha,
                AtivadoFicha2 = ficha2.Ativado
            };
        }
    }
}
