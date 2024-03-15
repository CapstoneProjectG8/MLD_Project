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
    public class SelectedTopicController : ControllerBase
    {
        private readonly ISelectedTopicsRepository _repository;

        public SelectedTopicController(ISelectedTopicsRepository repository)
        {
            _repository = repository;
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

        [HttpPost]
        public async Task<ActionResult<SelectedTopic>> AddSelectedTopic(SelectedTopic st)
        {
            await _repository.AddSelectedTopic(st);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSelectedTopic(int id, SelectedTopic st)
        {
            if (id != st.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateSelectedTopic(st);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
