using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern_BOL
{
    public class UserFile
    {
        public long FileID { get; set; }
        public File File { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
