using MediatR;
using Sebo.Core.Entities;
using System.Collections.Generic;

namespace Sebo.Application.Queries.GetAllMangas
{
    public class GetAllMangasQuery : IRequest<List<Manga>>
    {
    }
}
