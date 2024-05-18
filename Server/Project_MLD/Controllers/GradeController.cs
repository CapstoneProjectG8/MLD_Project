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
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _repository;

        public GradeController(IGradeRepository repository)
        {
            _repository = repository;
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
        public async Task<ActionResult<Grade>> AddGrade(Grade grade)
        {
            await _repository.AddGrade(grade);
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

        [HttpPut("UpdateGrade/{id}")]
        public async Task<IActionResult> UpdateGrade(Grade grade)
        {

            var result = await _repository.UpdateGrade(grade);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
