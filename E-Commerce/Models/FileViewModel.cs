using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{

    public class File
    {
        public string name { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteUrl { get; set; }
        public string deleteType { get; set; }
    }

    public class FileList
    {
        public List<File> files = new List<File>();
    }
}
