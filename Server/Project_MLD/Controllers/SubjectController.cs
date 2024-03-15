using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _repository;

        public SubjectController(ISubjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            var Subjects = await _repository.GetAllSubjects();
            return Ok(Subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var Subject = await _repository.GetSubjectById(id);
            if (Subject == null)
            {
                return NotFound();
            }

            return Ok(Subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject(Subject sub)
        {
            await _repository.AddSubject(sub);
            return CreatedAtAction(nameof(GetSubjectById), new { id = sub.Id }, sub);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _repository.DeleteSubject(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, Subject sub)
        {
            if (id != sub.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateSubject(sub);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
