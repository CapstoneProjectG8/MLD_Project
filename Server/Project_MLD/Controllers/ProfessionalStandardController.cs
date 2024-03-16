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
    public class ProfessionalStandardController : ControllerBase
    {
        private readonly IProfessionalStandardRepository _repository;

        public ProfessionalStandardController(IProfessionalStandardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllProfessionalStandard()
        {
            var ps = await _repository.GetAllProfessionalStandard();
            return Ok(ps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetProfessionalStandardById(int id)
        {
            var existPs = await _repository.GetProfessionalStandardById(id);
            if (existPs == null)
            {
                return NotFound();
            }

            return Ok(existPs);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddProfessionalStandard(ProfessionalStandard ps)
        {
            await _repository.AddProfessionalStandard(ps);
            return CreatedAtAction(nameof(GetProfessionalStandardById), new { id = ps.Id }, ps);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalStadard(int id)
        {
            var result = await _repository.DeleteProfessionalStandard(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessionalStandard(int id, ProfessionalStandard ps)
        {
            if (id != ps.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateProfessionalStandard(ps);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
