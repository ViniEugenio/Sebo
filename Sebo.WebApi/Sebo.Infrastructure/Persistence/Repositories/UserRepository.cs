using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sebo.Core.Entities;
using Sebo.Core.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Sebo.Infrastructure.Persistence.Repositories
{
    public class UserRepository : MainRepository<User>, IUserRepository
    {

        private readonly UserManager<User> UserManager;
        private readonly IHttpContextAccessor HttpContext;

        public UserRepository(SeboDbContext Context, UserManager<User> UserManager, IHttpContextAccessor HttpContext) : base(Context)
        {
            this.UserManager = UserManager;
            this.HttpContext = HttpContext;
        }

        public async Task<IdentityResult> CreateUser(User user, string Password)
        {
            return await UserManager.CreateAsync(user, Password);
        }

        public async Task<User> GetLoggedUser()
        {
            return await UserManager.FindByEmailAsync(HttpContext.HttpContext.User.Claims.Single(claim => claim.Type.Equals("Email")).Value);
        }

        public async Task<User> GetUserById(string Id)
        {
            return await DbSet.FindAsync(Id);
        }
    }
}
