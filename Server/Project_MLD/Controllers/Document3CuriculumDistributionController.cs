using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

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

        public class GroupedDocument3CurriculumDistributionDTO
        {
            public int Document3Id { get; set; }

            public int? CurriculumId { get; set; }

            public List<int>? EquipmentId { get; set; }

            public int? SubjectRoomId { get; set; }

            public int? Slot { get; set; }

            public DateOnly? Time { get; set; }
        }

        [HttpGet("GetAllByDoc3ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3CurriculumDistribution>>> GetDoc3CuriculumDistributionByDoc3ID(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);

            var groupedData = mapper
                .GroupBy(d => new
                {
                    d.Document3Id, d.CurriculumId, d.SubjectRoomId, d.Slot, d.Time

                })
                .Select(g => new GroupedDocument3CurriculumDistributionDTO
                {
                    Document3Id = g.Key.Document3Id,
                    CurriculumId = g.Key.CurriculumId,
                    EquipmentId = g.Select(d => d.EquipmentId ?? 0).Where(h => h != 0).Distinct().ToList(),
                    SubjectRoomId = g.Key.SubjectRoomId,
                    Slot = g.Key.Slot,
                    Time = g.Key.Time
                    
                })
                .ToList();

            return Ok(groupedData);
        }

        [HttpGet("GetAllByDoc1ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3CurriculumDistribution>>> GetCurriculumDistributionByDocument1Id(int id)
        {
            var cd = await _repository.GetCurriculumDistributionByDocument1Id(id);
            var mapper = _mapper.Map<List<Document3CurriculumDistributionDTO>>(cd);

            var groupedData = mapper
                .GroupBy(d => new
                {
                    d.Document3Id,
                    d.CurriculumId,
                    d.SubjectRoomId,
                    d.Slot,
                    d.Time

                })
                .Select(g => new GroupedDocument3CurriculumDistributionDTO
                {
                    Document3Id = g.Key.Document3Id,
                    CurriculumId = g.Key.CurriculumId,
                    EquipmentId = g.Select(d => d.EquipmentId ?? 0).Where(h => h != 0).Distinct().ToList(),
                    SubjectRoomId = g.Key.SubjectRoomId,
                    Slot = g.Key.Slot,
                    Time = g.Key.Time
                })
                .ToList();

            return Ok(groupedData);
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
