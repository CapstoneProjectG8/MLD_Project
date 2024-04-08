﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document1PeriodicAssessmentController : ControllerBase
    {
        private readonly IDocument1PeriodicAssessmentRepository _repository;
        private readonly IMapper _mapper;

        public Document1PeriodicAssessmentController(IDocument1PeriodicAssessmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<PeriodicAssessment>> GetAllPeriodicAssessment()
        {
            var PeriodicAssessment = await _repository.GetAllPeriodicAssessment();
            return Ok(PeriodicAssessment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodicAssessment>> GetDocument1PeriodicAssessmentByDocument1ID(int id)
        {
            var PeriodicAssessment = await _repository.GetPeriodicAssessmentByDocument1Id(id);
            return Ok(PeriodicAssessment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1PeriodicAssessment(int documentId, List<PeriodicAssessment> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document1Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
                var mapRequests = _mapper.Map<List<PeriodicAssessment>>(requests);
                foreach (var item in requests)
                {
                    await _repository.UpdateDocument1PeriodicAssessment(mapRequests);
                }
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Periodic Assessment: {ex.Message}");
            }
        }
    }
}
