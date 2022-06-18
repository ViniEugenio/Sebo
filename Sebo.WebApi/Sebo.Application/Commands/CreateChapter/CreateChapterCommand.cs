using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Sebo.Application.Commands.CreateChapter
{

    public class CreateChapterCommand : IRequest<Guid>
    {

        public Guid MangaId { get; set; }
        public string Title { get; set; }
        public List<IFormFile> Images { get; set; }

    }

}
