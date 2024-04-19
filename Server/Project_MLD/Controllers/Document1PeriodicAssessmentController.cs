using Amazon.Runtime.Internal.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System.Drawing.Printing;

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
        public async Task<ActionResult<IEnumerable<PeriodicAssessment>>> GetAllPeriodicAssessment()
        {
            var PeriodicAssessment = await _repository.GetAllPeriodicAssessment();
            var mapper = _mapper.Map<List<PeriodicAssessmentDTO>>(PeriodicAssessment);
            return Ok(mapper);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PeriodicAssessment>>> GetDocument1PeriodicAssessmentByDocument1ID(int id)
        {
            var PeriodicAssessment = await _repository.GetPeriodicAssessmentByDocument1Id(id);
            var mapper = _mapper.Map<List<List<PeriodicAssessmentDTO>>>(PeriodicAssessment);
            return Ok(mapper);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1PeriodicAssessment(List<PeriodicAssessmentDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<PeriodicAssessment>>(requests);

                await _repository.UpdateDocument1PeriodicAssessment(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Periodic Assessment: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDocument1PeriodicAssessment( List<PeriodicAssessmentDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<PeriodicAssessment>>(requests);

                await _repository.DeleteDocument1PeriodicAssessment(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Periodic Assessment: {ex.Message}");
            }
        }

        [HttpGet("GetAllTestingCategory")]
        public async Task<ActionResult<IEnumerable<TestingCategory>>> GetAllTestingCategory()
        {
            var allTestingCategory = await _repository.GetAllTestingCategory();
            return Ok(allTestingCategory);
        }

        [HttpGet("GetAllFormCategory")]
        public async Task<ActionResult<IEnumerable<FormCategory>>> GetAllFormCategory()
        {
            var allFormCategory = await _repository.GetAllFormCategory();
            return Ok(allFormCategory);
        }

        [HttpGet("GetTestingCategoryById/{id}")]
        public async Task<ActionResult<TestingCategory>> GetTestingCategoryById(int id)
        {
            var allTestingCategory = await _repository.GetTestingCategoryById(id);
            return Ok(allTestingCategory);
        }

        [HttpGet("GetFormCategoryById/{id}")]
        public async Task<ActionResult<FormCategory>> GetFormCategoryById(int id)
        {
            var allFormCategory = await _repository.GetFormCategoryById(id);
            return Ok(allFormCategory);
        }
    }
}
