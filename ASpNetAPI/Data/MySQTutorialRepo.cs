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
        public async Task CreateTutorialAsync(T tutorial)
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
        public Task DeleteAllTutorialAsync(IEnumerable<T> tutorial)
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
        public Task DeleteTutorialAsync(T tutorial)
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
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> tutorial)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(tutorial);
        }



        public IEnumerable<T> GetAllTutorial()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllTutorialAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public T GetTutorialById(long id)
        {
            return _context.Set<T>().First(k => k.ID == id);
        }
        public async Task<T> GetTutorialByIdAsync(long id)
        {
            return await _context.Set<T>().FirstAsync(k => k.ID == id);
        }



        public IEnumerable<T> GetTutorialByPublished()
        {
            return _context.Set<T>().Where(published => published.Published == true).ToList();
        }
        public async Task<IEnumerable<T>> GetTutorialByPublishedAsync()
        {
            return await _context.Set<T>().Where(published => published.Published == true).ToListAsync();
        }



        public IEnumerable<T> GetTutorialByPublished(string title)
        {
            return _context.Set<T>().Where(published => (published.Published == true)&&(published.Title == title)).ToList();
        }
        public async Task<IEnumerable<T>> GetTutorialByPublishedAsync(string title)
        {
            return await _context.Set<T>().Where(published => (published.Published == true) && (published.Title == title)).ToListAsync();
        }



        public IEnumerable<T> GetTutorialByTitle(string title)
        {
            return _context.Set<T>().Where(tutorial => tutorial.Title == title).ToList();
        }
        public async Task<IEnumerable<T>> GetTutorialByTitleAsync(string title)
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
        public Task UpdateTutorialAsync(T tutorial)
        {
            _context.Entry(tutorial).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }    
    }
}
