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
    public class SelectedTopicController : ControllerBase
    {
        private readonly ISelectedTopicsRepository _repository;
        private readonly IMapper _mapper;

        public SelectedTopicController(ISelectedTopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedTopic>>> GetAllSelectedTopics()
        {
            var SelectedTopics = await _repository.GetAllSelectedTopics();
            return Ok(SelectedTopics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedTopic>> GetSelectedTopicById(int id)
        {
            var existSelectedTopic = await _repository.GetSelectedTopicById(id);
            if (existSelectedTopic == null)
            {
                return NotFound();
            }

            return Ok(existSelectedTopic);
        }

        [HttpGet("GetSelectedTopicBySubjectId/{subjectId}")]
        public async Task<ActionResult<SelectedTopic>> GetSelectedTopicBySubjectId(int subjectId)
        {
            var existSelectedTopic = await _repository.GetSelectedTopicsBySubjectId(subjectId);
            if (existSelectedTopic == null)
            {
                return NotFound();
            }

            return Ok(existSelectedTopic);
        }


        [HttpPost]
        public async Task<ActionResult<SelectedTopic>> AddSelectedTopic(SelectedTopicDTO st)
        {
            var map = _mapper.Map<SelectedTopic>(st);
            await _repository.AddSelectedTopic(map);
            return CreatedAtAction(nameof(GetSelectedTopicById), new { id = st.Id }, st);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectedTopic(int id)
        {
            var result = await _repository.DeleteSelectedTopic(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateSelectedTopic")]
        public async Task<IActionResult> UpdateSelectedTopic(SelectedTopicDTO st)
        {
            var map = _mapper.Map<SelectedTopic>(st);
            var result = await _repository.UpdateSelectedTopic(map);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
