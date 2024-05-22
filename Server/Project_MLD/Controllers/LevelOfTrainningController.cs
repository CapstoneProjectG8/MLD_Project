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
    public class LevelOfTrainningController : ControllerBase
    {
        private readonly ILevelOfTrainningRepository _repository;
        private readonly IMapper _mapper;


        public LevelOfTrainningController(ILevelOfTrainningRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        [HttpPost("AddLevelOfTrainning")]
        public async Task<ActionResult<LevelOfTrainning>> AddLevelOfTrainning(LevelOfTrainningDTO lt)
        {   
            var mapper = _mapper.Map<LevelOfTrainning>(lt);
            await _repository.AddLevelOfTrainning(mapper);
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

        [HttpPut("UpdateLevelOfTrainning")]
        public async Task<IActionResult> UpdateLevelOfTrainning(LevelOfTrainningDTO lt)
        {
            var mapper = _mapper.Map<LevelOfTrainning>(lt);
            var result = await _repository.UpdateLevelOfTrainning(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
