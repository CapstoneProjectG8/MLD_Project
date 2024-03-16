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
    public class LevelOfTrainningController : ControllerBase
    {
        private readonly ILevelOfTrainningRepository _repository;

        public LevelOfTrainningController(ILevelOfTrainningRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelOfTrainning>>> GetAllLevelOfTrainning()
        {
            var LevelOfTrainnings = await _repository.GetAllLevelOfTrainnings();
            return Ok(LevelOfTrainnings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LevelOfTrainning>> GetLevelOfTrainningById(int id)
        {
            var existLt = await _repository.GetLevelOfTrainningById(id);
            if (existLt == null)
            {
                return NotFound();
            }

            return Ok(existLt);
        }

        [HttpPost]
        public async Task<ActionResult<LevelOfTrainning>> AddLevelOfTrainning(LevelOfTrainning lt)
        {
            await _repository.AddLevelOfTrainning(lt);
            return CreatedAtAction(nameof(GetLevelOfTrainningById), new { id = lt.Id }, lt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelOfTrainning(int id)
        {
            var result = await _repository.DeleteLevelOfTrainning(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLevelOfTrainning(int id, LevelOfTrainning lt)
        {
            if (id != lt.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateLevelOfTrainning(lt);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
