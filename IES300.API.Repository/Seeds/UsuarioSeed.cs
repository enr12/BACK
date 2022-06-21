using IES300.API.Domain.Entities;
using IES300.API.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace IES300.API.Repository.Seeds
{
    public class UsuarioSeed
    {
        public static void Usuarios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario()
                {
                    Id = 1,
                    NomeUsuario = "Admin",
                    Email = "admin@fourline.com",
                    Senha = "e10adc3949ba59abbe56e057f20f883e",
                    NumeroPartidas = 0,
                    NumeroVitorias = 0,
                    NumeroDerrotas = 0,
                    NumeroEmpates = 0,
                    TipoUsuario = ETipoUsuario.Administrador,
                    Ativado = true
                });
        }
    }
}
