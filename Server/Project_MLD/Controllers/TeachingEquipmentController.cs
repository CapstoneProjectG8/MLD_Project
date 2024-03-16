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
    public class TeachingEquipmentController : ControllerBase
    {
        private readonly ITeachingEquipmentRepository _repository;

        public TeachingEquipmentController(ITeachingEquipmentRepository repository)
        {
            _repository = repository;
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

        [HttpPost]
        public async Task<ActionResult<TeachingEquipment>> AddTeachingEquipment(TeachingEquipment te)
        {
            await _repository.AddTeachingEquipment(te);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeachingEquipment(int id, TeachingEquipment te)
        {
            if (id != te.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateTeachingEquipment(te);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
