using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class Doc
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Doc(string title, string path, DateTime dataCreted, DateTime dateModified) 
        { 
            Title = title;
            Path = path;
            DateCreated = dataCreted;
            DateModified = dateModified;
        }
        public Doc() { }
    }
}
