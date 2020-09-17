using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public class MockTutorialRepo : ITutorialRepo
    {
        public void CreateTutorial(Tutorial tutorial)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllTutorial(IEnumerable<Tutorial> tutorial)
        {
            throw new NotImplementedException();
        }

        public void DeleteTutorial(Tutorial tutorial)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tutorial> GetAllTutorial()
        {
            var tutorials = new List<Tutorial>
            {
                new Tutorial( 0,  "Zero", "Description_0", false),
                new Tutorial( 1,  "One", "Description_1", false),
                new Tutorial( 2,  "Two", "Description_2", false),
                new Tutorial( 3,  "Three", "Description_3", false),
                new Tutorial( 4,  "For", "Description_4", false),
                new Tutorial( 5,  "Five", "Description_5", false),
                new Tutorial( 6,  "Six", "Description_6", false),
                new Tutorial( 7,  "Seven", "Description_7", false),
        };
            return tutorials;
        }

        public Tutorial GetTutorialById(long id)
        {
            return new Tutorial( 0,  "One", "Description", false);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTutorial(Tutorial tutorial)
        {
            throw new NotImplementedException();
        }
    }
}
