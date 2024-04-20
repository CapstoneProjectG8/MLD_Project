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

        [HttpGet("FilterDocument1")]
        public async Task<ActionResult<IEnumerable<Document1>>> FilterDocument1(int gradeId, int subjectId)
        {
            var Document1 = await _repository.FilterDocument1(gradeId, subjectId);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpGet("ByApproveID/{id}")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetDocument1ByApprovalID(int id)
        {
            var Document1 = await _repository.GetDocument1ByApprovalID(id);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document1DTO>> AddDocument1(Document1DTO doc1)
        {
            try
            {
                doc1.Status = true;
                var document = _mapper.Map<Document1>(doc1);

                var addedDocument = await _repository.AddDocument1(document);
                if (addedDocument == null)
                {
                    return BadRequest("Error Adding Document1");
                }
                var addedDocumentDTO = _mapper.Map<Document1DTO>(addedDocument);
                return Ok(addedDocumentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Can not add Error, " + ex.Message);
            }
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

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1(Document1DTO document1)
        {

            var mapper = _mapper.Map<Document1>(document1);
            var result = await _repository.UpdateDocument1(mapper);
            if (!result)
            {
                return BadRequest("Error Updating Document 1");
            }
            var dataMap = _mapper.Map<Document1DTO>(mapper);
            return Ok(new
            {
                message = "Update Success",
                dataMap
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
            var totalTeacherProfessionalStandard = await _userRepository.GetTotalUserProfessionalStandard();
            var totalTeacherLevelOfTrainning = await _userRepository.GetTotalUserLevelOfTrainning();


            return Ok(new
            {
                totalTeacher = totalTeacher,
                totalTeacherProfessionalStandard = totalTeacherProfessionalStandard,
                totalTeacherLevelOfTrainning = totalTeacherLevelOfTrainning
            });
        }

        [HttpPut("ApproveDocument1")]
        public async Task<IActionResult> ApproveDocument1(Document1DTO document1)
        {

            var mapper = _mapper.Map<Document1>(document1);
            var result = await _repository.UpdateDocument1(mapper);
            if (!result)
            {
                return BadRequest("Error Updating Document 1");
            }
            var dataMap = _mapper.Map<Document1DTO>(mapper);
            return Ok(new
            {
                message = "Update Success",
                dataMap
            });
        }

        [HttpGet("GetDocument1ByUserSpecialiedDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetDocument1ByUserSpecialiedDepartment([FromQuery] List<int> listId)
        {

            //var documents = await _repository.GetDocument1ByUserSpecialiedDepartment(listId);
            //var mappedDocuments = _mapper.Map<List<Document1DTO>>(documents);
            //return Ok(mappedDocuments);

            var documents = await _repository.GetDocument1ByUserSpecialiedDepartment(listId);

            var modifiedDocuments = new List<object>();

            foreach (var document in documents)
            {
                // Kiểm tra xem document có thuộc tính "id" và "document" không
                if (document.GetType().GetProperty("id") != null && document.GetType().GetProperty("document") != null)
                {
                    // Truy cập thuộc tính "id" và "document"
                    var id = document.GetType().GetProperty("id").GetValue(document, null);
                    var doc = document.GetType().GetProperty("document").GetValue(document, null);

                    var dataMap = _mapper.Map<List<Document1DTO>>(doc);

                    var modifiedDocument = new
                    {
                        SpecializedDepartmentId = id,
                        documents = dataMap
                    };

                    modifiedDocuments.Add(modifiedDocument);
                }
            }

            return Ok(modifiedDocuments);

        }
    }
}
