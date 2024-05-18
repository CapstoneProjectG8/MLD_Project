using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using static Project_MLD.Controllers.Document2Controller;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document3CuriculumDistributionController : ControllerBase
    {
        private readonly IDocument3CurriculumDistributionRepository _repository;
        private readonly IMapper _mapper;

        public Document3CuriculumDistributionController(IDocument3CurriculumDistributionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllByDoc3ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3CurriculumDistribution>>> GetDoc3CuriculumDistributionByDoc3ID(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);
            return Ok(mapper);
        }

        [HttpGet("GetAllByDoc1ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3CurriculumDistribution>>> GetCurriculumDistributionByDocument1Id(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument1Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);
            return Ok(mapper);
        }

        public class Doc3CDRequest
        {
            public int Id { get; set; }

            public int Document3Id { get; set; }

            public int? CurriculumId { get; set; }

            public List<int>? EquipmentId { get; set; }

            public int? SubjectRoomId { get; set; }

            public int? Slot { get; set; }

            public DateOnly? Time { get; set; }
        }

        [HttpPost("AddDoc3CurriculumDistribution")]
        public async Task<IActionResult> AddDoc3CurriculumDistribution([FromBody] List<Doc3CDRequest> listRequest)
        {
            try
            {
                foreach (var itemList in listRequest)
                {
                    if (itemList.EquipmentId != null)
                    {
                        foreach (var equipment in itemList.EquipmentId)
                        {
                            var document3 = new Document3CurriculumDistributionDTO
                            {
                                Document3Id = itemList.Document3Id,
                                CurriculumId = itemList.CurriculumId,
                                EquipmentId = equipment,
                                SubjectRoomId = itemList.SubjectRoomId,
                                Slot = itemList.Slot,
                                Time = itemList.Time
                            };
                            var map = _mapper.Map<Document3CurriculumDistribution>(document3);
                            var doc = await _repository.AddDoc3curriculumDistribution(map);
                        }
                    }
                    else
                    {
                        var document3 = new Document3CurriculumDistributionDTO
                        {
                            Document3Id = itemList.Document3Id,
                            CurriculumId = itemList.CurriculumId,
                            EquipmentId = null,
                            SubjectRoomId = itemList.SubjectRoomId,
                            Slot = itemList.Slot,
                            Time = itemList.Time
                        };
                        var map = _mapper.Map<Document3CurriculumDistribution>(document3);
                        var doc = await _repository.AddDoc3curriculumDistribution(map);
                    }
                }
                return Ok("Add");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
