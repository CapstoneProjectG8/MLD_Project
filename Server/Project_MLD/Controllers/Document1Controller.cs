using Amazon.Runtime.Internal.Util;
using AutoMapper;
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
    public class Document1Controller : ControllerBase
    {
        private readonly IDocument1Repository _repository;
        private readonly IMapper _mapper;
        private readonly IGradeRepository _gradeRepository;
        private readonly IUserRepository _userRepository;
        public Document1Controller(IDocument1Repository repository, IMapper mapper, IGradeRepository gradeRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _gradeRepository = gradeRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument1()
        {
            var Document1 = await _repository.GetAllDocument1s();
            if (Document1 == null || Document1.Count() == 0)
            {
                return NotFound("No Document 1 Available");
            }
            var mappedDocuments = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mappedDocuments);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document1>> GetDocument1ById(int id)
        {
            var Document1 = await _repository.GetDocument1ById(id);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Available");
            }
            var mappedDocuments = _mapper.Map<Document1DTO>(Document1);
            return Ok(mappedDocuments);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetDocument1ByCondition(string condition)
        {
            var Document1 = await _repository.GetDocument1ByCondition(condition);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpGet("ByApprove")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetDocument1ByApproval()
        {
            var Document1 = await _repository.GetDocument1ByApproval();
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document1>> AddDocument1(Document1 doc1)
        {

            var document = await _repository.AddDocument1(doc1);
            var mapper = _mapper.Map<Document1DTO>(document);
            return Ok(mapper);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument1(int id)
        {
            var result = await _repository.DeleteDocument1(id);
            if (!result)
            {
                return NotFound("No Document 1 Available");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument1(int id, Document1 document1)
        {
            if (id != document1.Id)
            {
                return NotFound("Id Not Match");
            }
            var result = await _repository.UpdateDocument1(document1);
            if (!result)
            {
                return BadRequest("Error Updating Document 1");
            }
            var mapper = _mapper.Map<Document1DTO>(document1);
            return Ok(new
            {
                message = "Update Success",
                mapper
            });
        }

        [HttpGet("GetTotalClassByGradeId")]
        public async Task<IActionResult> GetTotalClassAndStudentByGradeId(int gradeId)
        {
            if (gradeId == 0)
            {
                return BadRequest("Grade Id is Null");
            }
            var totalClass = await _gradeRepository.GetTotalClassByGradeId(gradeId);

            var totalStudent = await _gradeRepository.GetTotalStudentByGradeId(gradeId);

            var totalStudentSelected = await _gradeRepository.GetTotalStudentSelectedTopicsByGradeId(gradeId);
            return Ok(new
            {
                totalClass = totalClass,
                totalStudent = totalStudent,
                totalStudentSelected = totalStudentSelected
            });
        }


        [HttpGet("GetTeacherInformation")]
        public async Task<IActionResult> GetTeacherInformation(int specializedDepartmentId)
        {
            if (specializedDepartmentId == 0)
            {
                return BadRequest("specialized Department Id is Null");
            }
            var totalTeacher = await _userRepository.GetTotalUserBySpecializedDepartmentId(specializedDepartmentId);
            var totalTeacherProfessionalStandard = await _userRepository.GetTotalTeacherProfessionalStandard();
            var totalTeacherLevelOfTrainning = await _userRepository.GetTotalTeacherLevelOfTrainning();


            return Ok(new
            {
                totalTeacher = totalTeacher,
                totalTeacherProfessionalStandard = totalTeacherProfessionalStandard,
                totalTeacherLevelOfTrainning = totalTeacherLevelOfTrainning
            });
        }
    }
}
