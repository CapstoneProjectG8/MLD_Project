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

        [HttpGet("GetDoc3CuriculumDistributionByDoc3ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3CurriculumDistribution>>> GetDoc3CuriculumDistributionByDoc3ID(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);
            return Ok(mapper);
        }

        [HttpPut("UpdateDoc3CurriculumDistribution")]
        public async Task<IActionResult> UpdateDocument3CurriculumDistribution(List<Document3CurriculumDistributionDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document3CurriculumDistribution>>(requests);

                await _repository.UpdateDocument3CurriculumDistribution(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document3 CurriculumDistribution: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc3CurriculumDistribution")]
        public async Task<IActionResult> DeleteDocument3CurriculumDistribution(List<Document3CurriculumDistributionDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document3CurriculumDistribution>>(requests);
                await _repository.DeleteDocument3CurriculumDistribution(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document3 CurriculumDistribution: {ex.Message}");
            }
        }


    }
}
