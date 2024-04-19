using AutoMapper;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document1TeachingEquipment>>> GetDocument1TeachingEquipmentByDocument1ID(int id)
        {
            var TeachingEquipment = await _repository.GetTeachingEquipmentByDocument1Id(id);
            var mapper = _mapper.Map<List<Document1TeachingEquipmentsDTO>>(TeachingEquipment);
            return Ok(mapper);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument1TeachingEquipment( List<Document1TeachingEquipmentsDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document1TeachingEquipment>>(requests);

                await _repository.UpdateDocument1TeachingEquipment(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, $"An error occurred while updating Document1 TeachingEquipment: {ex.Message}");
            }
        }

        [HttpDelete]
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
    }
}
