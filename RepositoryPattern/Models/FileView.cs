using Microsoft.AspNetCore.Http;
using RepositoryPattern_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class FileView
    {
        public IEnumerable<File> Files { get; set; }
        public IFormFile File { get; set; }
    }
}
