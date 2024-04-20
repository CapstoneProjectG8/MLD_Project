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
    public class Document2Controller : ControllerBase
    {
        private readonly IDocument2Repository _repository;
        private readonly IMapper _mapper;

        public Document2Controller(IDocument2Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document2>>> GetAllDocument2s()
        {
            var pl2 = await _repository.GetAllDocument2s();
            if (pl2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            return Ok(mapDocumemt);
        }

        [HttpGet("GetDocument2ByUserSpecialiedDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetDocument2ByUserSpecialiedDepartment([FromQuery] List<int> listId)
        {
            //var pl2 = await _repository.GetDocument2ByUserSpecialiedDepartment(specializedDepartmentId);
            //if (pl2 == null)
            //{
            //    return NotFound("No Document 2 Found");
            //}
            //var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            //return Ok(mapDocumemt);


            var documents = await _repository.GetDocument2ByUserSpecialiedDepartment(listId);
            var modifiedDocuments = new List<object>();

            foreach (var document in documents)
            {
                // Kiểm tra xem document có thuộc tính "id" và "document" không
                if (document.GetType().GetProperty("id") != null && document.GetType().GetProperty("document") != null)
                {
                    // Truy cập thuộc tính "id" và "document"
                    var id = document.GetType().GetProperty("id").GetValue(document, null);
                    var doc = document.GetType().GetProperty("document").GetValue(document, null);

                    var dataMap = _mapper.Map<List<Document2DTO>>(doc);

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

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document2>> GetDocument2ById(int id)
        {
            var existDocument2 = await _repository.GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return NotFound();
            }
            var mapDocumemt = _mapper.Map<Document2DTO>(existDocument2);
            return Ok(mapDocumemt);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDoucment2ByCondition(string condition)
        {
            var existDocument2 = await _repository.GetDocument2ByCondition(condition);
            if (existDocument2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(existDocument2);
            return Ok(mapDocumemt);
        }

        [HttpGet("ByApproveID/{id}")]
        public async Task<ActionResult<IEnumerable<Document2>>> GetDocument2ByApprovalID(int id)
        {
            var document2 = await _repository.GetDocument2ByApprovalID(id);
            if (document2 == null)
            {
                return NotFound("No Document 2 Found");
            }
            var mapDocument = _mapper.Map<List<Document2DTO>>(document2);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document2>> AddDocument2(Document2DTO doc2)
        {
            try
            {
                var document = _mapper.Map<Document2>(doc2);
                var addedDocument = await _repository.AddDocument2(document);
                if (addedDocument == null)
                {
                    return BadRequest("Error Adding Document1");
                }
                var addedDocumentDTO = _mapper.Map<Document2DTO>(addedDocument);
                return Ok(addedDocumentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Can not add Error, " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument2(int id)
        {
            var result = await _repository.DeleteDocument2(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument2(Document2DTO pl2)
        {
            var mapDocument = _mapper.Map<Document2>(pl2);
            var result = await _repository.UpdateDocument2(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating Document 2");
            }
            var data = _mapper.Map<Document2DTO>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                data
            });
        }

        [HttpPut("ApproveDocument2/{id}")]
        public async Task<IActionResult> ApproveDocument2(Document2DTO pl2)
        {
            var mapDocument = _mapper.Map<Document2>(pl2);
            var result = await _repository.UpdateDocument2(mapDocument);
            if (!result)
            {
                return BadRequest("Error Updating Document 2");
            }
            var data = _mapper.Map<Document2DTO>(mapDocument);
            return Ok(new
            {
                message = "Update Success",
                data
            });
        }
    }
}
