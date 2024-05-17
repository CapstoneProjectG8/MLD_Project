using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Document2Controller(IDocument2Repository repository, IMapper mapper, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("GetAllDoc2s")]
        public async Task<ActionResult<IEnumerable<Document2DTO>>> GetAllDocument2s()
        {
            var pl2 = await _repository.GetAllDocument2s();
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            foreach (var pl in mapDocumemt)
            {
                if (pl.ApproveBy.HasValue)
                {
                    var getUser = await _userRepository.GetUserById(pl.ApproveBy.Value);
                    if (getUser != null)
                    {
                        pl.ApproveByName = getUser.FirstName + " " + getUser.LastName;
                    }
                }
                var getUserName = await _userRepository.GetUserById(pl.UserId);
                pl.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            }
            return Ok(mapDocumemt);
        }

        [HttpGet("GetAllDoc2sWithCondition")]
        public async Task<ActionResult<IEnumerable<Document2DTO>>> GetAllDoc2sWithCondition(bool? status, int? isApprove)
        {
            var pl2 = await _repository.GetAllDoc2sByCondition(status, isApprove);
            var mapDocumemt = _mapper.Map<List<Document2DTO>>(pl2);
            foreach (var pl in mapDocumemt)
            {
                if (pl.ApproveBy.HasValue)
                {
                    var getUser = await _userRepository.GetUserById(pl.ApproveBy.Value);
                    if (getUser != null)
                    {
                        pl.ApproveByName = getUser.FirstName + " " + getUser.LastName;
                    }
                }
                var getUserName = await _userRepository.GetUserById(pl.UserId);
                pl.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            }
            return Ok(mapDocumemt);
        }

        [HttpGet("GetDoc2ByUserDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetDocument2ByUserSpecialiedDepartment([FromQuery] List<int> listId)
        {
            var documents = await _repository.GetDocument2ByUserSpecialiedDepartment(listId);
            var modifiedDocuments = new List<object>();
            foreach (var document in documents)
            {
                if (document.GetType().GetProperty("id") != null && document.GetType().GetProperty("document") != null)
                {
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

        [HttpGet("GetDoc2ById/{id}")]
        public async Task<ActionResult<Document2DTO>> GetDocument2ById(int id)
        {
            var existDocument2 = await _repository.GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return StatusCode(200, "No Document 2 Found");
            }
            var mapDocumemt = _mapper.Map<Document2DTO>(existDocument2);
            if (mapDocumemt.ApproveBy != null)
            {
                var getUser = await _userRepository.GetUserById((int)mapDocumemt.ApproveBy);
                if (getUser != null)
                {
                    mapDocumemt.ApproveByName = getUser.FirstName + " " + getUser.LastName;
                }
            }
            var getUserName = await _userRepository.GetUserById(mapDocumemt.UserId);
            mapDocumemt.UserFullName = getUserName.FirstName + " " + getUserName.LastName;
            return Ok(mapDocumemt);
        }

        [HttpPost("AddDocument2")]
        public async Task<ActionResult<Document2DTO>> AddDocument2(List<Document2DTO> doc2)
        {
            try
            {
                var listDocumentDTO = new List<Document2DTO>();
                foreach (var item in doc2)
                {
                    //Bien truyen
                    item.Status = true;
                    item.CreatedDate = DateOnly.FromDateTime(DateTime.Now);

                    var document = _mapper.Map<Document2>(item);
                    var addedDocument = await _repository.AddDocument2(document);
                    if (addedDocument == null)
                    {
                        return BadRequest("Error Adding Document1");
                    }
                    var doc = _mapper.Map<Document2DTO>(addedDocument);
                    listDocumentDTO.Add(doc);
                }
                return Ok(listDocumentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Can not add Error, " + ex.Message);
            }
        }

        [HttpDelete("DeleteDoc2/{id}")]
        public async Task<IActionResult> DeleteDocument2(int id)
        {
            var result = await _repository.DeleteDocument2(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("UpdateDoc2")]
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

        [HttpPut("ApproveDoc2")]
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

        [HttpGet("GetUserByDepId")]
        public async Task<IActionResult> GetUserByDepId([FromQuery] List<int> depIds)
        {
            var listUser = new List<object>();

            foreach (var id in depIds)
            {
                var user = await _userRepository.GetAllUsersByDepartmentId(id);
                var mapperUser = _mapper.Map<List<UserDTO>>(user);
                listUser.Add(mapperUser);
            }

            return Ok(listUser);
        }

    }
}
