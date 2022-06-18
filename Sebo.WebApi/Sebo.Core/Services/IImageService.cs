using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Sebo.Core.Services
{
    public interface IImageService
    {

        void UploadImages(Guid ChapterId, List<IFormFile> Files);

    }
}
