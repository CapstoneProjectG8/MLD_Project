using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IDocument1Repository _document1Repository;
        private readonly IDocument2Repository _document2Repository;
        private readonly IDocument3Repository _document3Repository;
        private readonly IDocument4Repository _document4Repository;
        private readonly IDocument5Repository _document5Repository;
        private readonly IMapper _mapper;

        public CommonController(IDocument1Repository document1Repository,
            IDocument2Repository document2Repository,
            IDocument3Repository document3Repository,
            IDocument4Repository document4Repository,
            IDocument5Repository document5Repository,
            IMapper mapper)
        {
            _document1Repository = document1Repository;
            _document2Repository = document2Repository;
            _document3Repository = document3Repository;
            _document4Repository = document4Repository;
            _document5Repository = document5Repository;
            _mapper = mapper;
        }

        [HttpGet("GetDocumentByUserId")]
        public async Task<IActionResult> GetDocumentByUserId(int userId, int docType, int approveId)
        {
            try
            {
                switch (docType)
                {
                    case 1:
                        var doc1 = await _document1Repository.GetAllDocument1sByUserIdAndApproveId(userId, approveId);
                        if (doc1 != null)
                        {
                            var mapperDoc1 = _mapper.Map<List<Document1DTO>>(doc1);
                            return Ok(mapperDoc1);
                        }
                        else
                        {
                            return NotFound("Document 1 not found");
                        }
                    case 2:
                        var doc2 = await _document2Repository.GetAllDocument2sByUserIdAndApproveId(userId, approveId);
                        if (doc2 != null)
                        {
                            var mapperDoc2 = _mapper.Map<List<Document2DTO>>(doc2);
                            return Ok(mapperDoc2);
                        }
                        else
                        {
                            return NotFound("Document 2 not found");
                        }
                    case 3:
                        var doc3 = await _document3Repository.GetAllDocument3sByUserIdAndApproveId(userId, approveId);
                        if (doc3 != null)
                        {
                            var mapperDoc3 = _mapper.Map<List<Document3DTO>>(doc3);
                            return Ok(mapperDoc3);
                        }
                        else
                        {
                            return NotFound("Document 3 not found");
                        }
                    case 4:
                        var doc4 = await _document4Repository.GetDocument4sByUserId(userId);
                        if (doc4 != null)
                        {
                            var mapperDoc4 = _mapper.Map<List<Document4DTO>>(doc4);
                            return Ok(mapperDoc4);
                        }
                        else
                        {
                            return NotFound("Document 4 not found");
                        }
                    case 5:
                        var doc5 = await _document5Repository.GetDocument5sbyUserId(userId);
                        if (doc5 != null)
                        {
                            var mapperDoc5 = _mapper.Map<List<Document5DTO>>(doc5);
                            return Ok(mapperDoc5);
                        }
                        else
                        {
                            return NotFound("Document 5 not found");
                        }
                    default: return BadRequest("Doc Type: " + docType + " not Exist");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request., " + ex.Message);
            }
        }

    }
}
