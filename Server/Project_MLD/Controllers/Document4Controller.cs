using AutoMapper;
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
        private readonly IMapper _mapper;
        public Document4Controller(IDocument4Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document4>>> GetAllDocument4s()
        {
            var Document4 = await _repository.GetAllDocument4s();
            if (Document4 == null || Document4.Count() == 0)
            {
                return NotFound("No Document 4 Available");
            }
            var mapDocument = _mapper.Map<List<Document4DTO>>(Document4);
            return Ok(mapDocument);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document4>> GetDocument4ById(int id)
        {
            var existDocument4 = await _repository.GetDocument4ById(id);
            if (existDocument4 == null)
            {
                return NotFound("No Document 4 Available");
            }

            return Ok(existDocument4);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document4>>> GetDoucment4sByCondition(string condition)
        {
            var existDocument4 = await _repository.GetDocument4sByCondition(condition);
            if (existDocument4 == null)
            {
                return NotFound("No Document 4 Available");
            }
            var mapDocumemt = _mapper.Map<List<Document4DTO>>(existDocument4);

            return Ok(mapDocumemt);
        }

        [HttpPost]
        public async Task<ActionResult<Document4>> AddDocument4(Document4 pl4)
        {
            var doc = await _repository.AddDocument4(pl4);
            var mapDocument = _mapper.Map<Document4DTO>(doc);
            return Ok(mapDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument4(int id)
        {
            var result = await _repository.DeleteDocument4(id);
            if (!result)
            {
                return NotFound("No Document 4 Available");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument4(int id, Document4DTO pl4)
        {
            if (id != pl4.Id)
            {
                return BadRequest("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document4>(pl4);
            var result = await _repository.UpdateDocument4(mapDocument);
            if (!result)
            {
                return NotFound("Error Updating");
            }
            return NoContent();
        }
    }
}
