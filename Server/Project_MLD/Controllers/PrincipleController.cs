using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System.Reflection.Metadata;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipleController : ControllerBase
    {
        private readonly IDocument1Repository _document1Repository;
        private readonly IDocument2Repository _document2Repository;
        private readonly IDocument3Repository _document3Repository;
        private readonly IDocument4Repository _document4Repository;
        private readonly IDocument5Repository _document5Repository;
        private readonly IMapper _mapper;


        public PrincipleController(
            IDocument1Repository document1Repository,
            IDocument2Repository document2Repository,
            IDocument3Repository document3Repository,
            IDocument4Repository document4Repository,
            IDocument5Repository document5Repository,
            IMapper mapper)
        {
            _document1Repository = document1Repository;
            _document2Repository = document2Repository;
            _document3Repository = document3Repository;
            _document4Repository = document4Repository;
            _document5Repository = document5Repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllDocument1")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument1()
        {
            var document1 = await _document1Repository.GetAllDocument1s();
            var mapperDocument1 = _mapper.Map<IEnumerable<Document1DTO>>(document1);
            return Ok(mapperDocument1);
        }

        [HttpGet("GetAllDocument2")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument2()
        {
            var document2 = await _document2Repository.GetAllDocument2s();
            var mapperDocument2 = _mapper.Map<IEnumerable<Document2DTO>>(document2);
            return Ok(mapperDocument2);
        }

        [HttpGet("GetAllDocument3")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument3()
        {
            var document3 = await _document3Repository.GetAllDocument3s();
            var mapperDocument3 = _mapper.Map<IEnumerable<Document3DTO>>(document3);
            return Ok(mapperDocument3);
        }

        [HttpGet("GetAllDocument4")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument4()
        {
            var document4 = await _document4Repository.GetAllDocument4s();
            var mapperDocument4 = _mapper.Map<IEnumerable<Document4DTO>>(document4);
            return Ok(mapperDocument4);
        }

        [HttpGet("GetAllDocument5")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument5()
        {
            var document5 = await _document5Repository.GetAllDocument5s();
            var mapperDocument5 = _mapper.Map<IEnumerable<Document5DTO>>(document5);
            return Ok(mapperDocument5);
        }

        [HttpPost("RateDocument4ByDocument5")]
        public async Task<ActionResult<Document5>> RateDocument4ByDocument5(Document5DTO pl5)
        {
            var mapDocument = _mapper.Map<Document5>(pl5);
            return await _document5Repository.AddDocument5(mapDocument);
        }

        [HttpPut("ApproveDocument1/{id}")]
        public async Task<ActionResult<Document5>> ApproveDocument1(int id,Document1DTO pl1)
        {
            if (id != pl1.Id)
            {
                return NotFound("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document1>(pl1);
            var result = await _document1Repository.UpdateDocument1(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            return NoContent();
        }

        [HttpPut("ApproveDocument2/{id}")]
        public async Task<ActionResult<Document5>> ApproveDocument2(int id, Document2DTO pl2)
        {
            if (id != pl2.Id)
            {
                return NotFound("Id Not Match");
            }
            var mapDocument = _mapper.Map<Document2>(pl2);
            var result = await _document2Repository.UpdateDocument2(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            return NoContent();
        }
    }
}
