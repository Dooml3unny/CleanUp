using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Model
{
    class UserContext : DbContext
    {
        public UserContext()
               : base("HeapOfBooksContext")
        { }

        public DbSet<Commit> Commits { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Collection> Collections { get; set; }

    }
}
