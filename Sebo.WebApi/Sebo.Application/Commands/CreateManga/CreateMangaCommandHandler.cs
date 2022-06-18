using AutoMapper;
using MediatR;
using Sebo.Core.Entities;
using Sebo.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Commands.CreateManga
{
    internal class CreateMangaCommandHandler : IRequestHandler<CreateMangaCommand, Guid>
    {

        private readonly IMapper Mapper;
        private readonly IMangaRepository MangaRepository;
        private readonly IUserRepository UserRepository;

        public CreateMangaCommandHandler(IMapper Mapper, IMangaRepository MangaRepository, IUserRepository UserRepository)
        {

            this.Mapper = Mapper;
            this.MangaRepository = MangaRepository;
            this.UserRepository = UserRepository;

        }

        public async Task<Guid> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
        {

            var NewManga = Mapper.Map<Manga>(request);

            var FoundedUser = await UserRepository.GetLoggedUser();
            NewManga.UserId = FoundedUser.Id;

            await MangaRepository.Add(NewManga);

            return NewManga.Id;

        }
    }
}
