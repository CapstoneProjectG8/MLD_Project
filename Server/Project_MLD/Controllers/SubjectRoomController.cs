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
    public class SubjectRoomController : ControllerBase
    {
        private readonly ISubjectRoomRepository _repository;

        public SubjectRoomController(ISubjectRoomRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectRoom>>> GetAllSubjectRooms()
        {
            var SubjectRooms = await _repository.GetAllSubjectRooms();
            return Ok(SubjectRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectRoom>> GetSubjectRoomById(int id)
        {
            var existSubjectRoom = await _repository.GetSubjectRoomById(id);
            if (existSubjectRoom == null)
            {
                return NotFound();
            }

            return Ok(existSubjectRoom);
        }

        [HttpPost]
        public async Task<ActionResult<SubjectRoom>> AddSubjectRoom(SubjectRoom sr)
        {
            await _repository.AddSubjectRoom(sr);
            return CreatedAtAction(nameof(GetSubjectRoomById), new { id = sr.Id }, sr);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectRoom(int id)
        {
            var result = await _repository.DeleteSubjectRoom(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubjectRoom(int id, SubjectRoom sr)
        {
            if (id != sr.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateSubjectRoom(sr);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
