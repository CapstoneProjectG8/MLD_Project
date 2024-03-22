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
    public class Document2Controller : ControllerBase
    {
        private readonly IDocument2Repository _repository;

        public Document2Controller(IDocument2Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document2>>> GetAllDocument2s()
        {
            var pl2 = await _repository.GetAllDocument2s();
            return Ok(pl2);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document2>> GetDocument2ById(int id)
        {
            var existDocument2 = await _repository.GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return NotFound();
            }

            return Ok(existDocument2);
        }

        [HttpPost]
        public async Task<ActionResult<Document2>> AddDocument2(Document2 pl2)
        {
            await _repository.AddDocument2(pl2);
            return CreatedAtAction(nameof(GetDocument2ById), new { id = pl2.Id }, pl2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument2(int id)
        {
            var result = await _repository.DeleteDocument2(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument2(int id, Document2 pl2)
        {
            if (id != pl2.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateDocument2(pl2);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
