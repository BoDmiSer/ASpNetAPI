using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public interface ITutorialRepoAsync<T> where T : ITutorial
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<T>> GetAllTutorialAsync();
        Task<IEnumerable<T>> GetTutorialByPublishedAsync();
        Task<IEnumerable<T>> GetTutorialByPublishedAsync(string title);
        Task<IEnumerable<T>> GetTutorialByTitleAsync(string title);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> tutorial);
        Task<T> GetTutorialByIdAsync(long id);
        Task CreateTutorialAsync(T tutorial);
        Task UpdateTutorialAsync(T tutorial);
        Task DeleteTutorialAsync(T tutorial);
        Task DeleteAllTutorialAsync(IEnumerable<T> tutorial);
    }
}
