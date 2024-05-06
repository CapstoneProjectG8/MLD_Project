﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document1TeachingEquipmentController : ControllerBase
    {
        private readonly IDocument1TeachingEquipmentRepository _repository;
        private readonly IMapper _mapper;

        public Document1TeachingEquipmentController(IDocument1TeachingEquipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet("GetDoc1TeachingEquipmentByDoc1ID")]
        public async Task<ActionResult<IEnumerable<Document1TeachingEquipment>>> GetDocument1TeachingEquipmentByDocument1ID(int id)
        {
            var TeachingEquipment = await _repository.GetTeachingEquipmentByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1TeachingEquipmentsDTO>>(TeachingEquipment);
            return Ok(mapper);
        }

        [HttpPost("AddDoc1TeachingEquipment")]
        public async Task<IActionResult> AddDoc1TeachingEquipment(List<Document1TeachingEquipmentsDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1TeachingEquipment>>(requests);

                await _repository.AddDocument1TeachingEquipment(mapRequests);

                return Ok("add Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while add Document1 TeachingEquipment: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDoc1TeachingEquipment")]
        public async Task<IActionResult> DeleteDocument1TeachingEquipment( List<Document1TeachingEquipmentsDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1TeachingEquipment>>(requests);
                await _repository.DeleteDocument1TeachingEquipment(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while delete Document1 Teaaching Equipment: {ex.Message}");
            }
        }

        //[HttpDelete("DeleteDocument1TeachingEquipmentByDocument1Id")]
        //public async Task<IActionResult> DeleteDocument1TeachingEquipmentByDocument1Id(int id)
        //{
        //    try
        //    {
        //        await _repository.DeleteDocument1TeachingEquipmentByDoc1ID(id);

        //        return Ok("Delete Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return StatusCode(500, $"An error occurred while delete Document1 Teaching Equipment Room: {ex.Message}");
        //    }
        //}
    }
}
