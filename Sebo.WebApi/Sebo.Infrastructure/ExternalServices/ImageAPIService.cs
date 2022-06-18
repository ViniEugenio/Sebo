using Sebo.Core.Services;
using Sebo.Core.ViewModels;
using Sebo.Infrastructure.ExternalServices.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sebo.Infrastructure.ExternalServices
{
    public class ImageAPIService : ClientService, IImageAPIService
    {

        public ImageAPIService() : base("")
        {
        }

        public Task<List<ChapterFileViewModel>> GetAllChapterFiles(Guid ChapterId)
        {
            return Get<List<ChapterFileViewModel>>(ChapterId.ToString());
        }

    }
}
