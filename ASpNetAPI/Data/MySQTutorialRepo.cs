using ASpNetAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public class MySQTutorialRepo<T> : ITutorialRepo<T>, ITutorialRepoAsync<T> where T: class, ITutorial
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
        async Task ITutorialRepoAsync<T>.CreateTutorial(T tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
           await _context.Set<T>().AddAsync(tutorial);
        }



        public void DeleteAllTutorial(IEnumerable<T> tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().RemoveRange(tutorial);
        }
        Task ITutorialRepoAsync<T>.DeleteAllTutorial(IEnumerable<T> tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().RemoveRange(tutorial);
            return _context.SaveChangesAsync();
        }



        public void DeleteTutorial(T tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().Remove(tutorial);
        }
        Task ITutorialRepoAsync<T>.DeleteTutorial(T tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Set<T>().Remove(tutorial);
            return _context.SaveChangesAsync();
        }



        public T FirstOrDefault(Expression<Func<T, bool>> tutorial)
        {
            return _context.Set<T>().FirstOrDefault(tutorial);
        }
        Task<T> ITutorialRepoAsync<T>.FirstOrDefault(Expression<Func<T, bool>> tutorial)
        {
            return _context.Set<T>().FirstOrDefaultAsync(tutorial);
        }



        public IEnumerable<T> GetAllTutorial()
        {
            return _context.Set<T>().ToList();
        }
        async Task<IEnumerable<T>> ITutorialRepoAsync<T>.GetAllTutorial()
        {
            return await _context.Set<T>().ToListAsync();
        }
        
        
        public T GetTutorialById(long id)
        {
            return _context.Set<T>().First(k => k.ID == id);
        }
        Task<T> ITutorialRepoAsync<T>.GetTutorialById(long id)
        {
            return _context.Set<T>().FirstAsync(k => k.ID == id);
        }



        public IEnumerable<T> GetTutorialByPublished()
        {
            return _context.Set<T>().Where(published => published.Published == true).ToList();
        }
        async Task<IEnumerable<T>> ITutorialRepoAsync<T>.GetTutorialByPublished()
        {
            return await _context.Set<T>().Where(published => published.Published == true).ToListAsync();
        }



        public IEnumerable<T> GetTutorialByPublished(string title)
        {
            return _context.Set<T>().Where(published => (published.Published == true)&&(published.Title == title)).ToList();
        }
        async Task<IEnumerable<T>> ITutorialRepoAsync<T>.GetTutorialByPublished(string title)
        {
            return await _context.Set<T>().Where(published => (published.Published == true) && (published.Title == title)).ToListAsync();
        }



        public IEnumerable<T> GetTutorialByTitle(string title)
        {
            return _context.Set<T>().Where(tutorial => tutorial.Title == title).ToList();
        }
        async Task<IEnumerable<T>> ITutorialRepoAsync<T>.GetTutorialByTitle(string title)
        {
            return await _context.Set<T>().Where(tutorial => tutorial.Title == title).ToListAsync();
        }



        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }
        async Task<bool> ITutorialRepoAsync<T>.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }



        public void UpdateTutorial(T tutorial)
        {
            //throw new NotImplementedException();
        }
        Task ITutorialRepoAsync<T>.UpdateTutorial(T tutorial)
        {
            _context.Entry(tutorial).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }       
    }
}
