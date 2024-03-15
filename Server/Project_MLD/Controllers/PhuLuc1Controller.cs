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
    public class PhuLuc1Controller : ControllerBase
    {
        private readonly IPhuLuc1Repository _repository;

        public PhuLuc1Controller(IPhuLuc1Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuLuc1>>> GetAllPhuLuc1()
        {
            var PhuLuc1 = await _repository.GetAllPhuLuc1s();
            return Ok(PhuLuc1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhuLuc1>> GetPhuLuc1ById(int id)
        {
            var PhuLuc1 = await _repository.GetPhuLuc1ById(id);
            if (PhuLuc1 == null)
            {
                return NotFound();
            }

            return Ok(PhuLuc1);
        }

        [HttpPost]
        public async Task<ActionResult<PhuLuc1>> AddPhuLuc1(PhuLuc1 pl1)
        {
            await _repository.AddPhuLuc1(pl1);
            return CreatedAtAction(nameof(GetPhuLuc1ById), new { id = pl1.Id }, pl1);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhuLuc1(int id)
        {
            var result = await _repository.DeletePhuLuc1(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhuLuc1(int id, PhuLuc1 pl1)
        {
            if (id != pl1.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdatePhuLuc1(pl1);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
