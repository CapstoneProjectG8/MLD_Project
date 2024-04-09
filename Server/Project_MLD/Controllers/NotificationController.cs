using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _repository;
        public NotificationController(INotificationRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<Notification>> GetAllNotification()
        {
            return await _repository.GetAllNotification();
        }

        [HttpGet("id")]
        public async Task<Notification> GetNotificationById(int id)
        {
            return await _repository.GetNotificationById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> AddNotification(Notification notification)
        {
            try
            {
                await _repository.AddNotification(notification);
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
