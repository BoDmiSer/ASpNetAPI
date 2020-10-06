using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    interface ITutorialRepoAsync<T> where T : ITutorial
    {
        bool SaveChanges();
        Task<IEnumerable<Tutorial>> GetAllTutorial();
        Task<IEnumerable<Tutorial>> GetTutorialByPublished();
        Task<IEnumerable<Tutorial>> GetTutorialByPublished(string title);
        Task<IEnumerable<Tutorial>> GetTutorialByTitle(string title);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> tutorial);
        Task<Tutorial> GetTutorialById(long id);
        Task CreateTutorial(Tutorial tutorial);
        Task UpdateTutorial(Tutorial tutorial);
        Task DeleteTutorial(Tutorial tutorial);
        Task DeleteAllTutorial(IEnumerable<Tutorial> tutorial);
    }
}
