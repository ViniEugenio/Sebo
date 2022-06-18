using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sebo.Core.Entities;
using Sebo.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IdentityResult>
    {

        private readonly IMapper Mapper;
        private readonly IUserRepository UserRepository;

        public CreateUserCommandHandler(IMapper Mapper, IUserRepository UserRepository)
        {

            this.Mapper = Mapper;
            this.UserRepository = UserRepository;

        }

        public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var NewUser = Mapper.Map<User>(request);

            NewUser.CreatedDate = DateTime.Now;
            NewUser.UpdatedDate = DateTime.Now;
            NewUser.IsDeleted = false;

            return await UserRepository.CreateUser(NewUser, request.Password);

        }

    }
}
