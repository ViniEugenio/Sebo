using Sebo.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sebo.Core.Services
{
    public interface IImageAPIService
    {
        Task<List<ChapterFileViewModel>> GetAllChapterFiles(Guid ChapterId);
    }
}
