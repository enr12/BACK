using IES300.API.Domain.Entities;
using IES300.API.Repository.Mapping;
using IES300.API.Repository.Seeds;
using Microsoft.EntityFrameworkCore;

namespace IES300.API.Repository
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() { }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Patrocinador> Patrocinador { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:fourline.database.windows.net,1433;Initial Catalog=quatroemlinhaDB;Persist Security Info=False;User ID=fourlineadmin;Password=Ies300@fatec;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patrocinador>(new PatrocinadorMap().Configure);
            modelBuilder.Entity<Tema>(new TemaMap().Configure);
            modelBuilder.Entity<Ficha>(new FichaMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

            base.OnModelCreating(modelBuilder);

            UsuarioSeed.Usuarios(modelBuilder);
        }
    }
}
