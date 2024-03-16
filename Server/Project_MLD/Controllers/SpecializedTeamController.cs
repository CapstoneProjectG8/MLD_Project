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
    public class SpecializedTeamController : ControllerBase
    {
        private readonly ISpecialTeamRepository _repository;

        public SpecializedTeamController(ISpecialTeamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecializedTeam>>> GetAllSpecialTeams()
        {
            var SpecialTeams = await _repository.GetAllSpecialTeams();
            return Ok(SpecialTeams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializedTeam>> GetSpecialTeamById(int id)
        {
            var existSpecialTeam = await _repository.GetSpecialTeamById(id);
            if (existSpecialTeam == null)
            {
                return NotFound();
            }

            return Ok(existSpecialTeam);
        }

        [HttpPost]
        public async Task<ActionResult<SpecializedTeam>> AddSpecialTeam(SpecializedTeam st)
        {
            await _repository.AddSpecialTeam(st);
            return CreatedAtAction(nameof(GetSpecialTeamById), new { id = st.Id }, st);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialTeam(int id)
        {
            var result = await _repository.DeleteSpecialTeam(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialTeam(int id, SpecializedTeam st)
        {
            if (id != st.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateSpecialTeam(st);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
