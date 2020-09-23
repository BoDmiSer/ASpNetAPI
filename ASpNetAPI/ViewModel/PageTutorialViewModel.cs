using ASpNetAPI.Models;
using ASpNetAPI.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.ViewModel
{
    public class PageTutorialViewModel<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Tutorials { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        private PageTutorialViewModel(int TotalItems, IEnumerable<T> Tutorials, int CurrentPage, int TotalPages)
        {
            this.TotalItems = TotalItems;
            this.Tutorials = Tutorials;
            this.CurrentPage = CurrentPage;
            this.TotalPages = TotalPages;
        }
        public static PageTutorialViewModel<T> Create(IEnumerable<T> Tutorials, int page, int size)
        {
            PageTutorialList<T> PaginationTutorials;
            PaginationTutorials = PageTutorialList<T>.Create(Tutorials, page, size);
            return new PageTutorialViewModel<T>(PaginationTutorials.TotalItems, PaginationTutorials,PaginationTutorials.CurrentPage,PaginationTutorials.TotalPages);
        }
    }
}
