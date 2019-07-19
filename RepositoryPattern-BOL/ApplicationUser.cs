using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryPattern_BOL
{
    public class ApplicationUser : IdentityUser
    {
        public string First { get; set; }

        public string Last { get; set; }

        [NotMapped]
        public virtual ICollection<UserFile> UserFiles { get; set; }

    }
}
