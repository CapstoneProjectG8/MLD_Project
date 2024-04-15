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
    public class Document2Controller : ControllerBase
    {
        private readonly IDocument2Repository _repository;
        private readonly IMapper _mapper;

        public Document2Controller(IDocument2Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document2>>> GetAllDocument2s()
        {
            var pl2 = await _repository.GetAllDocument2s();
            if(pl2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            return Ok(mapDocumemt);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDocument2ById(int id)
        {
            var existDocument2 = await _repository.GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return NotFound();
            }

            return Ok(existDocument2);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDoucment2ByCondition(string condition)
        {
            var existDocument2 = await _repository.GetDocument2ByCondition(condition);
            if (existDocument2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(existDocument2);
            return Ok(mapDocumemt);
        }

        [HttpGet("ByApprove")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDocument2ByApproval()
        {
            var document2 = await _repository.GetDocument2ByApproval();
            if (document2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocument = _mapper.Map<List<Document2DTO>>(document2);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document2>> AddDocument2(Document2DTO pl2)
        {
            var mapDocument = _mapper.Map<Document2>(pl2);
            return await _repository.AddDocument2(mapDocument);
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
        public async Task<IActionResult> UpdateDocument2(int id, Document2DTO pl2)
        {
            if (id != pl2.Id)
            {
                return NotFound("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document2>(pl2);
            var result = await _repository.UpdateDocument2(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            return NoContent();
        }
    }
}
