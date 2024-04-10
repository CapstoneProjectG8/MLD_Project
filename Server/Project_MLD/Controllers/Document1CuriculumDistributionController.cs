using AutoMapper;
using AutoMapper.Internal;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document1CuriculumDistributionController : ControllerBase
    {
        private readonly IDocument1CuriculumDistributionRepository _repository;
        private readonly IMapper _mapper;

        public Document1CuriculumDistributionController(IDocument1CuriculumDistributionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Document1CurriculumDistribution>> GetDocument1CuriculumDistributionByDocument1ID(int id)
        {
            var curriculumDistribution = await _repository.GetCurriculumDistributionByDocument1Id(id);
            return Ok(curriculumDistribution);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1CurriculumDistribution(int documentId, List<Document1CurriculumDistributionDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document1Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
                var mapRequests = _mapper.Map<List<Document1CurriculumDistribution>>(requests);
                foreach (var item in requests)
                {
                    await _repository.UpdateDocument1CurriculumDistribution(mapRequests);
                }
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document1CurriculumDistribution: {ex.Message}");
            }
        }
    }
}
