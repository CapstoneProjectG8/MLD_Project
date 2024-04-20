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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedbacks()
        {
            return Ok(await _repository.GetAllFeedbacks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
        {
            return Ok(await _repository.GetFeedbackById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback(Feedback st)
        {
            await _repository.AddFeedback(st);
            return CreatedAtAction(nameof(GetFeedbackById), new { id = st.Id }, st);
        }

    }
}
