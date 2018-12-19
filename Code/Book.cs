using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Model
{
   public  class Book : Document
    {        
        public string Author { get; set; }
        public string Series { get; set; }
        public int NumberInTheSeries { get; set; }
    }
}
