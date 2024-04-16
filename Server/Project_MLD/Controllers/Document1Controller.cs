﻿using AutoMapper;
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
    public class Document1Controller : ControllerBase
    {
        private readonly IDocument1Repository _repository;
        private readonly IMapper _mapper;

        public Document1Controller(IDocument1Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document1>>> GetAllDocument1()
        {
            var Document1 = await _repository.GetAllDocument1s();
            if (Document1 == null || Document1.Count() == 0)
            {
                return NotFound("No Document 1 Available");
            }
            var mappedDocuments = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mappedDocuments);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Document1>> GetDocument1ById(int id)
        {
            var Document1 = await _repository.GetDocument1ById(id);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Available");
            }
            var mappedDocuments = _mapper.Map<Document1DTO>(Document1);
            return Ok(mappedDocuments);
        }

        [HttpGet("ByCondition/{condition}")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetDocument1ByCondition(string condition)
        {
            var Document1 = await _repository.GetDocument1ByCondition(condition);
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpGet("ByApprove")]
        public async Task<ActionResult<IEnumerable<Document1>>> GetDocument1ByApproval()
        {
            var Document1 = await _repository.GetDocument1ByApproval();
            if (Document1 == null)
            {
                return NotFound("No Document 1 Found");
            }
            var mapDocument = _mapper.Map<List<Document1DTO>>(Document1);
            return Ok(mapDocument);
        }

        [HttpPost]
        public async Task<ActionResult<Document1>> AddDocument1(Document1 doc1)
        {

            var document = await _repository.AddDocument1(doc1);
            var mapper = _mapper.Map<Document1DTO>(document);
            return Ok(mapper);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument1(int id)
        {
            var result = await _repository.DeleteDocument1(id);
            if (!result)
            {
                return NotFound("No Document 1 Available");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument1(int id, Document1 document1)
        {
            if (id != document1.Id)
            {
                return NotFound("Id Not Match");
            }
            var result = await _repository.UpdateDocument1(document1);
            if (!result)
            {
                return BadRequest("Error Updating Document 1");
            }
            var mapper = _mapper.Map<Document1DTO>(document1);
            return Ok(new
            {
                message = "Update Success",
                mapper
            });
        }
    }
}
