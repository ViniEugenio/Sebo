using AutoMapper;
using MediatR;
using Sebo.Application.ViewModels.UserViewModels;
using Sebo.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Queries.UserDetail
{
    public class UserDetailQueryHandler : IRequestHandler<UserDetailQuery, UserDetailViewModel>
    {

        private readonly IMapper Mapper;
        private readonly IUserRepository UserRepository;

        public UserDetailQueryHandler(IMapper Mapper, IUserRepository UserRepository)
        {
            this.Mapper = Mapper;
            this.UserRepository = UserRepository;
        }

        public async Task<UserDetailViewModel> Handle(UserDetailQuery request, CancellationToken cancellationToken)
        {
            var FoundedUser = await UserRepository.GetUserById(request.Id);
            return Mapper.Map<UserDetailViewModel>(FoundedUser);
        }
    }
}
