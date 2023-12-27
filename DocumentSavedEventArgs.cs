using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    public class DocumentSavedEventArgs
    {
        public Doc SavedDocument { get; }

        public DocumentSavedEventArgs(Doc savedDocument)
        {
            SavedDocument = savedDocument;
        }
    }
}
