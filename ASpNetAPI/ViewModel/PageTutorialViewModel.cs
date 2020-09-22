using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.ViewModel
{
    public class PageTutorialViewModel
    {
        public int TotalItems { get; set; }
        public IEnumerable<Tutorial> Tutorials { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
