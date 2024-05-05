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
    public class Document3Controller : ControllerBase
    {
        private readonly IDocument3Repository _repository;
        private readonly IMapper _mapper;
        private readonly IDocument3CurriculumDistributionRepository _curriculumDistributionRepository;
        private readonly IDocument3SelectedTopicsRepository _selectedTopicsRepository;
        private readonly IUserRepository _userRepository;

        public Document3Controller(IDocument3Repository repository, IMapper mapper,
            IDocument3CurriculumDistributionRepository curriculumDistributionRepository,
            IDocument3SelectedTopicsRepository selectedTopicsRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _curriculumDistributionRepository = curriculumDistributionRepository;
            _selectedTopicsRepository = selectedTopicsRepository;
            _userRepository = userRepository;
        }

        [HttpGet("GetAllDoc3s")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDocument3s()
        {
            var document3s = await _repository.GetAllDocument3s();
            var mapDocument = _mapper.Map<List<Document3DTO>>(document3s);
            foreach (var document3 in mapDocument)
            {
                if (document3.ApproveBy.HasValue)
                {
                    var getUser = await _userRepository.GetUserById(document3.ApproveBy.Value);
                    if (getUser != null)
                    {
                        document3.ApproveByName = getUser.FirstName + " " + getUser.LastName; 
                    }
                }
                var getUserName = await _userRepository.GetUserById(document3.UserId);
                document3.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            }
            return Ok(mapDocument);
        }

        [HttpGet("GetAllDoc3sWithCondition")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDoc3sWithCondition(bool? status, int? isApprove)
        {
            var document3s = await _repository.GetAllDoc3sWithCondition(status, isApprove);
            var mapDocument = _mapper.Map<List<Document3DTO>>(document3s);
            foreach (var document3 in mapDocument)
            {
                if (document3.ApproveBy.HasValue)
                {
                    var getUser = await _userRepository.GetUserById(document3.ApproveBy.Value);
                    if (getUser != null)
                    {
                        document3.ApproveByName = getUser.FirstName + " " + getUser.LastName;
                    }
                }
                var getUserName = await _userRepository.GetUserById(document3.UserId);
                document3.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            }
            return Ok(mapDocument);
        }

        [HttpGet("GetDoc3ByUserDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetDoc3ByUserDepartment([FromQuery] List<int> listId)
        {
            var documents = await _repository.GetDocument3ByUserSpecialiedDepartment(listId);
            var modifiedDocuments = new List<object>();
            foreach (var document in documents)
            {
                if (document.GetType().GetProperty("id") != null && document.GetType().GetProperty("document") != null)
                {
                    var id = document.GetType().GetProperty("id").GetValue(document, null);
                    var doc = document.GetType().GetProperty("document").GetValue(document, null);
                    var dataMap = _mapper.Map<List<Document3DTO>>(doc);
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

        [HttpGet("GetDoc3ById/{id}")]
        public async Task<ActionResult<Document3DTO>> GetDoc3ById(int id)
        {
            var existDocument3 = await _repository.GetDocument3ById(id);

            var mapDocument = _mapper.Map<Document3DTO>(existDocument3);
            if (mapDocument.ApproveBy.HasValue)
            {
                var getUser = await _userRepository.GetUserById(mapDocument.ApproveBy.Value);
                if (getUser != null)
                {
                    mapDocument.ApproveByName = getUser.FirstName + " " + getUser.LastName;
                }
            }
            var getUserName = await _userRepository.GetUserById(mapDocument.UserId);
            mapDocument.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            return Ok(mapDocument);
        }

        [HttpPost("AddDoc3")]
        public async Task<ActionResult<Document3DTO>> AddDoc3(Document3DTO pl3)
        {
            try
            {
                pl3.Status = true;
                pl3.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

                var document = _mapper.Map<Document3>(pl3);

                var doc = await _repository.AddDocument3(document);
                if (doc == null)
                {
                    return BadRequest("Error Adding Document 3");
                }

                var mapper = _mapper.Map<Document3DTO>(doc);
                return Ok(mapper);

            }
            catch (Exception ex)
            {
                return BadRequest("Can not add Error, " + ex.Message);
            }

        }

        [HttpDelete("DeleteDoc3/{id}")]
        public async Task<IActionResult> DeleteDoc3(int id)
        {
            var result = await _repository.DeleteDocument3(id);
            if (!result)
            {
                return NotFound("No Document 3 Available");
            }
            return NoContent();
        }

        [HttpPut("UpdateDoc3")]
        public async Task<IActionResult> UpdateDoc3(Document3DTO pl3)
        {
            var mapDocument = _mapper.Map<Document3>(pl3);
            var result = await _repository.UpdateDocument3(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            var dataMap = _mapper.Map<Document3DTO>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                dataMap
            });
        }

        [HttpPut("ApproveDoc3")]
        public async Task<IActionResult> ApproveDoc3(Document3DTO pl3)
        {
            var mapDocument = _mapper.Map<Document3>(pl3);
            var result = await _repository.UpdateDocument3(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating");
            }
            var dataMap = _mapper.Map<Document3DTO>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                dataMap
            });
        }

        [HttpDelete("DeleteDoc3ForeignTableByDoc3Id/{id}")]
        public async Task<IActionResult> DeleteDoc3ForeignTableByDoc3Id(int id)
        {
            try
            {
                await _curriculumDistributionRepository.DeleteDocument3CurriculumDistributionByDoc3Id(id);
                await _selectedTopicsRepository.DeleteDocument3SelectedTopicsbyDoc3Id(id);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document3 Foreign Table: {ex.Message}");
            }
        }
    }
}