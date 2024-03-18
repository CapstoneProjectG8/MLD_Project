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
    public class PhuLuc2Controller : ControllerBase
    {
        private readonly IPhuLuc2Repository _repository;

        public PhuLuc2Controller(IPhuLuc2Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuLuc2>>> GetAllPhuLuc2s()
        {
            var pl2 = await _repository.GetAllPhuLuc2s();
            return Ok(pl2);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhuLuc2>> GetPhuLuc2ById(int id)
        {
            var existPhuLuc2 = await _repository.GetPhuLuc2ById(id);
            if (existPhuLuc2 == null)
            {
                return NotFound();
            }

            return Ok(existPhuLuc2);
        }

        [HttpPost]
        public async Task<ActionResult<PhuLuc2>> AddPhuLuc2(PhuLuc2 pl2)
        {
            await _repository.AddPhuLuc2(pl2);
            return CreatedAtAction(nameof(GetPhuLuc2ById), new { id = pl2.Id }, pl2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhuLuc2(int id)
        {
            var result = await _repository.DeletePhuLuc2(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhuLuc2(int id, PhuLuc2 pl2)
        {
            if (id != pl2.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdatePhuLuc2(pl2);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
