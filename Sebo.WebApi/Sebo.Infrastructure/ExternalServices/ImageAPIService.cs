using Microsoft.Extensions.Configuration;
using Sebo.Core.Helpers;
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

        public ImageAPIService(IConfiguration Configuration)
            : base(Configuration.GetSection("ExternalServices:ImagesAPI").Value)
        {
        }

        public async Task<List<ChapterFileViewModel>> GetAllChapterFiles(Guid ChapterId)
        {

            var Response = await Get(ChapterId.ToString());

            if (Response.IsSuccessStatusCode)
            {
                return await HttpClientHelper.FormatResponse<List<ChapterFileViewModel>>(Response);
            }

            return null;

        }

    }
}
