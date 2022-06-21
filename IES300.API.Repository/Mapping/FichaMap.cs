using IES300.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IES300.API.Repository.Mapping
{
    public class FichaMap : IEntityTypeConfiguration<Ficha>
    {
        public void Configure(EntityTypeBuilder<Ficha> builder)
        {
            builder.ToTable("Ficha");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UrlFicha).IsRequired();
            builder.Property(x => x.Ativado).IsRequired();
            builder.HasOne(x => x.Tema).WithMany(x => x.Fichas).HasForeignKey(x => x.IdTema);
        }
    }
}
