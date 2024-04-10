using AutoMapper;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _repository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllClasss()
        {
            var classes = await _repository.GetAllClasss();
            var mapClass = _mapper.Map<List<Class>>(classes);
            return Ok(mapClass);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var exClass = await _repository.GetClassById(id);
            if (exClass == null)
            {
                return NotFound();
            }

            return Ok(exClass);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> AddClass(Class cl)
        {
            await _repository.AddClass(cl);
            return CreatedAtAction(nameof(GetClassById), new { id = cl.Id }, cl);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var result = await _repository.DeleteClass(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, Class cl)
        {
            if (id != cl.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateClass(cl);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
