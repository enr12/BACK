using IES300.API.Domain.DTOs.Patrocinador;
using IES300.API.Domain.Entities;
using IES300.API.Domain.Entities.Jogo;
using IES300.API.Domain.Interfaces.Repositories;
using IES300.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IES300.API.Services.Services
{
    public class PatrocinadorService : IPatrocinadorService
    {
        private readonly IPatrocinadorRepository _patrocinadorRepository;
        private readonly ITemaRepository _temaRepository;
        private readonly ITemaService _temaService;

        public PatrocinadorService(IPatrocinadorRepository patrocinadorRepository, ITemaRepository temaRepository, ITemaService temaService)
        {
            _patrocinadorRepository = patrocinadorRepository;
            _temaRepository = temaRepository;
            _temaService = temaService;
        }

        public PatrocinadorOutputDTO InserirPatrocinador(PatrocinadorInsertDTO patrocinadorInsert)
        {
            this.ExisteEmailIgual(patrocinadorInsert.Email);

            var patrocinador = new Patrocinador()
            {
                Nome = patrocinadorInsert.Nome,
                Email = patrocinadorInsert.Email,
                Celular = patrocinadorInsert.Celular,
                UrlLogo = patrocinadorInsert.UrlLogo,
                Website = patrocinadorInsert.Website,
                Ativado = true
            };

            _patrocinadorRepository.Inserir(patrocinador);

            if (patrocinador.Id == 0)
                throw new NullReferenceException("Falha ao inserir Patrocinador");

            return new PatrocinadorOutputDTO()
            {
                Id = patrocinador.Id,
                Nome = patrocinador.Nome,
                Email = patrocinador.Email,
                UrlLogo = patrocinador.UrlLogo,
                Website = patrocinador.Website,
                Celular = patrocinador.Celular,
                Ativado = patrocinador.Ativado
            };
        }

        public List<PatrocinadorOutputDTO> ObterTodosPatrocinadores(bool ativado)
        {
            var listaPatrocinadores = _patrocinadorRepository.ObterTodos().Where(x => x.Ativado == ativado);

            return listaPatrocinadores.Select(x =>
            {
                return new PatrocinadorOutputDTO()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    UrlLogo = x.UrlLogo,
                    Website = x.Website,
                    Celular = x.Celular,
                    Ativado = x.Ativado
                };
            }).ToList();
        }

        public PatrocinadorOutputDTO ObterPatrocinadorPorId(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var patrocinador = _patrocinadorRepository.ObterPorId(id);

            if (patrocinador == null || !patrocinador.Ativado)
                throw new KeyNotFoundException($"Patrocinador com Id: {id} não encontrado");

            return new PatrocinadorOutputDTO()
            {
                Id = patrocinador.Id,
                Nome = patrocinador.Nome,
                Email = patrocinador.Email,
                UrlLogo = patrocinador.UrlLogo,
                Website = patrocinador.Website,
                Celular = patrocinador.Celular,
                Ativado = patrocinador.Ativado
            };
        }

        public PatrocinadorOutputDTO AlterarPatrocinador(PatrocinadorUpdatetDTO patrocinadorUpdate)
        {
            var patrocinadorOutput = this.ObterPatrocinadorPorId(patrocinadorUpdate.Id);
            this.ExisteEmailIgual(patrocinadorUpdate.Email, patrocinadorUpdate.Id);

            var patrocinador = new Patrocinador()
            {
                Id = patrocinadorUpdate.Id,
                Nome = patrocinadorUpdate.Nome,
                Email = patrocinadorUpdate.Email,
                Celular = patrocinadorUpdate.Celular,
                UrlLogo = patrocinadorUpdate.UrlLogo,
                Website = patrocinadorUpdate.Website,
                Ativado = patrocinadorOutput.Ativado
            };

            _patrocinadorRepository.Alterar(patrocinador);

            return new PatrocinadorOutputDTO()
            {
                Id = patrocinador.Id,
                Nome = patrocinador.Nome,
                Email = patrocinador.Email,
                UrlLogo = patrocinador.UrlLogo,
                Website = patrocinador.Website,
                Celular = patrocinador.Celular,
                Ativado = patrocinador.Ativado
            };
        }

        public void DeletarPatrocinador(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");
            
            var retorno = _patrocinadorRepository.Deletar(id);

            if (!retorno)
                throw new KeyNotFoundException($"Patrocinador com Id: {id} não encontrado");

            var patrocinadorTemas = _temaRepository.ObterTemasPorIdPatrocinador(id).Where(x => x.Ativado == true);

            foreach (var tema in patrocinadorTemas)
            {
                _temaService.DeletarTema(tema.Id);
            }
        }

        private void ExisteEmailIgual(string email, int id = 0)
        {
            var retorno = _patrocinadorRepository.EmailExistenteDePatrocinador(email, id);

            if (retorno)
                throw new ArgumentException($"Email: {email} já existe");
        }

        public DadosPatrocinador ObterPatrocinadorComFichaseTemaAleatorio()
        {
            var patrocinadorCompleto = _patrocinadorRepository.ObterTodosPatrocinadoresComFichasETemas();

            if (patrocinadorCompleto.Count() != 0)
            {
                var randomPatro = new Random(DateTime.Now.Millisecond);
                var numRandomP = randomPatro.Next(0, (patrocinadorCompleto.Count()));

                var patrocinadorEscolhido = patrocinadorCompleto[numRandomP];

                var randomTema = new Random(DateTime.Now.Millisecond);
                var numRandomT = randomTema.Next(0, (patrocinadorEscolhido.Temas.Count()));

                var temaEscolhido = patrocinadorEscolhido.Temas.ToList()[numRandomT];

                var randomFicha1 = new Random(DateTime.Now.Millisecond);
                var numRandomF1 = randomFicha1.Next(0, (temaEscolhido.Fichas.Count()));
                var fichaEscolhida1 = temaEscolhido.Fichas.ToList()[numRandomF1];
                temaEscolhido.Fichas.Remove(fichaEscolhida1);

                var randomFicha2 = new Random(DateTime.Now.Millisecond);
                var numRandomF2 = randomFicha2.Next(0, (temaEscolhido.Fichas.Count()));

                var fichaEscolhida2 = temaEscolhido.Fichas.ToList()[numRandomF2];

                return new DadosPatrocinador()
                {
                    Tabuleiro = temaEscolhido.UrlTabuleiro,
                    Banner = patrocinadorEscolhido.UrlLogo,
                    Ficha1 = fichaEscolhida1.UrlFicha,
                    Ficha2 = fichaEscolhida2.UrlFicha,
                    Url = patrocinadorEscolhido.Website
                };
            }

            return null;
        }
    }
}
