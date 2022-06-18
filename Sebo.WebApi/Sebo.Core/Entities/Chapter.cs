using Sebo.Core.Enums;
using System;

namespace Sebo.Core.Entities
{
    public class Chapter : BaseEntity
    {

        public Guid MangaId { get; set; }
        public string Title { get; set; }
        public ChapterProcessingStatusEnum ProcessingStatus { get; set; }

        //Navigation Properties
        public Manga Manga { get; set; }

    }
}
