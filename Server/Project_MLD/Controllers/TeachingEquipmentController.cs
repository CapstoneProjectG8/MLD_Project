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
    public class TeachingEquipmentController : ControllerBase
    {
        private readonly ITeachingEquipmentRepository _repository;
        private readonly IMapper _mapper;

        public TeachingEquipmentController(ITeachingEquipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingEquipment>>> GetAllTeachingEquipments()
        {
            var TeachingEquipments = await _repository.GetAllTeachingEquipments();
            return Ok(TeachingEquipments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingEquipment>> GetTeachingEquipmentById(int id)
        {
            var existTeachingEquipment = await _repository.GetTeachingEquipmentById(id);
            if (existTeachingEquipment == null)
            {
                return NotFound();
            }

            return Ok(existTeachingEquipment);
        }

        [HttpPost("AddTeachingEquipment")]
        public async Task<ActionResult<TeachingEquipment>> AddTeachingEquipment(TeachingEquipmentDTO te)
        {
            var mapper = _mapper.Map<TeachingEquipment>(te);
            await _repository.AddTeachingEquipment(mapper);
            return CreatedAtAction(nameof(GetTeachingEquipmentById), new { id = te.Id }, te);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachingEquipment(int id)
        {
            var result = await _repository.DeleteTeachingEquipment(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateTeachingEquipment")]
        public async Task<IActionResult> UpdateTeachingEquipment(TeachingEquipmentDTO te)
        {
            var mapper = _mapper.Map<TeachingEquipment>(te);

            var result = await _repository.UpdateTeachingEquipment(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
