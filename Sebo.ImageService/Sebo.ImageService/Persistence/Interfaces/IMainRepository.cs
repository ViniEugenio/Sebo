using System.Threading.Tasks;

namespace Sebo.ImageService.Persistence.Interfaces
{
    public interface IMainRepository<T> where T : class
    {       
        Task Add(T model);
        Task SaveChanges();
    }
}
