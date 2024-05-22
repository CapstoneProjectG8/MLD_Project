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
    public class SubjectRoomController : ControllerBase
    {
        private readonly ISubjectRoomRepository _repository;
        private readonly IMapper _mapper;

        public SubjectRoomController(ISubjectRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public async Task<ActionResult<SubjectRoom>> AddSubjectRoom(SubjectRoomDTO sr)
        {
            var mapper = _mapper.Map<SubjectRoom>(sr);
            await _repository.AddSubjectRoom(mapper);
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

        [HttpPut("UpdateSubjectRoom")]
        public async Task<IActionResult> UpdateSubjectRoom(SubjectRoomDTO sr)
        {
            var mapper = _mapper.Map<SubjectRoom>(sr);
            var result = await _repository.UpdateSubjectRoom(mapper);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
