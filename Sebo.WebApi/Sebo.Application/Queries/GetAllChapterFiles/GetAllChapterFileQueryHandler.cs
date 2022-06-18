using MediatR;
using Sebo.Core.Services;
using Sebo.Core.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Queries.GetAllChapterFiles
{
    public class GetAllChapterFileQueryHandler : IRequestHandler<GetAllChapterFilesQuery, List<ChapterFileViewModel>>
    {

        private readonly IImageAPIService ImageAPIService;

        public GetAllChapterFileQueryHandler(IImageAPIService ImageAPIService)
        {
            this.ImageAPIService = ImageAPIService;
        }

        public async Task<List<ChapterFileViewModel>> Handle(GetAllChapterFilesQuery request, CancellationToken cancellationToken)
        {

            return await ImageAPIService.GetAllChapterFiles(request.ChapterId);

        }

    }
}
