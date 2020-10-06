using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public interface ITutorialRepo<T> where T : ITutorial
    {
        bool SaveChanges();
        IEnumerable<T> GetAllTutorial();
        IEnumerable<T> GetTutorialByPublished();
        IEnumerable<T> GetTutorialByPublished(string title);
        IEnumerable<T> GetTutorialByTitle(string title);
        T GetTutorialById(long id);
        T FirstOrDefault(Expression<Func<T, bool>> tutorial);
        void CreateTutorial(T tutorial);
        void UpdateTutorial(T tutorial);
        void DeleteTutorial(T tutorial);
        void DeleteAllTutorial(IEnumerable<T> tutorial);
    }
}
