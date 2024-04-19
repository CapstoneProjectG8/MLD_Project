using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public CurriculumDistributionController(ICurriculumDistributionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurriculumDistribution>>> GetAllCurriculumDistributions()
        {
            var CurriculumDistributions = await _repository.GetAllCurriculumDistributions();
            return Ok(CurriculumDistributions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurriculumDistribution>> GetCurriculumDistributionById(int id)
        {
            var CurriculumDistribution = await _repository.GetCurriculumDistributionById(id);
            if (CurriculumDistribution == null)
            {
                return NotFound();
            }

            return Ok(CurriculumDistribution);
        }

        [HttpPost]
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCurriculumDistribution(int id, CurriculumDistribution cd)
        //{
        //    if (id != cd.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _repository.UpdateCurriculumDistribution(cd);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}
