using IES300.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IES300.API.Repository.Mapping
{
    public class PatrocinadorMap : IEntityTypeConfiguration<Patrocinador>
    {
        public void Configure(EntityTypeBuilder<Patrocinador> builder)
        {
            builder.ToTable("Patrocinador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Website).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Celular).IsRequired();
            builder.Property(x => x.UrlLogo).IsRequired();
            builder.Property(x => x.Ativado).IsRequired();
        }
    }
}
