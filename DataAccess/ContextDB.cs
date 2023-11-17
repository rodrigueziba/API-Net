using Microsoft.EntityFrameworkCore;

using API_Net.Entities;


namespace API_Net.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Entities.Task> Tasks { get; set; }


    }
}
