using Sebo.Core.Entities;
using Sebo.Core.Repositories;

namespace Sebo.Infrastructure.Persistence.Repositories
{
    public class ChapterRepository : MainRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(SeboDbContext Context) : base(Context)
        {
        }
    }
}
