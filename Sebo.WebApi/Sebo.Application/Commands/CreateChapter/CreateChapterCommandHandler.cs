using AutoMapper;
using MediatR;
using Sebo.Core.Entities;
using Sebo.Core.Enums;
using Sebo.Core.Repositories;
using Sebo.Core.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Commands.CreateChapter
{
    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, Guid>
    {

        private readonly IMapper Mapper;
        private readonly IImageService ImageService;
        private readonly IChapterRepository ChapterRepository;

        public CreateChapterCommandHandler(IMapper Mapper, IImageService ImageService, IChapterRepository ChapterRepository)
        {

            this.Mapper = Mapper;
            this.ImageService = ImageService;
            this.ChapterRepository = ChapterRepository;

        }

        public async Task<Guid> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {

            var NewChapter = Mapper.Map<Chapter>(request);

            NewChapter.ProcessingStatus = ChapterProcessingStatusEnum.Processing;
            await ChapterRepository.Add(NewChapter);

            ImageService.UploadImages(NewChapter.Id, request.Images);

            return NewChapter.Id;

        }
    }
}
