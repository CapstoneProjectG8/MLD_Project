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
    public class Document1SelectedTopicController : ControllerBase
    {
        private readonly IDocument1SelectedTopicsRepository _repository;
        private readonly IMapper _mapper;

        public Document1SelectedTopicController(IDocument1SelectedTopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Document1SelectedTopic>> GetDocument1SelectedTopicByDocument1ID(int id)
        {
            var selectedTopic = await _repository.GetSelectedTopicByDocument1Id(id);
            return Ok(selectedTopic);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1SelectedTopic(int documentId, List<Document1SelectedTopicsDTO> requests)
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
                var mapRequests = _mapper.Map<List<Document1SelectedTopic>>(requests);
                foreach (var item in requests)
                {
                    await _repository.UpdateDocument1SelectedTopic(mapRequests);
                }
                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document1 SelectedTopic: {ex.Message}");
            }
        }
    }
}