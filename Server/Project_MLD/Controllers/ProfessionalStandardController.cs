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
    public class ProfessionalStandardController : ControllerBase
    {
        private readonly IProfessionalStandardRepository _repository;
        private readonly IMapper _mapper;

        public ProfessionalStandardController(IProfessionalStandardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllProfessionalStandard()
        {
            var ps = await _repository.GetAllProfessionalStandard();
            return Ok(ps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetProfessionalStandardById(int id)
        {
            var existPs = await _repository.GetProfessionalStandardById(id);
            if (existPs == null)
            {
                return NotFound();
            }

            return Ok(existPs);
        }

        [HttpPost("AddProfessionalStandard")]
        public async Task<ActionResult<Role>> AddProfessionalStandard(ProfessionalStandardDTO ps)
        {
            var mapper = _mapper.Map<ProfessionalStandard>(ps);
            await _repository.AddProfessionalStandard(mapper);
            return CreatedAtAction(nameof(GetProfessionalStandardById), new { id = ps.Id }, ps);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalStadard(int id)
        {
            var result = await _repository.DeleteProfessionalStandard(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateProfessionalStandard")]
        public async Task<IActionResult> UpdateProfessionalStandard(ProfessionalStandardDTO ps)
        {
            var mapper = _mapper.Map<ProfessionalStandard>(ps);
            var result = await _repository.UpdateProfessionalStandard(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
