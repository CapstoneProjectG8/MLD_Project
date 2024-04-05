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
    public class Document5Controller : ControllerBase
    {
        private readonly IDocument5Repository _repository;

        public Document5Controller(IDocument5Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document5>>> GetAllDocument5s()
        {
            var pl5 = await _repository.GetAllDocument5s();
            return Ok(pl5);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document5>> GetDocument5ById(int id)
        {
            var existDocument5 = await _repository.GetDocument5ById(id);
            if (existDocument5 == null)
            {
                return NotFound();
            }

            return Ok(existDocument5);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<Document5>> GetDoucment5ByCondition(string condition)
        {
            var existDocument5 = await _repository.GetDocument5sByCondition(condition);
            if (existDocument5 == null)
            {
                return NotFound();
            }

            return Ok(existDocument5);
        }

        [HttpPost]
        public async Task<ActionResult<Document5>> AddDocument5(Document5 pl5)
        {
            await _repository.AddDocument5(pl5);
            return CreatedAtAction(nameof(GetDocument5ById), new { id = pl5.Id }, pl5);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument5(int id)
        {
            var result = await _repository.DeleteDocument5(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument5(int id, Document5 pl5)
        {
            if (id != pl5.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateDocument5(pl5);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
