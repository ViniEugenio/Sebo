using Microsoft.AspNetCore.Identity;
using Sebo.Core.Entities;
using System.Threading.Tasks;

namespace Sebo.Core.Repositories
{
    public interface IUserRepository : IMainRepository<User>
    {
        Task<User> GetUserById(string Id);
        Task<IdentityResult> CreateUser(User user, string Password);
        Task<User> GetLoggedUser();
    }
}
