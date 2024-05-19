using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Document3SelectedTopicsController : ControllerBase
    {
        private readonly IDocument3SelectedTopicsRepository _repository;
        private readonly IMapper _mapper;

        public Document3SelectedTopicsController(IDocument3SelectedTopicsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public class GroupDocument3SelectedTopicDTO
        {
            public int Document3Id { get; set; }
            public int? SelectedTopicsId { get; set; }
            public int? SubjectRoomId { get; set; }
            public int? Slot { get; set; }
            public DateOnly? Time { get; set; }
            public List<int>? EquipmentId { get; set; }
        }

        [HttpGet("GetDoc3SelectedTopicsByDoc3ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3SelectedTopic>>> GetDocument3SelectedTopicsByDocument3ID(int id)
        {
            var cd = await _repository.GetDocument3SelectedTopicsByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3SelectedTopicDTO>>(cd);

            // Group tất cả trùng nhau trừ HostBy
            var groupedData = mapper
                .GroupBy(d => new
                {
                    d.Document3Id,
                    d.SelectedTopicsId,
                    d.SubjectRoomId,
                    d.Slot,
                    d.Time
                })
                .Select(g => new GroupDocument3SelectedTopicDTO
                {
                    Document3Id = g.Key.Document3Id,
                    SelectedTopicsId = g.Key.SelectedTopicsId,
                    SubjectRoomId = g.Key.SubjectRoomId,
                    Slot = g.Key.Slot,
                    Time = g.Key.Time,
                    EquipmentId = g.Select(d => d.EquipmentId ?? 0).Where(h => h != 0).Distinct().ToList()
                })
                .ToList();
            return Ok(groupedData);
        }

        public class Doc3STRequest
        {
            public int Document3Id { get; set; }
            public int? SelectedTopicsId { get; set; }
            public List<int>? EquipmentId { get; set; }
            public int? SubjectRoomId { get; set; }
            public int? Slot { get; set; }
            public DateOnly? Time { get; set; }
        }

        [HttpPost("AddDocument3SelectedTopics")]
        public async Task<IActionResult> AddDocument3SelectedTopics(List<Doc3STRequest> listRequest)
        {

            try
            {
                foreach (var itemList in listRequest)
                {
                    if (itemList.EquipmentId != null)
                    {
                        foreach (var equipment in itemList.EquipmentId)
                        {
                            var document3 = new Document3SelectedTopicDTO
                            {
                                Document3Id = itemList.Document3Id,
                                SelectedTopicsId = itemList.SelectedTopicsId,
                                EquipmentId = equipment,
                                SubjectRoomId = itemList.SubjectRoomId,
                                Slot = itemList.Slot,
                                Time = itemList.Time
                            };
                            var map = _mapper.Map<Document3SelectedTopic>(document3);
                            var doc = await _repository.AddDoc3SelectedTopics(map);
                        }
                    }
                    else
                    {
                        var document3 = new Document3SelectedTopicDTO
                        {
                            Document3Id = itemList.Document3Id,
                            SelectedTopicsId = itemList.SelectedTopicsId,
                            EquipmentId = null,
                            SubjectRoomId = itemList.SubjectRoomId,
                            Slot = itemList.Slot,
                            Time = itemList.Time
                        };
                        var map = _mapper.Map<Document3SelectedTopic>(document3);
                        var doc = await _repository.AddDoc3SelectedTopics(map);
                    }
                }
                return Ok("Add");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteDoc3SelectedTopics")]
        public async Task<IActionResult> DeleteDocument3SelectedTopics(List<Document3SelectedTopicDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document3SelectedTopic>>(requests);
                await _repository.DeleteDocument3SelectedTopics(mapRequests);

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while delete Document3 Selected Topics: {ex.Message}");
            }
        }

    }
}
