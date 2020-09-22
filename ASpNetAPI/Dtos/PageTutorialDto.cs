using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Dtos
{
    public class PageTutorialDto
    {
        public int TotalItems { get; set; }
        public IEnumerable<TutorialReadDto> Tutorials { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
