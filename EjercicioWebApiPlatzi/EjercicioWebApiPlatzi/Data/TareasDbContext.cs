using EjercicioWebApiPlatzi.ModelosEstructura;
using EjercicioWebApiPlatzi.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioWebApiPlatzi
{
    public class TareasDbContext : DbContext
    {

        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public TareasDbContext(DbContextOptions<TareasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaEstructura());
            modelBuilder.ApplyConfiguration(new TareaEstructura());
        }
    }
}
