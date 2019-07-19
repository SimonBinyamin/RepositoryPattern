using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryPattern_BOL
{
    public class File
    {
        [Key]
        public long FileID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double? Size { get; set; }

        public byte[] FileByte { get; set; }

        public DateTime Date { get; set; }


    }
}
