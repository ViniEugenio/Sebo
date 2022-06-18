using MediatR;
using Sebo.Application.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace Sebo.Application.Queries.ListUsers
{
    public class ListUsersQuery : IRequest<List<UserDetailViewModel>>
    {
    }
}
