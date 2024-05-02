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

        [HttpGet("GetAllClasses")]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllClasses()
        {
            var classes = await _repository.GetAllClasss();
            var mapClass = _mapper.Map<List<ClassDTO>>(classes);
            return Ok(mapClass);
        }

        [HttpGet("GetClassById/{id}")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var exClass = await _repository.GetClassById(id);
            if (exClass == null)
            {
                return NotFound();
            }
            var _mapperClass = _mapper.Map<Class>(exClass);
            return Ok(_mapperClass);
        }

        [HttpGet("GetClassByGradeId/{Gradeid}")]
        public async Task<ActionResult<Class>> GetClassByGradeId(int Gradeid)
        {
            var exClass = await _repository.GetClassesByGradeId(Gradeid);
            if (exClass == null)
            {
                return NotFound();
            }
            return Ok(exClass);
        }

        //[HttpPost]
        //public async Task<ActionResult<Class>> AddClass(ClassDTO classDTO)
        //{
        //    var _mapperClass = _mapper.Map<Class>(classDTO);
        //    await _repository.AddClass(_mapperClass);
        //    return CreatedAtAction(nameof(GetClassById), new { id = _mapperClass.Id }, _mapperClass);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClass(int id)
        //{
        //    var result = await _repository.DeleteClass(id);
        //    if (!result)
        //    {
        //        return BadRequest("Can Not Delete Class");
        //    }
        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateClass(int id, ClassDTO classDTO)
        //{
        //    if (id != classDTO.Id)
        //    {
        //        return BadRequest("Id Not Match");
        //    }
        //    var _mapperClass = _mapper.Map<Class>(classDTO);
        //    var result = await _repository.UpdateClass(_mapperClass);
        //    if (!result)
        //    {
        //        return NotFound("Can not Update Class");
        //    }
        //    return NoContent();
        //}
    }
}
