using MediatR;
using Sebo.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace Sebo.Application.Queries.GetAllChapterFiles
{
    public class GetAllChapterFilesQuery : IRequest<List<ChapterFileViewModel>>
    {

        public Guid ChapterId { get; set; }

        public GetAllChapterFilesQuery(Guid ChapterId)
        {
            this.ChapterId = ChapterId;
        }

    }
}
