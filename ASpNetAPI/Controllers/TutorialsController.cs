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
using ASpNetAPI.Pagination;
using ASpNetAPI.ViewModel;

namespace ASpNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialsController : ControllerBase
    {
        private readonly ASpNetAPIContext _context;
        private readonly IMapper _mapper;

        //private readonly MockTutorialRepo _repo = new MockTutorialRepo();

        private readonly ITutorialRepo<Tutorial> _repo;
        private readonly ITutorialRepoAsync<Tutorial> _repoasync;

        public TutorialsController(ITutorialRepo<Tutorial> repository, ITutorialRepoAsync<Tutorial> repositoryasync, ASpNetAPIContext context, IMapper mapper)
        {
            _repo = repository;
            _repoasync = repositoryasync;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PageTutorialDto>> GetTutorial(string title, int page = 0, int size = 4)
        {
            IEnumerable<Tutorial> Tutorials;
            if (title == null)
            {
                Tutorials = await _repoasync.GetAllTutorialAsync();
            }
            else
            {
                Tutorials = await _repoasync.GetTutorialByTitleAsync(title);
            }
            PageTutorialViewModel<Tutorial> PaginationTutorialViewModel;
            PaginationTutorialViewModel = PageTutorialViewModel<Tutorial>.Create(Tutorials, page,size);
            return Ok(_mapper.Map<PageTutorialDto>(PaginationTutorialViewModel));
        }

        // GET: api/Tutorials/5
        [HttpGet("{id}", Name = "GetTutorialById")]
        public async Task<ActionResult<TutorialReadDto>> GetTutorialById(long id)
        {
            var tutorial = await _repoasync.GetTutorialByIdAsync(id);

            if (tutorial == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TutorialReadDto>(tutorial));
        }

        [HttpGet("published")]
        public async Task<ActionResult<PageTutorialDto>> GetTutorialByPublished(string title, int page = 0, int size = 4)
        {
            IEnumerable<Tutorial> Tutorials;
            if (title == null)
            {
                Tutorials = await _repoasync.GetTutorialByPublishedAsync();
            }
            else
            {
                Tutorials = await _repoasync.GetTutorialByPublishedAsync(title);
            }
            PageTutorialViewModel<Tutorial> PaginationTutorialViewModel;
            PaginationTutorialViewModel = PageTutorialViewModel<Tutorial>.Create(Tutorials, page, size);
            return Ok(_mapper.Map<PageTutorialDto>(PaginationTutorialViewModel));
        }

        //Put api/Tutorial/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTutorial(long id, TutorialUpdateDto tutorialUpdateDto)
        {
            var tutorialModelFromRepo = await _repoasync.GetTutorialByIdAsync(id);
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(tutorialUpdateDto, tutorialModelFromRepo);
            await _repoasync.UpdateTutorialAsync(tutorialModelFromRepo);
            await _repoasync.SaveChangesAsync();
            return NoContent();
        }


        // POST: api/Tutorials
        [HttpPost]
        public async Task<ActionResult<TutorialReadDto>> CreateCommand(TutorialCreateDto createtutorial)
        {
            var tutorialModel = _mapper.Map<Tutorial>(createtutorial);
            await _repoasync.CreateTutorialAsync(tutorialModel);
            await _repoasync.SaveChangesAsync();
            var tutorialReadDto = _mapper.Map<TutorialReadDto>(tutorialModel);

            return CreatedAtRoute(nameof(GetTutorialById), new { Id = tutorialReadDto.ID }, tutorialReadDto);

        }


        //PATCH api/Tutotrials/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialTutorialUpdate(long id, JsonPatchDocument<TutorialUpdateDto> patchDocument)
        {
            var tutorialModelFromRepo = await _repoasync.GetTutorialByIdAsync(id);
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
            await _repoasync.UpdateTutorialAsync(tutorialModelFromRepo);
            await _repoasync.SaveChangesAsync();
            return NoContent();

        }

        // DELETE: api/Tutorials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTutorialById(long id)
        {
            var tutorialModelFromRepo = await _repoasync.GetTutorialByIdAsync(id);
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            await _repoasync.DeleteTutorialAsync(tutorialModelFromRepo);
            await _repoasync.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Tutorials
        [HttpDelete]
        public async Task<ActionResult> DeleteTutorial()
        {
            var tutorialModelFromRepo = await _repoasync.GetAllTutorialAsync();
            if (tutorialModelFromRepo == null)
            {
                return NotFound();
            }
            await _repoasync.DeleteAllTutorialAsync(tutorialModelFromRepo);
            await _repoasync.SaveChangesAsync();
            return NoContent();
        }

        private bool TutorialExists(long id)
        {
            return _context.Tutorial.Any(e => e.ID == id);
        }
    }
}
