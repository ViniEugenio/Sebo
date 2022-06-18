using Microsoft.EntityFrameworkCore;
using Sebo.ImageService.Persistence.Interfaces;
using System.Threading.Tasks;

namespace Sebo.ImageService.Persistence.Repositories
{
    public class MainRepository<T> : IMainRepository<T> where T : class
    {

        private readonly Context Context;
        public readonly DbSet<T> Db;

        public MainRepository(Context Context)
        {
            this.Context = Context;
            Db = Context.Set<T>();
        }

        public async Task Add(T model)
        {
            await Db.AddAsync(model);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

    }
}
