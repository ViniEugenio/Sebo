using System;
using System.Collections.Generic;

namespace Sebo.Core.IntegrationEvents
{

    public class ChapterFileIntegrationEvent
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
