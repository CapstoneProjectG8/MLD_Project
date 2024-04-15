using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using System.Reflection.Metadata;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingPlannerController : ControllerBase
    {
        private readonly ITeachingPlannerRepository _repository;
        private readonly IMapper _mapper;

        public TeachingPlannerController(ITeachingPlannerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingPlanner>>> GetAllTeachingPlanner()
        {
            var TeachingPlanner = await _repository.GetAllTeachingPlanner();
            if(TeachingPlanner == null)
            {
                return NotFound("Null");
            }
            return Ok(TeachingPlanner);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingPlanner>> GetTeachingPlannerById(int id)
        {
            var TeachingPlanner = await _repository.GetTeachingPlannerById(id);
            if (TeachingPlanner == null)
            {
                return NotFound("No Teaching Planner Found");
            }

            return Ok(TeachingPlanner);
        }

        [HttpGet("ByUserId")]
        public async Task<ActionResult<IEnumerable<TeachingPlanner>>> GetTeachingPlannerByUserId(int userId)
        {
            var TeachingPlanner = await _repository.GetTeachingPlannerByUserId(userId);
            if (TeachingPlanner == null)
            {
                return NotFound("No Teaching Planner Found");
            }

            return Ok(TeachingPlanner);
        }

        [HttpGet("ByClassId")]
        public async Task<ActionResult<IEnumerable<TeachingPlanner>>> GetTeachingPlannerByClassId(int classId)
        {
            var TeachingPlanner = await _repository.GetTeachingPlannerByClassId(classId);
            if (TeachingPlanner == null)
            {
                return NotFound("No Teaching Planner Found");
            }

            return Ok(TeachingPlanner);
        }

        [HttpGet("BySubjectId")]
        public async Task<ActionResult<IEnumerable<TeachingPlanner>>> GetTeachingPlannerBySubjectId(int subjectId)
        {
            var TeachingPlanner = await _repository.GetTeachingPlannerBySubjectId(subjectId);
            if (TeachingPlanner == null)
            {
                return NotFound("No Teaching Planner Found");
            }

            return Ok(TeachingPlanner);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachingPlannerById(int id)
        {
            var result = await _repository.DeleteTeachingPlanner(id);
            if (!result)
            {
                return NotFound("Teaching Planner not Found");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeachingPlannerByUserId(List<TeachingPlannerDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<TeachingPlanner>>(requests);
                foreach (var item in requests)
                {
                    await _repository.UpdateTeachingPlannerByUserId(mapRequests);
                }
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating TeachingPlanner: {ex.Message}");
            }
        }
    }
}
