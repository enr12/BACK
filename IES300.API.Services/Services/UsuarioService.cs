using IES300.API.Domain.DTOs.Usuario;
using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using IES300.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using IES300.API.Domain.Utils;
using IES300.API.Domain.Enum;

namespace IES300.API.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioOutputDTO InserirUsuario(UsuarioInsertDTO UsuarioInput)
        {
            this.ExisteEmailIgual(UsuarioInput.Email);

            var usuario = new Usuario()
            {
                NomeUsuario = UsuarioInput.NomeUsuario,
                Email = UsuarioInput.Email,
                Senha = Criptografia.getMDIHash(UsuarioInput.Senha),
                Ativado = true,
                NumeroPartidas = 0,
                NumeroVitorias = 0,
                NumeroDerrotas = 0,
                NumeroEmpates = 0,
                TipoUsuario = ETipoUsuario.Jogador
            };

            _usuarioRepository.Inserir(usuario);

            if (usuario.Id == 0)
                throw new NullReferenceException("Falha ao inserir Usuario");

            return new UsuarioOutputDTO()
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Ativado = usuario.Ativado,
                NumeroPartidas = usuario.NumeroPartidas,
                NumeroVitorias = usuario.NumeroVitorias,
                NumeroDerrotas = usuario.NumeroDerrotas,
                NumeroEmpates = usuario.NumeroEmpates,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public List<UsuarioOutputDTO> ObterTodosUsuarios(bool ativado)
        {
            var listaUsuarios = _usuarioRepository.ObterTodos().Where(x => x.Ativado == ativado);

            return listaUsuarios.Select(x =>
            {
                return new UsuarioOutputDTO()
                {
                    Id = x.Id,
                    NomeUsuario = x.NomeUsuario,
                    Email = x.Email,
                    Ativado = x.Ativado,
                    NumeroPartidas = x.NumeroPartidas,
                    NumeroVitorias = x.NumeroVitorias,
                    NumeroDerrotas = x.NumeroDerrotas,
                    NumeroEmpates = x.NumeroEmpates,
                    TipoUsuario = x.TipoUsuario
                };
            }).ToList();
        }

        public UsuarioOutputDTO ObterUsuarioPorId(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var usuario = _usuarioRepository.ObterPorId(id);

            if (usuario == null || !usuario.Ativado)
                throw new KeyNotFoundException($"Usuario com Id: {id} não encontrado");

            return new UsuarioOutputDTO()
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Ativado = usuario.Ativado,
                NumeroPartidas = usuario.NumeroPartidas,
                NumeroVitorias = usuario.NumeroVitorias,
                NumeroDerrotas = usuario.NumeroDerrotas,
                NumeroEmpates = usuario.NumeroEmpates,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public UsuarioOutputDTO AlterarUsuario(UsuarioUpdateDTO usuarioUpdate)
        {
            var usuarioOutput = this.ObterUsuarioPorId(usuarioUpdate.Id);
            this.ExisteEmailIgual(usuarioUpdate.Email, usuarioUpdate.Id);

            var usuario = new Usuario()
            {
                Id = usuarioUpdate.Id,
                NomeUsuario = usuarioUpdate.NomeUsuario,
                Email = usuarioUpdate.Email,
                Ativado = usuarioOutput.Ativado,
                NumeroPartidas = usuarioOutput.NumeroPartidas,
                NumeroVitorias = usuarioOutput.NumeroVitorias,
                NumeroDerrotas = usuarioOutput.NumeroDerrotas,
                NumeroEmpates = usuarioOutput.NumeroEmpates,
                TipoUsuario = usuarioOutput.TipoUsuario
            };

            if (string.IsNullOrEmpty(usuarioUpdate.Senha))
                usuario.Senha = _usuarioRepository.ObterSenhaEncriptadaPeloId(usuarioUpdate.Id);
            else
                usuario.Senha = Criptografia.getMDIHash(usuarioUpdate.Senha);

            _usuarioRepository.Alterar(usuario);

            return new UsuarioOutputDTO()
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Ativado = usuario.Ativado,
                NumeroPartidas = usuario.NumeroPartidas,
                NumeroVitorias = usuario.NumeroVitorias,
                NumeroDerrotas = usuario.NumeroDerrotas,
                NumeroEmpates = usuario.NumeroEmpates,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public void DeletarUsuario(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            if (!_usuarioRepository.Deletar(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");
        }

        private void ExisteEmailIgual(string email, int id = 0)
        {
            var retorno = _usuarioRepository.EmailExistenteDeUsuario(email, id);

            if (retorno)
                throw new ArgumentException($"Email: {email} já existe");
        }

        public UsuarioOutputDTO ValidarUsuario(UsuarioValidateDTO usuarioInput)
        {
            var usuario = _usuarioRepository.UsuarioExistente(usuarioInput.NomeUsuario, Criptografia.getMDIHash(usuarioInput.Senha));

            if (usuario == null)
                throw new UnauthorizedAccessException($"Acesso inválido");

            return new UsuarioOutputDTO()
            {
                Id = usuario.Id,
                NomeUsuario = usuario.NomeUsuario,
                Email = usuario.Email,
                Ativado = usuario.Ativado,
                NumeroPartidas = usuario.NumeroPartidas,
                NumeroVitorias = usuario.NumeroVitorias,
                NumeroDerrotas = usuario.NumeroDerrotas,
                NumeroEmpates = usuario.NumeroEmpates,
                TipoUsuario = usuario.TipoUsuario
            };
        }

        public void ContabilizarResultadoPartida(int idUsuarioGanhador, int idUsuarioPerdedor)
        {
            var usuarioGanhador = _usuarioRepository.ObterPorId(idUsuarioGanhador);
            usuarioGanhador.NumeroPartidas++;
            usuarioGanhador.NumeroVitorias++;
            _usuarioRepository.Alterar(usuarioGanhador);

            var usuarioPerdedor = _usuarioRepository.ObterPorId(idUsuarioPerdedor);
            usuarioPerdedor.NumeroPartidas++;
            usuarioPerdedor.NumeroDerrotas++;
            _usuarioRepository.Alterar(usuarioPerdedor);
        }

        public void ContabilizarResultadoPartidaEmpate(int idUsuario1, int idUsuario2)
        {
            var usuario1 = _usuarioRepository.ObterPorId(idUsuario1);
            usuario1.NumeroPartidas++;
            usuario1.NumeroEmpates++;
            _usuarioRepository.Alterar(usuario1);

            var usuario2 = _usuarioRepository.ObterPorId(idUsuario2);
            usuario2.NumeroPartidas++;
            usuario2.NumeroEmpates++;
            _usuarioRepository.Alterar(usuario2);
        }
    }
}
