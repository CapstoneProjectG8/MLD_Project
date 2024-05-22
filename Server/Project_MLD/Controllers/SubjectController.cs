using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
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
        private readonly IMapper _mapper;
        public SubjectController(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        [HttpGet("GetSubjectByDepartmentId")]
        public async Task<ActionResult<Subject>> GetSubjectByDepartmentId(int id)
        {
            var Subject = await _repository.GetSubjectsByDepartmentId(id);
            if (Subject == null)
            {
                return NotFound();
            }

            return Ok(Subject);
        }

        [HttpPost("AddSubject")]
        public async Task<ActionResult<Subject>> AddSubject(SubjectDTO sub)
        {
            var mapper = _mapper.Map<Subject>(sub);
            await _repository.AddSubject(mapper);
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

        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(SubjectDTO sub)
        {

            var mapper = _mapper.Map<Subject>(sub);
            var result = await _repository.UpdateSubject(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
