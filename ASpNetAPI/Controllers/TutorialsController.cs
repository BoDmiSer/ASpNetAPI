using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASpNetAPI.Data;
using ASpNetAPI.Models;
using AutoMapper;
using ASpNetAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace ASpNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialsController : ControllerBase
    {
        private readonly ASpNetAPIContext _context;
        private readonly IMapper _mapper;

        //private readonly MockTutorialRepo _repo = new MockTutorialRepo();

        private readonly ITutorialRepo _repo;

        public TutorialsController(ITutorialRepo repository, ASpNetAPIContext context, IMapper mapper)
        {
            _repo = repository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TutorialReadDto>> GetTutorial(string title)
        {
            IEnumerable<Tutorial> Tutorials;
            if (title == null)
            {
                Tutorials = _repo.GetAllTutorial();
            }
            else
            {
                Tutorials = _repo.GetTutorialByTitle(title);
            }
            return Ok(_mapper.Map<IEnumerable<TutorialReadDto>>(Tutorials));
        }

        // GET: api/Tutorials/5
        [HttpGet("{id}", Name = "GetTutorialById")]
        public ActionResult<TutorialReadDto> GetTutorialById(long id)
        {
            var tutorial = _repo.GetTutorialById(id);

            if (tutorial == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TutorialReadDto>(tutorial));
        }
               
        //Put api/Tutorial/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTutorial(long id, TutorialUpdateDto tutorialUpdateDto)
        {
            var tutorialModelFromRepo = _repo.GetTutorialById(id);
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(tutorialUpdateDto, tutorialModelFromRepo);
            _repo.UpdateTutorial(tutorialModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }


        // POST: api/Tutorials
        [HttpPost]
        public ActionResult<TutorialReadDto> CreateCommand(TutorialCreateDto createtutorial)
        {
            var tutorialModel = _mapper.Map<Tutorial>(createtutorial);
            _repo.CreateTutorial(tutorialModel);
            _repo.SaveChanges();
            var tutorialReadDto = _mapper.Map<TutorialReadDto>(tutorialModel);

            return CreatedAtRoute(nameof(GetTutorialById), new { Id = tutorialReadDto.ID }, tutorialReadDto);

        }


        //PATCH api/Tutotrials/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTutorialUpdate(long id, JsonPatchDocument<TutorialUpdateDto> patchDocument)
        {
            var tutorialModelFromRepo = _repo.GetTutorialById(id);
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            var tutorialToPath = _mapper.Map<TutorialUpdateDto>(tutorialModelFromRepo);
            patchDocument.ApplyTo(tutorialToPath, ModelState);
            if (!TryValidateModel(tutorialToPath))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(tutorialToPath, tutorialModelFromRepo);
            _repo.UpdateTutorial(tutorialModelFromRepo);
            _repo.SaveChanges();
            return NoContent();

        }

        // DELETE: api/Tutorials/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTutorialById(long id)
        {
            var tutorialModelFromRepo = _repo.GetTutorialById(id);
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteTutorial(tutorialModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Tutorials
        [HttpDelete]
        public ActionResult DeleteTutorial()
        {
            var tutorialModelFromRepo = _repo.GetAllTutorial();
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteAllTutorial(tutorialModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        private bool TutorialExists(long id)
        {
            return _context.Tutorial.Any(e => e.ID == id);
        }
    }
}
