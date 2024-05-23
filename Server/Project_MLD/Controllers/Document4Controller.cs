using Amazon.S3.Model.Internal.MarshallTransformations;
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
    public class Document4Controller : ControllerBase
    {
        private readonly IDocument4Repository _repository;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;
        public Document4Controller(IDocument4Repository repository, IMapper mapper, INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }

        [HttpGet("GetAllDocument4s")]
        public async Task<ActionResult<IEnumerable<Document4DTO>>> GetAllDocument4s()
        {
            var doc4 = await _repository.GetAllDocument4s();
            var mapDocument = _mapper.Map<List<Document4DTO>>(doc4);

            return Ok(mapDocument);
        }

        [HttpGet("IsTheSameDepartment")]
        public async Task<IActionResult> IsTheSameDepartment(int document4Id, int userLoginId, int doctype)
        {

            var existDocument4 = await _repository.GetDoc4TeachingPlannerByDoc4Id(document4Id);

            //check leader 
            var leader = await _userRepository.GetUserIsRole(userLoginId, 3);
            //check principle
            var principle = await _userRepository.GetUserIsRole(userLoginId, 4);

            if (principle != null && doctype == 5)
            {
                return Ok(true);
            }

            if (leader != null)
            {
                var userdoc = await _userRepository.GetUserById(existDocument4.TeachingPlanner.UserId);
                if (leader.DepartmentId == userdoc.DepartmentId)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpGet("GetDocument4ByUserSpecialiedDepartment")]
        public async Task<ActionResult<IEnumerable<Document4>>> GetDocument4ByUserSpecialiedDepartment([FromQuery] List<int> listId)
        {
            var documents = await _repository.GetDocument4ByUserSpecialiedDepartment(listId);
            var modifiedDocuments = new List<object>();
            foreach (var document in documents)
            {
                if (document.GetType().GetProperty("SpecializedDepartmentId") != null && document.GetType().GetProperty("Document4s") != null)
                {

                    var id = document.GetType().GetProperty("SpecializedDepartmentId").GetValue(document, null);
                    var doc = document.GetType().GetProperty("Document4s").GetValue(document, null);

                    var dataMap = _mapper.Map<List<Document4DTO>>(doc);

                    var modifiedDocument = new
                    {
                        SpecializedDepartmentId = id,
                        Documents = dataMap
                    };

                    modifiedDocuments.Add(modifiedDocument);
                }
            }

            return Ok(modifiedDocuments);

        }

        [HttpGet("GetDoc4ById/{id}")]
        public async Task<ActionResult<Document4>> GetDocument4ById(int id)
        {
            var existDocument4 = await _repository.GetDocument4ById(id);

            return Ok(existDocument4);
        }

        [HttpGet("GetDocument4sWithCondition")]
        public async Task<ActionResult<IEnumerable<Document4>>> GetDocument4sWithCondition(bool? status, int? isApprove)
        {
            var existDocument4 = await _repository.GetDocument4sWithCondition(status, isApprove);
            //if (existDocument4 == null)
            //{
            //    return NotFound("No Document 4 Available");
            //}
            var mapDocumemt = _mapper.Map<List<Document4DTO>>(existDocument4);

            return Ok(mapDocumemt);
        }

        [HttpPost("AddDocument4")]
        public async Task<ActionResult<Document4>> AddDocument4(Document4DTO pl4)
        {
            try
            {
                pl4.Status = true;
                pl4.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

                var document = _mapper.Map<Document4>(pl4);

                var doc = await _repository.AddDocument4(document);
                if (doc == null)
                {
                    return BadRequest("Error Adding Document 4");
                }

                var mapper = _mapper.Map<Document4DTO>(doc);
                return Ok(mapper);

            }
            catch (Exception ex)
            {
                return BadRequest("Can not add Error, " + ex.Message);
            }
        }

        [HttpDelete("DeleteDocument4/{id}")]
        public async Task<IActionResult> DeleteDocument4(int id)
        {
            var result = await _repository.DeleteDocument4(id);
            if (!result)
            {
                return NotFound("No Document 4 Available");
            }
            await _notificationRepository.DeleteNotification(4, id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument4(Document4DTO pl4)
        {

            var mapDocument = _mapper.Map<Document4>(pl4);
            var result = await _repository.UpdateDocument4(mapDocument);
            if (!result)
            {
                return NotFound("Error Updating");
            }
            var dataMap = _mapper.Map<Document4>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                dataMap
            });
        }
        [HttpGet("GetDoc4InformationByDoc4Id")]
        public async Task<IActionResult> GetDoc4InformationByDoc4Id(int id)
        {
            var doc4 = await _repository.GetDoc4InformationByDoc4Id(id);
            if (doc4 == null)
            {
                return NotFound("No Document 4 Found");
            }
            return Ok(doc4);
        }

        [HttpGet("GetDocument4sByDoc3Id")]
        public async Task<IActionResult> GetDocument4sByDoc3Id(int doc3id)
        {
            var doc4 = await _repository.GetDoc4sByDoc3Id(doc3id);
            var dataMap = _mapper.Map<List<Document4DTO>>(doc4);
            return Ok(dataMap);
        }
    }
}
