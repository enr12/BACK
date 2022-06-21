using IES300.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IES300.API.Repository.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeUsuario).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Senha).IsRequired();
            builder.Property(x => x.Ativado).IsRequired();
            builder.Property(x => x.NumeroPartidas).HasDefaultValue(0);
            builder.Property(x => x.NumeroVitorias).HasDefaultValue(0);
            builder.Property(x => x.NumeroDerrotas).HasDefaultValue(0);
            builder.Property(x => x.NumeroEmpates).HasDefaultValue(0);
            builder.Property(x => x.TipoUsuario).IsRequired();
        }
    }
}
