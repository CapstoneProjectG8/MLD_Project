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
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mappper;

        public ReportController(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mappper = mapper;
        }

        [HttpGet("GetAllReports")]
        public async Task<ActionResult<IEnumerable<Report>>> GetAllReports()
        {
            return Ok(await _repository.GetAllReports());
        }

        [HttpGet("GetReportById/{id}")]
        public async Task<ActionResult<Report>> GetReportById(int id)
        {
            return Ok(await _repository.GetReportById(id));
        }

        [HttpPost("AddReport")]
        public async Task<ActionResult<Report>> AddReport(ReportDTO st)
        {
            st.Read = false;
            var fb = _mappper.Map<Report>(st);
            var addFB = await _repository.AddReport(fb);
            var mapFB = _mappper.Map<ReportDTO>(addFB);
            return Ok(mapFB);
        }
        [HttpPut("UpdateReport")]
        public async Task<ActionResult<Report>> UpdateReport(ReportDTO st)
        {
            var mapperFB = _mappper.Map<Report>(st);
            var result = await _repository.UpdateReport(mapperFB);
            if (!result)
            {
                return NotFound("Chua dien du thong tin id");
            }
            return Ok();
        }
    }
}
