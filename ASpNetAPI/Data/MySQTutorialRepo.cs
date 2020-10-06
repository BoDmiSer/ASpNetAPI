using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public class MySQTutorialRepo<T> : ITutorialRepo<T> where T: class, ITutorial
    {
        private readonly ASpNetAPIContext _context;

        public MySQTutorialRepo(ASpNetAPIContext context)
        {
            _context = context;
        }

        public void CreateTutorial(T tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().Add(tutorial);
        }
        public void DeleteAllTutorial(IEnumerable<T> tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().RemoveRange(tutorial);
        }

        public void DeleteTutorial(T tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().Remove(tutorial);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> tutorial)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllTutorial()
        {
            return _context.Set<T>().ToList();
        }

        public T GetTutorialById(long id)
        {
            return _context.Set<T>().FirstOrDefault(k => k.ID == id);
        }

        public IEnumerable<T> GetTutorialByPublished()
        {
            return _context.Set<T>().Where(published => published.Published == true).ToList();
        }

        public IEnumerable<T> GetTutorialByPublished(string title)
        {
            return _context.Set<T>().Where(published => (published.Published == true)&&(published.Title == title)).ToList();
        }

        public IEnumerable<T> GetTutorialByPublished(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetTutorialByTitle(string title)
        {
            return _context.Set<T>().Where(tutorial => tutorial.Title == title).ToList();
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateTutorial(T tutorial)
        {
            //throw new NotImplementedException();
        }

        T ITutorialRepo<T>.GetTutorialById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
