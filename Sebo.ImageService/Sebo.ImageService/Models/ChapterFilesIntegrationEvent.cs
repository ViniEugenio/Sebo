using System;
using System.Collections.Generic;

namespace Sebo.ImageService.Models
{

    public class ChapterFilesIntegrationEvent
    {

        public Guid ChapterId { get; set; }
        public List<FileModel> Files { get; set; }

    }

    public class FileModel
    {

        public byte[] File { get; set; }
        public int Order { get; set; }

    }

}
