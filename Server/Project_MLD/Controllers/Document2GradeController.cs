using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using System.Reflection.Metadata;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document2GradeController : ControllerBase
    {
        private readonly IDocument2GradeRepository _repository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public Document2GradeController(IDocument2GradeRepository repository, IMapper mapper, IGradeRepository gradeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document2Grade>>> GetAllDocument2sGrade()
        {
            var pl2 = await _repository.GetAllDocuemnt2Grades();
            if (pl2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2GradeDTO>>(pl2);
            return Ok(mapDocumemt);
        }

        [HttpGet("GetDocument2GradeById/{id}")]
        public async Task<ActionResult<IEnumerable<Document2Grade>>> GetDocument2GradeById(int id)
        {
            var existDocument2 = await _repository.GetDocument2GradeByDocument2Id(id);
            if (existDocument2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2GradeDTO>>(existDocument2);
            return Ok(mapDocumemt);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateDocument2Grade(List<Document2GradeDTO> requests)
        //{
        //    try
        //    {
        //        var mapRequests = _mapper.Map<List<Document2Grade>>(requests);


        //        await _repository.UpdateDocument2Grade(mapRequests);

        //        return Ok("Update success");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return StatusCode(500, $"An error occurred while updating Document2 Grade: {ex.Message}");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> AddDocument2Grade(Document2GradeDTO dto)
        {
            try
            {
                var document2 = _mapper.Map<Document2Grade>(dto);
                var doc = await _repository.AddDocument2Grade(document2);
                var mapDoc2 = _mapper.Map<Document2GradeDTO>(document2);
                return Ok(mapDoc2);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while add Document2 Grade: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDocument2Grade(List<Document2GradeDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document2Grade>>(requests);
                await _repository.DeleteDocument2Grade(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 CurriculumDistribution: {ex.Message}");
            }
        }

        [HttpGet("GetTotalStudentByGradeId/{gradeId}")]
        public async Task<IActionResult> GetTotalStudentByGradeId(int gradeId)
        {
            if (gradeId == 0)
            {
                return BadRequest("Grade Id is null");
            }
            var totalStudent = await _gradeRepository.GetTotalStudentByGradeId(gradeId);

            return Ok(new
            {
                totalStudent = totalStudent
            });
        }

        [HttpDelete("DeleteDocument2GradeByDocument2Id")]
        public async Task<IActionResult> DeleteDocument2GradeByDocument2Id(int id)
        {
            try
            {
                await _repository.DeleteDocument2GradeByDoc2Id(id);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document2 Grade: {ex.Message}");
            }
        }
    }
}
