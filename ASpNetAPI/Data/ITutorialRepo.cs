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
        Tutorial GetTutorialById(long id);
        void CreateTutorial(Tutorial tutorial);
        void UpdateTutorial(Tutorial tutorial);
        void DeleteTutorial(Tutorial tutorial);
        void DeleteAllTutorial(IEnumerable<Tutorial> tutorial);
    }
}
