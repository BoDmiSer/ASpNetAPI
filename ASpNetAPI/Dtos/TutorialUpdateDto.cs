using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Dtos
{
    public class TutorialUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
    }
}
