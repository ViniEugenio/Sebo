using AutoMapper;
using MediatR;
using Sebo.Application.ViewModels.UserViewModels;
using Sebo.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Queries.ListUsers
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<UserDetailViewModel>>
    {

        IMapper Mapper;
        private readonly IUserRepository UserRepository;

        public ListUsersQueryHandler(IMapper Mapper, IUserRepository UserRepository)
        {
            this.Mapper = Mapper;
            this.UserRepository = UserRepository;
        }

        public async Task<List<UserDetailViewModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var FoundedUsers = await UserRepository.GetAllWithExpression(user => !user.IsDeleted);
            return Mapper.Map<List<UserDetailViewModel>>(FoundedUsers);
        }
    }
}
