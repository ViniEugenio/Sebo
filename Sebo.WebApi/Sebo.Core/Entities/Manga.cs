using Sebo.Core.Enums;
using System;
using System.Collections.Generic;

namespace Sebo.Core.Entities
{
    public class Manga : BaseEntity
    {

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Designer { get; set; }
        public MangaStatusEnum Status { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public List<Chapter> Chapter { get; set; }

    }
}
