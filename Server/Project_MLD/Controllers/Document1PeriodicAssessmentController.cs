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
        private readonly IDocument1PeriodicAssessmentsRepository _repository;
        private readonly IMapper _mapper;

        public Document1PeriodicAssessmentController(IDocument1PeriodicAssessmentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetDoc1PeriodicAssessment")]
        public async Task<ActionResult<IEnumerable<Document1PeriodicAssessment>>> GetAllDocument1PeriodicAssessment()
        {
            var Document1PeriodicAssessment = await _repository.GetAllDocument1PeriodicAssessment();
            var mapper = _mapper.Map<List<Document1PeriodicAssessmentDTO>>(Document1PeriodicAssessment);
            return Ok(mapper);
        }

        [HttpGet("GetDoc1PeriodicAssessmentByDocument1ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document1PeriodicAssessment>>> GetDocument1PeriodicAssessmentByDocument1ID(int id)
        {
            var Document1PeriodicAssessment = await _repository.GetDocument1PeriodicAssessmentByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1PeriodicAssessmentDTO>>(Document1PeriodicAssessment);
            return Ok(mapper);
        }

        [HttpPut("UpdateDoc1PeriodicAssessment")]
        public async Task<IActionResult> UpdateDocument1PeriodicAssessment(List<Document1PeriodicAssessmentDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1PeriodicAssessment>>(requests);

                await _repository.UpdateDocument1PeriodicAssessment(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Periodic Assessment: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1PeriodicAssessment")]
        public async Task<IActionResult> DeleteDocument1PeriodicAssessment(List<Document1PeriodicAssessmentDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1PeriodicAssessment>>(requests);

                await _repository.DeleteDocument1PeriodicAssessment(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Periodic Assessment: {ex.Message}");
            }
        }

        //[HttpDelete("DeleteDocument1PeriodicAssessmentByDocument1Id")]
        //public async Task<IActionResult> DeleteDocument1PeriodicAssessmentByDocument1Id(int id)
        //{
        //    try
        //    {
        //        await _repository.DeleteDocument1PeriodicAssessmentByDoc1ID(id);

        //        return Ok("Delete Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return StatusCode(500, $"An error occurred while delete Document1 Periodic Assessment: {ex.Message}");
        //    }
        //}

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

        [HttpPut("UpdateTestingCategory")]
        public async Task<IActionResult> UpdateTestingCategory(TestingCategoryDTO testingCategoryDTO)
        {
            var mapper = _mapper.Map<TestingCategory>(testingCategoryDTO);
            var allTestingCategory = await _repository.UpdateTestingCategory(mapper);
            return Ok(allTestingCategory);
        }

        [HttpPut("UpdateFormCategory")]
        public async Task<IActionResult> UpdateFormCategory(FormCategoryDTO formCategoryDTO)
        {
            var mapper = _mapper.Map<FormCategory>(formCategoryDTO);
            var allFormCategory = await _repository.UpdateFormCategory(mapper);
            return Ok(allFormCategory);
        }
    }
}
