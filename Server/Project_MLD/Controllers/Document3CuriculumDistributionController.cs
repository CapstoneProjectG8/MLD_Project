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

        [HttpPost("AddDoc3CurriculumDistribution")]
        public async Task<IActionResult> AddDoc3CurriculumDistribution(int document3Id, int? curriculumId, List<int?> listEquipmentIds,
            int? subjectRoomId, int slot, DateOnly time)
        {
            try
            {
                var doc3 = new List<Document3CurriculumDistribution>();

                var docDistribution = new Document3CurriculumDistribution();
                docDistribution.Document3Id = document3Id;
                docDistribution.CurriculumId = (int)curriculumId;
                docDistribution.SubjectRoomId = (int)subjectRoomId;
                docDistribution.Slot = slot;
                docDistribution.Time = time;

                if (listEquipmentIds != null)
                {
                    foreach (var item in listEquipmentIds)
                    {
                        docDistribution.EquipmentId = item.Value;
                        var doc = await _repository.AddDoc3curriculumDistribution(docDistribution);
                        doc3.Add(doc);
                    }
                    return Ok(doc3);
                }
                else
                {
                    var doc = await _repository.AddDoc3curriculumDistribution(docDistribution);
                    doc3.Add(doc);
                    return Ok(doc3);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
