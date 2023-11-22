using Microsoft.EntityFrameworkCore;

using API_Net.Entities;
using API_Net.DataAccess.DatabaseSeeding;

namespace API_Net.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new TareaSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
