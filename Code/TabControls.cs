using CodeHeapOfBooks.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeHeapOfBooks.Model
{
    public  class TabControls
    {
        public string Header { get; set; }
        public BindableBase ContentTab { get; set; }

        public TabControls(string header, BindableBase contentTab)
        {
            this.Header = header;
            this.ContentTab = contentTab;
        }
    }
}
