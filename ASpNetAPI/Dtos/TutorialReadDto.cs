using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Dtos
{
    public class TutorialReadDto
    {
        public long ID
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool Published
        {
            get;
            set;
        }
    }
}
