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
        public Document3Controller(IDocument3Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document3>>> GetAllDocument3s()
        {
            var document3s = await _repository.GetAllDocument3s();
            if (document3s == null || document3s.Count() == 0)
            {
                return NotFound("No Document 3 Available");
            }
            var mapDocument = _mapper.Map<List<Document3DTO>>(document3s);
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
            if (Document3 == null)
            {
                return NotFound("No Document 3 Found");
            }
            var mapDocument = _mapper.Map<List<Document3DTO>>(Document3);
            return Ok(mapDocument);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document3>> GetDocument3ById(int id)
        {
            var existDocument3 = await _repository.GetDocument3ById(id);
            if (existDocument3 == null)
            {
                return NotFound("No Document 3 Available");
            }

            return Ok(existDocument3);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document3>>> GetDoucment3ByCondition(string condition)
        {
            var existDocument3 = await _repository.GetDocument3sByCondition(condition);
            if (existDocument3 == null)
            {
                return NotFound("No Document 3 Available");
            }
            var mapDocument = _mapper.Map<List<Document3DTO>>(existDocument3);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document3>> AddDocument3(Document3DTO pl3)
        {
            try
            {
                pl3.Status = true;
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

        [HttpPut("{id}")]
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

        [HttpPut("ApproveDocument3/{id}")]
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
    }
}