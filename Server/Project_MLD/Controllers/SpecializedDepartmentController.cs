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
    public class SpecializedDepartmentController : ControllerBase
    {
        private readonly ISpecializedDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public SpecializedDepartmentController(ISpecializedDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecializedDepartment>>> GetAllSpecializedDepartments()
        {
            var SpecializedDepartments = await _repository.GetAllSpecializedDepartment();
            return Ok(SpecializedDepartments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializedDepartment>> GetSpecializedDepartmentById(int id)
        {
            var existSpecializedDepartment = await _repository.GetSpecializedDepartmentById(id);
            if (existSpecializedDepartment == null)
            {
                return NotFound();
            }

            return Ok(existSpecializedDepartment);
        }

        [HttpPost]
        public async Task<ActionResult<SpecializedDepartment>> AddSpecializedDepartment(SpecializedDepartment st)
        {
            await _repository.AddSpecializedDepartment(st);
            return CreatedAtAction(nameof(GetSpecializedDepartmentById), new { id = st.Id }, st);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecializedDepartment(int id)
        {
            var result = await _repository.DeleteSpecializedDepartment(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateSpecializedDepartment")]
        public async Task<IActionResult> UpdateSpecializedDepartment(SpecializedDepartmentDTO st)
        {
            var mapper = _mapper.Map<SpecializedDepartment>(st);

            var result = await _repository.UpdateSpecializedDepartment(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
