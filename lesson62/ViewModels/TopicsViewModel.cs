using lesson62.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson62.ViewModels
{
    public class TopicsViewModel
    {
        public IEnumerable<Topic> topics { get; set; }
        public PageViewModel pageViewModel { get; set; }
    }
}
