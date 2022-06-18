using System;

namespace Sebo.ImageService.Persistence.Entities
{
    public class File
    {

        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsDeleted { get; set; }

    }
}
