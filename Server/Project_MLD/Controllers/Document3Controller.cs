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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDocument3s()
        {
            var document3s = await _repository.GetAllDocument3s();
            //if (document3s == null || document3s.Count() == 0)
            //{
            //    return NotFound("No Document 3 Available");
            //}
            var mapDocument = _mapper.Map<List<Document3DTO>>(document3s);
            foreach (var document3 in mapDocument)
            {
                if (document3.ApproveBy.HasValue)
                {
                    var getUser = await _userRepository.GetUserById(document3.ApproveBy.Value);
                    if (getUser != null)
                    {
                        document3.ApproveByName = getUser.FullName;
                    }
                }
            }
            return Ok(mapDocument);
        }

        [HttpGet("GetDocument3ByUserSpecialiedDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetDocument3ByUserSpecialiedDepartment([FromQuery] List<int> listId)
        {
            //var document3s = await _repository.GetDocument3ByUserSpecialiedDepartment(specializedDepartmentId);
            //if (document3s == null || document3s.Count() == 0)
            //{
            //    return NotFound("No Document 3 Available");
            //}
            //var mapDocument = _mapper.Map<List<Document3DTO>>(document3s);
            //return Ok(mapDocument);


            var documents = await _repository.GetDocument3ByUserSpecialiedDepartment(listId);

            var modifiedDocuments = new List<object>();

            foreach (var document in documents)
            {
                // Kiểm tra xem document có thuộc tính "id" và "document" không
                if (document.GetType().GetProperty("id") != null && document.GetType().GetProperty("document") != null)
                {
                    // Truy cập thuộc tính "id" và "document"
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

        [HttpGet("ByApproveID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetDocument3ByApprovalID(int id)
        {
            var Document3 = await _repository.GetDocument3ByApprovalID(id);
            //if (Document3 == null)
            //{
            //    return NotFound("No Document 3 Found");
            //}
            var mapDocument = _mapper.Map<List<Document3DTO>>(Document3);
            return Ok(mapDocument);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document3>> GetDocument3ById(int id)
        {
            var existDocument3 = await _repository.GetDocument3ById(id);
            //if (existDocument3 == null)
            //{
            //    return NotFound("No Document 3 Available");
            //}
            var mapDocument = _mapper.Map<Document3DTO>(existDocument3);
            if (mapDocument.ApproveBy.HasValue)
            {
                var getUser = await _userRepository.GetUserById(mapDocument.ApproveBy.Value);
                if (getUser != null)
                {
                    mapDocument.ApproveByName = getUser.FullName;
                }
            }
            return Ok(mapDocument);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetDoucment3ByCondition(string condition)
        {
            var existDocument3 = await _repository.GetDocument3sByCondition(condition);
            //if (existDocument3 == null)
            //{
            //    return NotFound("No Document 3 Available");
            //}
            var mapDocument = _mapper.Map<List<Document3DTO>>(existDocument3);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document3>> AddDocument3(Document3DTO pl3)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument3(int id)
        {
            var result = await _repository.DeleteDocument3(id);
            if (!result)
            {
                return NotFound("No Document 3 Available");
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument3(Document3DTO pl3)
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

        [HttpPut("ApproveDocument3")]
        public async Task<IActionResult> ApproveDocument3(Document3DTO pl3)
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

        [HttpDelete("DeleteDocument3ForeignTableByDocument3Id")]
        public async Task<IActionResult> DeleteDocument3ForeignTableByDocument3Id(int id)
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