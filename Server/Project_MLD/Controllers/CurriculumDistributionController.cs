using AutoMapper;
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
    public class CurriculumDistributionController : ControllerBase
    {
        private readonly ICurriculumDistributionRepository _repository;
        private readonly IMapper _mapper;

        public CurriculumDistributionController(ICurriculumDistributionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllCurriculums")]
        public async Task<ActionResult<IEnumerable<CurriculumDistribution>>> GetAllCurriculumDistributions()
        {
            var CurriculumDistributions = await _repository.GetAllCurriculumDistributions();
            return Ok(CurriculumDistributions);
        }

        [HttpGet("GetCurriculumById/{id}")]
        public async Task<ActionResult<CurriculumDistribution>> GetCurriculumDistributionById(int id)
        {
            var CurriculumDistribution = await _repository.GetCurriculumDistributionById(id);
            if (CurriculumDistribution == null)
            {
                return NotFound();
            }

            return Ok(CurriculumDistribution);
        }

        [HttpGet("GetCurriculumBySubjectId/{subjectId}")]
        public async Task<ActionResult<CurriculumDistribution>> GetCurriculumDistributionBySubjectId(int subjectId)
        {
            var CurriculumDistribution = await _repository.GetCurriculumDistributionsBySubjectId(subjectId);
            if (CurriculumDistribution == null)
            {
                return NotFound();
            }

            return Ok(CurriculumDistribution);
        }

        [HttpPost("AddCurriculum")]
        public async Task<ActionResult<CurriculumDistribution>> AddCurriculumDistribution(CurriculumDistribution cd)
        {
            await _repository.AddCurriculumDistribution(cd);
            return CreatedAtAction(nameof(GetCurriculumDistributionById), new { id = cd.Id }, cd);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCurriculumDistribution(int id)
        //{
        //    var result = await _repository.DeleteCurriculumDistribution(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        [HttpPut("UpdateCurriculumDistribution")]
        public async Task<IActionResult> UpdateCurriculumDistribution(CurriculumDistributionDTO cd)
        {
            var mapper = _mapper.Map<CurriculumDistribution>(cd);
            var result = await _repository.UpdateCurriculumDistribution(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
