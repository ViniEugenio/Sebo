using MediatR;
using Sebo.Core.Entities;
using Sebo.Core.Enums;
using System;

namespace Sebo.Application.Commands.CreateManga
{
    public class CreateMangaCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Designer { get; set; }
        public MangaStatusEnum Status { get; set; }
    }
}
