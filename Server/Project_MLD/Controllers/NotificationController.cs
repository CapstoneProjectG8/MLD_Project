using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System.Formats.Asn1;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IDocument1Repository _document1Repository;
        private readonly IDocument2Repository _document2Repository;
        private readonly IDocument3Repository _document3Repository;
        private readonly IDocument4Repository _document4Repository;
        private readonly IDocument5Repository _document5Repository;
        private readonly INotificationRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public NotificationController(
            IDocument1Repository document1Repository,
            IDocument2Repository document2Repository,
            IDocument3Repository document3Repository,
            IDocument4Repository document4Repository,
            IDocument5Repository document5Repository,
            INotificationRepository notificationRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _document1Repository = document1Repository;
            _document2Repository = document2Repository;
            _document3Repository = document3Repository;
            _document4Repository = document4Repository;
            _document5Repository = document5Repository;
            _repository = notificationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("GetNotificationByReceiverId/{receiverId}")]
        public async Task<ActionResult<Notification>> GetNotificationByReceiverId(int receiverId)
        {
            var notification = await _repository.GetNotificationByReceiveIdDESC(receiverId);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpGet("GetNotificationById/{id}")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        {
            var notification = await _repository.GetNotificationById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        public class NotificationRequest()
        {
            public string? TitleName { get; set; }

            public int SentBy { get; set; }

            public List<int>? ReceiveBy { get; set; }

            public string? Message { get; set; }

            public int? DocType { get; set; }

            public int? DocId { get; set; }
        }


        [HttpPost("AddNotification")]
        public async Task<ActionResult<Notification>> AddNotification([FromBody] List<NotificationRequest> listRequest)
        {
            try
            {
                foreach (var itemRequest in listRequest)
                {
                    if (itemRequest.ReceiveBy != null)
                    {
                        foreach (var item in itemRequest.ReceiveBy)
                        {
                            var notification = new NotificationDTO
                            {
                                TitleName = itemRequest.TitleName,
                                SentBy = itemRequest.SentBy,
                                ReceiveBy = item,
                                Message = itemRequest.Message,
                                DocType = itemRequest.DocType,
                                DocId = itemRequest.DocId
                            };

                            var mapperNotification = _mapper.Map<Notification>(notification);
                            var addedNotification = await _repository.AddNotification(mapperNotification);
                        }
                    }
                    else
                    {
                        return NotFound("Receive By is Null");
                    }
                }
                return Ok("Add Noti Success");
            }
            catch (Exception ex)
            {
                throw new Exception("Can not add notification. " + ex.Message);
            }
        }

        [HttpGet("GetDocByDocTypeAndId")]
        public async Task<IActionResult> GetDocByDocTypeAndId(int docType, int docId)
        {
            try
            {
                switch (docType)
                {
                    case 1:
                        var doc1 = await _document1Repository.GetDocument1ById(docId);
                        if (doc1 != null)
                        {
                            var mapperDoc1 = _mapper.Map<Document1DTO>(doc1);
                            return Ok(mapperDoc1);
                        }
                        else
                        {
                            return NotFound("Doc 1 Not Found");
                        }
                    case 2:
                        var doc2 = await _document2Repository.GetDocument2ById(docId);
                        if (doc2 != null)
                        {
                            var mapperDoc2 = _mapper.Map<Document2DTO>(doc2);
                            return Ok(mapperDoc2);
                        }
                        else
                        {
                            return NotFound("Doc 2 Not Found");
                        }
                    case 3:
                        var doc3 = await _document3Repository.GetDocument3ById(docId);
                        if (doc3 != null)
                        {
                            var mapperDoc3 = _mapper.Map<Document3DTO>(doc3);
                            return Ok(mapperDoc3);
                        }
                        else
                        {
                            return NotFound("Doc 3 Not Found");
                        }
                    case 4:
                        var doc4 = await _document4Repository.GetDocument4ById(docId);
                        if (doc4 != null)
                        {
                            var mapperDoc4 = _mapper.Map<Document4DTO>(doc4);
                            return Ok(mapperDoc4);
                        }
                        else
                        {
                            return NotFound("Doc 4 Not Found");
                        }
                    case 5:
                        var doc5 = await _document5Repository.GetDocument5ById(docId);
                        if (doc5 != null)
                        {
                            var mapperDoc5 = _mapper.Map<Document5DTO>(doc5);
                            return Ok(mapperDoc5);
                        }
                        else
                        {
                            return NotFound("Doc 5 Not Found");
                        }
                    default:
                        return BadRequest("Error List");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request, " + ex.Message);
            }
        }

        [HttpGet("GetListIdOfTeacherAndPricipleByDepartmentId")]
        public async Task<ActionResult> GetListIdOfTeacherAndPricipleByDepartmentId([FromQuery] List<int> listDepartmentId)
        {
            var teacher = new List<int>();
            var principle = new List<int>();
            var leader = new List<int>();   

            foreach (var id in listDepartmentId)
            {
                var users = await _userRepository.GetAllUsersByDepartmentId(id);

                foreach (var person in users)
                {
                    if (person.Account.Role.RoleId == 2)
                    {
                        teacher.Add(person.Id);
                    }else if (person.Account.Role.RoleId == 3)
                    {
                        leader.Add(person.Id);
                    }
                }
            }

            var getUserPrinciple = await _userRepository.GetPrinciples();
            var mapperPrinciple = _mapper.Map<List<UserDTO>>(getUserPrinciple);
            if (mapperPrinciple != null)
            {
                foreach (var user in mapperPrinciple)
                {
                    principle.Add((int)user.Id);
                }
            }
            return Ok(new
            {
                principle,
                teacher,
                leader
            });
        }

        [HttpGet("GetListHostbyByIdOfUserByDoc2Id")]
        public async Task<ActionResult> GetListHostbyByIdOfUserByDoc2Id(int doc2Id)
        {
            var id = await _document2Repository.GetListHostbyByIdOfUserByDoc2Id(doc2Id);
            return Ok(id);
        }

    }
}
