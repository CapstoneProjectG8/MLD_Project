using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluateController : ControllerBase
    {
        private readonly IEvaluateRepository _repository;
        private readonly IMapper _mapper;
        public EvaluateController(IEvaluateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluate>>> GetAllEvaluate()
        {
            var Evaluates = await _repository.GetAllEvaluates();
            var mapEvaluate = _mapper.Map<EvaluateDTO>(Evaluates);
            return Ok(mapEvaluate);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluate>> GetEvaluateById(int id)
        {
            var exEvaluate = await _repository.GetEvaluateById(id);
            if (exEvaluate == null)
            {
                return NotFound();
            }
            var mapEvaluate = _mapper.Map<EvaluateDTO>(exEvaluate);
            return Ok(mapEvaluate);
        }

        [HttpPost]
        public async Task<ActionResult<Evaluate>> AddEvaluate(EvaluateDTO Evaluate)
        {
            var u = await _repository.AddEvaluate(_mapper.Map<Evaluate>(Evaluate));
            return Ok(u);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluate(EvaluateDTO Evaluate)
        {
            var mapEvaluate = _mapper.Map<Evaluate>(Evaluate);

            var result = await _repository.UpdateEvaluate(mapEvaluate);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
