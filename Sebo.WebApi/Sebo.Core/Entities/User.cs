using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Sebo.Core.Entities
{
    public class User : IdentityUser
    {

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //Navigation Properties
        public List<Manga> Mangas { get; set; }

    }
}
