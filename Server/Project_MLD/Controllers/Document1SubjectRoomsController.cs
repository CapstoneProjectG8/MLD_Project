using AutoMapper;
using AutoMapper.Internal;
using Azure.Core;
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
    public class Document1SubjectRoomsController : ControllerBase
    {
        private readonly IDocument1SubjectRoomsRepository _repository;
        private readonly IMapper _mapper;

        public Document1SubjectRoomsController(IDocument1SubjectRoomsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet("GetDoc1SubjectRoomByDoc1ID")]
        public async Task<ActionResult<IEnumerable<Document1SubjectRoom>>> GetDocument1SubjectRoomByDocument1ID(int id)
        {
            var subjectRoom = await _repository.GetSubjectRoomsByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1SubjectRoomDTO>>(subjectRoom);
            return Ok(mapper);
        }

        public class RequestDoc1SubjectRoom
        {
            public int? SubjectRoomId { get; set; }

            public int Document1Id { get; set; }

            public int? Quantity { get; set; }

            public string? Description { get; set; }

            public string? Note { get; set; }

        }

        [HttpPost("AddDoc1SubjectRoom")]
        public async Task<IActionResult> AddDoc1SubjectRoom([FromBody] List<RequestDoc1SubjectRoom> listRequest)
        {
            try
            {
                var listDTO = new List<Document1SubjectRoomDTO>();
                foreach (var itemList in listRequest)
                {
                    var doc1SR = new Document1SubjectRoomDTO
                    {
                        SubjectRoomId = itemList.SubjectRoomId,
                        Document1Id = itemList.Document1Id,
                        Quantity = itemList.Quantity,
                        Note = itemList.Note,
                        Description = itemList.Description
                    };
                    listDTO.Add(doc1SR);
                }
                var mapRequests = _mapper.Map<List<Document1SubjectRoom>>(listDTO);

                await _repository.AddDocument1SubjectRoom(mapRequests);

                return Ok("add Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while add Document1 Subject Room: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1SubjectRoom")]
        public async Task<IActionResult> DeleteDocument1SubjectRoom(List<Document1SubjectRoomDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1SubjectRoom>>(requests);
                await _repository.DeleteDocument1SubjectRoom(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 Subject Room: {ex.Message}");
            }
        }

        //[HttpDelete("DeleteDocument1SubjectRoomByDocument1Id")]
        //public async Task<IActionResult> DeleteDocument1SubjectRoomByDocument1Id(int id)
        //{
        //    try
        //    {
        //        await _repository.DeleteDocument1SubjectRoomByDoc1Id(id);

        //        return Ok("Delete Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return StatusCode(500, $"An error occurred while delete Document1 Subject Room: {ex.Message}");
        //    }
        //}
    }
}
