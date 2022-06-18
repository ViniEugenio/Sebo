using Microsoft.EntityFrameworkCore;
using Sebo.ImageService.DTOs;
using Sebo.ImageService.Persistence.Entities;
using Sebo.ImageService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sebo.ImageService.Persistence.Repositories
{
    public class FileRepository : MainRepository<File>, IFileRepository
    {

        public FileRepository(Context Context) : base(Context)
        {
        }

        public async Task AddChapterFiles(List<File> chapterFiles)
        {
            await Db.AddRangeAsync(chapterFiles);
            await SaveChanges();
        }

        public async Task<List<ChapterFileDTO>> GetAllChaptersFile(Guid ChapterId)
        {

            var FoundedFiles = await Db.Where(file => file.ChapterId == ChapterId).ToListAsync();

            return FoundedFiles.Select(file => new ChapterFileDTO()
            {
                Order = file.Order,
                Url = file.Url
            }).ToList();

        }

    }
}
