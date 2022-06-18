using Sebo.ImageService.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sebo.ImageService.Persistence.Interfaces
{
    public interface IFileRepository : IMainRepository<Entities.File>
    {
        Task AddChapterFiles(List<Entities.File> chapterFiles);
        Task<List<ChapterFileDTO>> GetAllChaptersFile(Guid ChapterId);
    }
}
