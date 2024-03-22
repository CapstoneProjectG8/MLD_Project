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
    public class Document1Controller : ControllerBase
    {
        private readonly IDocument1Repository _repository;

        public Document1Controller(IDocument1Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument1()
        {
            var Document1 = await _repository.GetAllDocument1s();
            return Ok(Document1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document1>> GetDocument1ById(int id)
        {
            var Document1 = await _repository.GetDocument1ById(id);
            if (Document1 == null)
            {
                return NotFound();
            }

            return Ok(Document1);
        }

        [HttpPost]
        public async Task<ActionResult<Document1>> AddDocument1(Document1 document1)
        {
            await _repository.AddDocument1(document1);
            return CreatedAtAction(nameof(GetDocument1ById), new { id = document1.Id }, document1);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument1(int id)
        {
            var result = await _repository.DeleteDocument1(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument1(int id, Document1 document1)
        {
            if (id != document1.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateDocument1(document1);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
