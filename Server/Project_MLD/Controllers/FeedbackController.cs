using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using System.Data;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMapper _mappper;

        public FeedbackController(IFeedbackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mappper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetAllFeedbacks()
        {
            return Ok(await _repository.GetAllFeedbacks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetFeedbackById(int id)
        {
            return Ok(await _repository.GetFeedbackById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Report>> AddFeedback(FeedbackDTO st)
        {
            st.Read = false;
            var fb = _mappper.Map<Report>(st);
            var addFB = await _repository.AddFeedback(fb);
            var mapFB = _mappper.Map<FeedbackDTO>(addFB);
            return Ok(mapFB);
        }
        [HttpPut]
        public async Task<ActionResult<Report>> PutFeedback(FeedbackDTO st)
        {
            var mapperFB = _mappper.Map<Report>(st);
            var result = await _repository.UpdateFeedback(mapperFB);
            if (!result)
            {
                return NotFound("Chua dien du thong tin id");
            }
            return Ok();
        }
    }
}
