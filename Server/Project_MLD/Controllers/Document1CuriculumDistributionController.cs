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

        [HttpGet("GetDoc1CuriculumByDoc1ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document1CurriculumDistribution>>> GetDocument1CuriculumDistributionByDocument1ID(int id)
        {
            var curriculumDistribution = await _repository.GetCurriculumDistributionByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1CurriculumDistributionDTO>>(curriculumDistribution);
            return Ok(mapper);
        }

        [HttpPut("UpdateDoc1Curiculum")]
        public async Task<IActionResult> UpdateDocument1CurriculumDistribution(List<Document1CurriculumDistributionDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1CurriculumDistribution>>(requests);

                await _repository.UpdateDocument1CurriculumDistribution(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document1 CurriculumDistribution: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1Curriculum")]
        public async Task<IActionResult> DeleteDocument1CurriculumDistribution( List<Document1CurriculumDistributionDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1CurriculumDistribution>>(requests);
                await _repository.DeleteDocument1CurriculumDistribution(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 CurriculumDistribution: {ex.Message}");
            }
        }

        
    }
}
