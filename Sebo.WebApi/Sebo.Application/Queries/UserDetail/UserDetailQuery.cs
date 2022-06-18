using MediatR;
using Sebo.Application.ViewModels.UserViewModels;

namespace Sebo.Application.Queries.UserDetail
{
    public class UserDetailQuery : IRequest<UserDetailViewModel>
    {
        public string Id { get; set; }

        public UserDetailQuery(string Id)
        {
            this.Id = Id;
        }
    }
}
