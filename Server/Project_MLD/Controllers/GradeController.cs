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
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _repository;
        private readonly IMapper _mapper;

        public GradeController(IGradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllGrades")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetAllGrades()
        {
            var grades = await _repository.GetAllGrades();
            return Ok(grades);
        }

        [HttpGet("GetGradeById/{id}")]
        public async Task<ActionResult<Grade>> GetGradeById(int id)
        {
            var existGrade = await _repository.GetGradeById(id);
            if (existGrade == null)
            {
                return NotFound();
            }

            return Ok(existGrade);
        }

        [HttpPost("AddGrade")]
        public async Task<ActionResult<Grade>> AddGrade(GradeDTO grade)
        {
            var map = _mapper.Map<Grade>(grade);
            await _repository.AddGrade(map);
            return CreatedAtAction(nameof(GetGradeById), new { id = grade.Id }, grade);
        }

        [HttpDelete("DeleteGrade/{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var result = await _repository.DeleteGrade(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateGrade")]
        public async Task<IActionResult> UpdateGrade(GradeDTO grade)
        {
            var mapper = _mapper.Map<Grade>(grade);
            var result = await _repository.UpdateGrade(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
