using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Models
{
    public interface ITutorial
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }

    }
}
