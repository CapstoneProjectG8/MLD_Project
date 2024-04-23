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
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;
        public NotificationController(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAllNotification()
        {
            var noti = await _repository.GetAllNotification();
            var mapAddNoti = _mapper.Map<List<NotificationDTO>>(noti);
            return Ok(mapAddNoti);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        {
            var noti = await _repository.GetNotificationById(id);
            var mapAddNoti = _mapper.Map<NotificationDTO>(noti);
            return Ok(mapAddNoti);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> AddNotification(NotificationDTO dto, int documentId)
        {
            try
            {
                var mapNoti = _mapper.Map<Notification>(dto);
                var addNoti = await _repository.AddNotification(mapNoti);
                var mapAddNoti = _mapper.Map<NotificationDTO>(addNoti);
                return Ok(mapAddNoti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
