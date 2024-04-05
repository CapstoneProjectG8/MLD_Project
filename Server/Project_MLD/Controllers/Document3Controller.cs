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
    public class Document3Controller : ControllerBase
    {
        private readonly IDocument3Repository _repository;

        public Document3Controller(IDocument3Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDocument3s()
        {
            var pl3 = await _repository.GetAllDocument3s();
            return Ok(pl3);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document3>> GetDocument3ById(int id)
        {
            var existDocument3 = await _repository.GetDocument3ById(id);
            if (existDocument3 == null)
            {
                return NotFound();
            }

            return Ok(existDocument3);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<Document3>> GetDoucment3ByCondition(string condition)
        {
            var existDocument3 = await _repository.GetDocument3sByCondition(condition);
            if (existDocument3 == null)
            {
                return NotFound();
            }

            return Ok(existDocument3);
        }

        [HttpPost]
        public async Task<ActionResult<Document3>> AddDocument3(Document3 pl3)
        {
            await _repository.AddDocument3(pl3);
            return CreatedAtAction(nameof(GetDocument3ById), new { id = pl3.Id }, pl3);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument3(int id)
        {
            var result = await _repository.DeleteDocument3(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument3(int id, Document3 pl3)
        {
            if (id != pl3.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateDocument3(pl3);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
