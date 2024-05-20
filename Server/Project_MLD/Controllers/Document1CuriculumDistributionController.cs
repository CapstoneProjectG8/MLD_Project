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

        public class RequestDocument1CurriculumDistribution
        {
            public int Document1Id { get; set; }

            public int? CurriculumId { get; set; }

            public int? Slot { get; set; }

            public string? Description { get; set; }
        }

        [HttpPost("AddDoc1Curiculum")]
        public async Task<IActionResult> AddDocument1CurriculumDistribution([FromBody] List<RequestDocument1CurriculumDistribution> listRequests)
        {
            try
            {
                var listDTO = new List<Document1CurriculumDistributionDTO>();
                foreach (var itemList in listRequests)
                {
                    var doc1CD = new Document1CurriculumDistributionDTO
                    {
                        Document1Id = itemList.Document1Id,
                        CurriculumId = itemList.CurriculumId,
                        Slot = itemList.Slot,
                        Description = itemList.Description
                    };
                    listDTO.Add(doc1CD);
                }
                var mapRequests = _mapper.Map<List<Document1CurriculumDistribution>>(listDTO);

                await _repository.AddDocument1CurriculumDistribution(mapRequests);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while add Document1 CurriculumDistribution: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1Curriculum")]
        public async Task<IActionResult> DeleteDocument1CurriculumDistribution(List<Document1CurriculumDistributionDTO> requests)
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
