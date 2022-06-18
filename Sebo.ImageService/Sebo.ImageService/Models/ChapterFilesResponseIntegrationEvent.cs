using System;

namespace Sebo.ImageService.Models
{
    public class ChapterFilesResponseIntegrationEvent
    {

        public bool Success { get; set; }
        public Guid ChapterId { get; set; }
        public string Message { get; set; }

        public ChapterFilesResponseIntegrationEvent(bool Success, Guid ChapterId, string Message)
        {

            this.Success = Success;
            this.ChapterId = ChapterId;
            this.Message = Message;

        }

    }
}
