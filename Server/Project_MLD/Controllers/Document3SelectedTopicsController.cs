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

        [HttpGet("GetDoc3SelectedTopicsByDoc3ID/{id}")]
        public async Task<ActionResult<IEnumerable<Document3SelectedTopic>>> GetDocument3SelectedTopicsByDocument3ID(int id)
        {
            var cd = await _repository.GetDocument3SelectedTopicsByDocument3Id(id);
            var mapper = _mapper.Map<List<Document3SelectedTopicDTO>>(cd);
            return Ok(mapper);
        }

        [HttpPut("UpdateDoc3SelectedTopics")]
        public async Task<IActionResult> UpdateDocument3SelectedTopics(List<Document3SelectedTopicDTO> requests)
        {
            try
            {
                var mapRequests = _mapper.Map<List<Document3SelectedTopic>>(requests);
                await _repository.UpdateDocument3SelectedTopics(mapRequests);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Document3 Selected Topic: {ex.Message}");
            }
        }

        [HttpPut("AddDocument3SelectedTopics")]
        public async Task<IActionResult> AddDocument3SelectedTopics(int document3Id, int? selectedTopicsId, List<int?> listEquipment,
            int? subjectId, int? slot, DateOnly time)
        {
            try
            {
                var listDoc3 = new List<Document3SelectedTopic>();
                var doc3SelectedTopics = new Document3SelectedTopic();
                doc3SelectedTopics.Document3Id = document3Id;
                doc3SelectedTopics.SelectedTopicsId = (int)selectedTopicsId;
                doc3SelectedTopics.SelectedTopicsId = (int)selectedTopicsId;
                doc3SelectedTopics.Slot = slot;
                doc3SelectedTopics.Time = time;

                if (listEquipment != null)
                {
                    foreach (var item in listEquipment)
                    {
                        doc3SelectedTopics.EquipmentId = item.Value;
                        var doc = await _repository.AddDoc3SelectedTopics(doc3SelectedTopics);
                        listDoc3.Add(doc);
                    }
                    return Ok(listDoc3);
                }
                else
                {
                    var doc = await _repository.AddDoc3SelectedTopics(doc3SelectedTopics);
                    listDoc3.Add(doc);
                    return Ok(listDoc3);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding document 3 selected topic.");
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
