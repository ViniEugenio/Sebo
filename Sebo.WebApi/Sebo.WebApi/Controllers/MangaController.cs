using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sebo.Application.Commands.CreateChapter;
using Sebo.Application.Commands.CreateManga;
using Sebo.Application.Queries.GetAllChapterFiles;
using Sebo.Core.Helpers.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sebo.WebApi.Controllers
{

    [Route("api/manga")]
    [Authorize]
    public class MangaController : Controller
    {

        private readonly IMediator Mediator;

        public MangaController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManga([FromBody] CreateMangaCommand Command)
        {

            Guid response = await Mediator.Send(Command);
            return Ok(new
            {
                Message = MangaMessages.MangaCreated,
                MangaId = response
            });

        }

        [HttpPost("AddChapter")]
        public async Task<IActionResult> AddChapter([FromForm] CreateChapterCommand Command)
        {

            var response = await Mediator.Send(Command);
            return Ok();

        }

        [HttpGet("GetAllChapterFiles/{ChapterId}")]
        public async Task<IActionResult> GetAllChapterFiles(Guid ChapterId)
        {

            var FoundedFiles = await Mediator.Send(new GetAllChapterFilesQuery(ChapterId));
            if (FoundedFiles == null)
            {
                return NotFound(MangaMessages.NotFoundedFiles);
            }

            return Ok(FoundedFiles);

        }

    }
}
