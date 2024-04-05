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
    public class Document4Controller : ControllerBase
    {
        private readonly IDocument4Repository _repository;

        public Document4Controller(IDocument4Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document4>>> GetAllDocument4s()
        {
            var pl4 = await _repository.GetAllDocument4s();
            return Ok(pl4);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document4>> GetDocument4ById(int id)
        {
            var existDocument4 = await _repository.GetDocument4ById(id);
            if (existDocument4 == null)
            {
                return NotFound();
            }

            return Ok(existDocument4);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<Document4>> GetDoucment4sByCondition(string condition)
        {
            var existDocument4 = await _repository.GetDocument4sByCondition(condition);
            if (existDocument4 == null)
            {
                return NotFound();
            }

            return Ok(existDocument4);
        }

        [HttpPost]
        public async Task<ActionResult<Document4>> AddDocument4(Document4 pl4)
        {
            await _repository.AddDocument4(pl4);
            return CreatedAtAction(nameof(GetDocument4ById), new { id = pl4.Id }, pl4);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument4(int id)
        {
            var result = await _repository.DeleteDocument4(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument4(int id, Document4 pl4)
        {
            if (id != pl4.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateDocument4(pl4);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
