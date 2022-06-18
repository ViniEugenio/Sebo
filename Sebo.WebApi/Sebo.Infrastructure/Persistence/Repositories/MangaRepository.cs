using Sebo.Core.Entities;
using Sebo.Core.Repositories;

namespace Sebo.Infrastructure.Persistence.Repositories
{
    public class MangaRepository : MainRepository<Manga>, IMangaRepository
    {
        public MangaRepository(SeboDbContext Context) : base(Context)
        {
        }
    }
}
