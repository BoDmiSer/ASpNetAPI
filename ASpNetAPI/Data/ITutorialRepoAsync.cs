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
        Task<IEnumerable<T>> GetAllTutorial();
        Task<IEnumerable<T>> GetTutorialByPublished();
        Task<IEnumerable<T>> GetTutorialByPublished(string title);
        Task<IEnumerable<T>> GetTutorialByTitle(string title);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> tutorial);
        Task<T> GetTutorialById(long id);
        Task CreateTutorial(T tutorial);
        Task UpdateTutorial(T tutorial);
        Task DeleteTutorial(T tutorial);
        Task DeleteAllTutorial(IEnumerable<T> tutorial);
    }
}
