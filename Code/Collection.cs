using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Model
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateСreation { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
