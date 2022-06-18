using MediatR;
using Sebo.Core.Entities;
using Sebo.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Queries.GetAllMangas
{
    public class GetAllMangasQueryHandler : IRequestHandler<GetAllMangasQuery, List<Manga>>
    {

        private readonly IMangaRepository MangaRepository;

        public GetAllMangasQueryHandler(IMangaRepository MangaRepository)
        {
            this.MangaRepository = MangaRepository;
        }

        public async Task<List<Manga>> Handle(GetAllMangasQuery request, CancellationToken cancellationToken)
        {
            return await MangaRepository.GetAll();
        }

    }
}
