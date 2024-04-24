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
    public class Document5Controller : ControllerBase
    {
        private readonly IDocument5Repository _repository;
        private readonly IMapper _mapper;

        public Document5Controller(IDocument5Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document5>>> GetAllDocument5s()
        {
            var pl5 = await _repository.GetAllDocument5s();
            var mappper = _mapper.Map<List<Document5DTO>>(pl5);
            return Ok(mappper);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document5>> GetDocument5ById(int id)
        {
            var existDocument5 = await _repository.GetDocument5ById(id);
            if (existDocument5 == null)
            {
                return NotFound();
            }
            var mappper = _mapper.Map<Document5DTO>(existDocument5);
            return Ok(mappper);
        }

        [HttpGet("GetDocument5ByDocument4/{id}")]
        public async Task<ActionResult<IEnumerable<Document5>>> GetDoucment5ByDoc4(int id)
        {
            var existDocument5 = await _repository.GetDoucment5ByDoc4(id);
            return Ok(existDocument5);
        }

        [HttpPost]
        public async Task<ActionResult<Document5>> AddDocument5(Document5DTO pl5)
        {
            pl5.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            var doc = _mapper.Map<Document5>(pl5);
            var mapDoc = await _repository.AddDocument5(doc);
            var docDTO = _mapper.Map<Document5DTO>(mapDoc);
            return Ok(docDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument5(int id)
        {
            var result = await _repository.DeleteDocument5(id);
            if (!result)
            {
                return NotFound("No Document 5 Available");
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument5( Document5DTO pl5)
        {
            var mapDocument = _mapper.Map<Document5>(pl5);
            var result = await _repository.UpdateDocument5(mapDocument);
            if (!result)
            {
                return NotFound("Error Updating");
            }
            var dataMap = _mapper.Map<Document5DTO>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                dataMap
            });
        }
    }
}
