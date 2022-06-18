using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Sebo.ImageService.Persistence
{
    public class Context : DbContext
    {

        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.File> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
