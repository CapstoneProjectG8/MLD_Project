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
    public class Document3Controller : ControllerBase
    {
        private readonly IDocument3Repository _repository;
        private readonly IMapper _mapper;
        public Document3Controller(IDocument3Repository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDocument3s()
        {
            var document3s = await _repository.GetAllDocument3s();
            if (document3s == null || document3s.Count() == 0)
            {
                return NotFound("No Document 3 Available");
            }
            var mapDocument = _mapper.Map<Document3DTO>(document3s);
            return Ok(mapDocument);
        }

        [HttpGet("ByApprove")]
        public async Task<ActionResult<Document3>> GetDocument3ByApproval()
        {
            var Document3 = await _repository.GetDocument3ByApproval();
            if (Document3 == null)
            {
                return NotFound("No Document 3 Found");
            }
            var mapDocument = _mapper.Map<Document3DTO>(Document3);
            return Ok(mapDocument);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document3>> GetDocument3ById(int id)
        {
            var existDocument3 = await _repository.GetDocument3ById(id);
            if (existDocument3 == null)
            {
                return NotFound("No Document 3 Available");
            }

            return Ok(existDocument3);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetDoucment3ByCondition(string condition)
        {
            var existDocument3 = await _repository.GetDocument3sByCondition(condition);
            if (existDocument3 == null)
            {
                return NotFound("No Document 3 Available");
            }
            var mapDocument = _mapper.Map<List<Document3DTO>>(existDocument3);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document3>> AddDocument3(Document3DTO pl3)
        {
            var mapDocument = _mapper.Map<Document3>(pl3);
            return await _repository.AddDocument3(mapDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument3(int id)
        {
            var result = await _repository.DeleteDocument3(id);
            if (!result)
            {
                return NotFound("No Document 3 Available");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument3(int id, Document3DTO pl3)
        {
            if (id != pl3.Id)
            {
                return NotFound("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document3>(pl3);
            var result = await _repository.UpdateDocument3(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            return NoContent();
        }
    }
}