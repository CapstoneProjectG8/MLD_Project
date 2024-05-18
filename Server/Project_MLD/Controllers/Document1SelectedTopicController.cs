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
    public class Document1SelectedTopicController : ControllerBase
    {
        private readonly IDocument1SelectedTopicsRepository _repository;
        private readonly IMapper _mapper;

        public Document1SelectedTopicController(IDocument1SelectedTopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet("GetDoc1SelectedTopicByDoc1ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document1SelectedTopic>>> GetDocument1SelectedTopicByDocument1ID(int id)
        {
            var selectedTopic = await _repository.GetSelectedTopicByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1SelectedTopicsDTO>>(selectedTopic);
            return Ok(mapper);
        }

        [HttpPost("AddDoc1SelectedTopic")]
        public async Task<IActionResult> AddDocument1SelectedTopic(List<Document1SelectedTopicsDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1SelectedTopic>>(requests);

                await _repository.AddDocument1SelectedTopic(mapRequests);

                return Ok("Add Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while add Document1 SelectedTopic: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1SelectedTopic")]
        public async Task<IActionResult> DeleteDocument1SelectedTopic(List<Document1SelectedTopicsDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1SelectedTopic>>(requests);
                await _repository.DeleteDocument1SelectedTopic(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 Selected Topics: {ex.Message}");
            }
        }
    }
}
