using API_Net.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Net.DataAccess.DatabaseSeeding
{
    public class TareaSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = 0,
                    TareaTitle = "Primera",
                    TareaDescription = "Descripcion primera",
                    IsCompleted = true,
                },
                new Tarea
                {
                    Id = 1,
                    TareaTitle = "Segunda",
                    TareaDescription = "Descripciòn 2",
                    IsCompleted = false,
                }
                );
        }
    }
}
