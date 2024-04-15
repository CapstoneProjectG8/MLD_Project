﻿using AutoMapper;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document1SubjectRoom>>> GetDocument1SubjectRoomByDocument1ID(int id)
        {
            var subjectRoom = await _repository.GetSubjectRoomsByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1SubjectRoomDTO>>(subjectRoom);
            return Ok(mapper);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1SubjectRoom(int documentId, List<Document1SubjectRoomDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document1Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }

                var mapRequests = _mapper.Map<List<Document1SubjectRoom>>(requests);

                await _repository.UpdateDocument1SubjectRoom(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document1 Subject Room: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDocument1SubjectRoom(int documentId, List<Document1SubjectRoomDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    if (request.Document1Id != documentId)
                    {
                        return BadRequest("Id Not Match");
                    }
                }
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
    }
}