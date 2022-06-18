using Microsoft.AspNetCore.Mvc;
using Sebo.ImageService.Persistence.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sebo.ImageService.Controllers
{

    [Route("api/image")]
    public class ImageController : Controller
    {

        private readonly IFileRepository FileRepository;

        public ImageController(IFileRepository FileRepository)
        {
            this.FileRepository = FileRepository;
        }


        [HttpGet("{ChapterId}")]
        public async Task<IActionResult> GetAllChapterFiles(Guid ChapterId)
        {

            var FoundedFiles = await FileRepository.GetAllChaptersFile(ChapterId);
            if (!FoundedFiles.Any())
            {
                return NotFound("Não foram encontrados arquivos referentes ao capítulo");
            }

            return Ok(FoundedFiles);

        }


    }
}
