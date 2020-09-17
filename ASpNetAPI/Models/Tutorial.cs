using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Models
{
    public class Tutorial
    {
        private long id;
        private string title;
        private string description;
        private bool published;

        public Tutorial()
        {

        }
        public Tutorial(long id,string title, string description, bool published)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.published = published;
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public bool Published
        {
            get { return published; }
            set { published = value; }
        }
        public override string ToString()
        {
            return "Tutorial [id=" + id + ",title=" + title + ",desc=" + description + ",published=" + published + "]";
        }
    }
}
