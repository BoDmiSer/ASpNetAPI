using ASpNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Data
{
    public class MySQTutorialRepo : ITutorialRepo
    {
        private readonly ASpNetAPIContext _context;

        public MySQTutorialRepo(ASpNetAPIContext context)
        {
            _context = context;
        }

        public void CreateTutorial(Tutorial tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Tutorial.Add(tutorial);
        }

        public void DeleteAllTutorial(IEnumerable<Tutorial> tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Tutorial.RemoveRange(tutorial);
        }

        public void DeleteTutorial(Tutorial tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            _context.Tutorial.Remove(tutorial);
        }

        public IEnumerable<Tutorial> GetAllTutorial()
        {
            return _context.Tutorial.ToList();
        }

        public Tutorial GetTutorialById(long id)
        {
            return _context.Tutorial.FirstOrDefault(k => k.ID == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateTutorial(Tutorial tutorial)
        {
            //throw new NotImplementedException();
        }
    }
}
