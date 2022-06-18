using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sebo.Core.IntegrationEvents;
using Sebo.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sebo.Infrastructure.MicroServices
{
    public class ImageService : IImageService
    {

        private readonly IMessageBusService MessageBusService;

        public ImageService(IMessageBusService MessageBusService)
        {
            this.MessageBusService = MessageBusService;
        }

        public void UploadImages(Guid ChapterId, List<IFormFile> Files)
        {

            List<FileModel> FilesModel = new List<FileModel>();
            int Order = 1;

            foreach (var ChapterFile in Files)
            {

                using (var ms = new MemoryStream())
                {

                    ChapterFile.CopyTo(ms);
                    FilesModel.Add(new FileModel()
                    {

                        File = ms.ToArray(),
                        Order = Order

                    });

                }

                Order++;

            }

            MessageBusService.Publish("Images", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new ChapterFileIntegrationEvent()
            {
                ChapterId = ChapterId,
                Files = FilesModel
            })));

        }

    }
}
