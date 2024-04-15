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

        [HttpGet("ByDocument4/{id}")]
        public async Task<ActionResult<IEnumerable<Document5>>> GetDoucment5ByDoc4(int id)
        {
            var existDocument5 = await _repository.GetDoucment5ByDoc4(id);
            if (existDocument5 == null)
            {
                return NotFound("No Document 1 Available");
            }
            return Ok(existDocument5);
        }

        [HttpPost]
        public async Task<ActionResult<Document5>> AddDocument5(Document5DTO pl5)
        {
            var mapDocument = _mapper.Map<Document5>(pl5);
            return await _repository.AddDocument5(mapDocument);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument5(int id, Document5DTO pl5)
        {
            if (id != pl5.Id)
            {
                return NotFound("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document5>(pl5);
            var result = await _repository.UpdateDocument5(mapDocument);
            if (!result)
            {
                return NotFound("Error Updating");
            }
            return NoContent();
        }
    }
}
