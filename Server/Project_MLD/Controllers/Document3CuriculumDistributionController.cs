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
    public class Document3CuriculumDistributionController : ControllerBase
    {
        private readonly IDocument3CurriculumDistributionRepository _repository;
        private readonly IMapper _mapper;

        public Document3CuriculumDistributionController(IDocument3CurriculumDistributionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Document3CurriculumDistribution>> GetDocument3CuriculumDistributionByDocument3ID(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);
            return Ok(mapper);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument3CurriculumDistribution(int documentId, List<Document3CurriculumDistributionDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document3Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
                var mapRequests = _mapper.Map<List<Document3CurriculumDistribution>>(requests);
                foreach (var item in requests)
                {
                    await _repository.UpdateDocument3CurriculumDistribution(mapRequests);
                }
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document3 CurriculumDistribution: {ex.Message}");
            }
        }


    }
}
