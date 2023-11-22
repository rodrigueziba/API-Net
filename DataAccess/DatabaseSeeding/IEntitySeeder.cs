using Microsoft.EntityFrameworkCore;

namespace API_Net.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
