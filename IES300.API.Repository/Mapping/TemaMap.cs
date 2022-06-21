using IES300.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IES300.API.Repository.Mapping
{
    public class TemaMap : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Tema");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UrlTabuleiro).IsRequired();
            builder.Property(x => x.Ativado).IsRequired();
            builder.HasOne(x => x.Patrocinador).WithMany(x => x.Temas).HasForeignKey(x => x.IdPatrocinador);
        }
    }
}
