using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public interface ITutorialRepo
    {
        bool SaveChanges();
        IEnumerable<Tutorial> GetAllTutorial();
        IEnumerable<Tutorial> GetTutorialByPublished();
        IEnumerable<Tutorial> GetTutorialByPublished(string title);
        IEnumerable<Tutorial> GetTutorialByTitle(string title);
        Tutorial GetTutorialById(long id);
        void CreateTutorial(Tutorial tutorial);
        void UpdateTutorial(Tutorial tutorial);
        void DeleteTutorial(Tutorial tutorial);
        void DeleteAllTutorial(IEnumerable<Tutorial> tutorial);
    }
}
