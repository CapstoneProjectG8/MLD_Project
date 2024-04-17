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
        private readonly IMapper _mapper;

        public Document2GradeController(IDocument2GradeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document2Grade>>> GetAllDocument2sGrade()
        {
            var pl2 = await _repository.GetAllDocuemnt2Grades();
            if (pl2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            return Ok(mapDocumemt);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDocument2GradeById(int id)
        {
            var existDocument2 = await _repository.GetDocument2GradeByDocument2Id(id);
            if (existDocument2 == null)
            {
                return NotFound("No Document 2 Grade Found");
            }
            return Ok(existDocument2);
        }

        [HttpPut("{document2Id}")]
        public async Task<IActionResult> UpdateDocument2Grade(int document2Id, List<Document2GradeDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document2Id != document2Id)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
                var mapRequests = _mapper.Map<List<Document2Grade>>(requests);


                await _repository.UpdateDocument2Grade(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document2 Grade: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDocument2Grade(int documentId, List<Document2GradeDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document2Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
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
    }
}
