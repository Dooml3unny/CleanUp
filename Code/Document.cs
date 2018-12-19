using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateСreation { get; set; }
        public DateTime DateLastChange { get; set; }
        public string FilePath { get; set; }

        public int? CollectionId { get; set; }
        public virtual Collection Collection { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }

    }
}
