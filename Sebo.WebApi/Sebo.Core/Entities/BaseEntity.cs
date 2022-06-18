using System;

namespace Sebo.Core.Entities
{
    public abstract class BaseEntity
    {

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {

            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsDeleted = false;

        }

    }
}
