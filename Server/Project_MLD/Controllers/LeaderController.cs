using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        private readonly IDocument1Repository _document1Repository;
        private readonly IDocument2Repository _document2Repository;
        private readonly IDocument3Repository _document3Repository;
        private readonly IDocument4Repository _document4Repository;
        private readonly IDocument5Repository _document5Repository;
        private readonly IMapper _mapper;

        public LeaderController(IDocument1Repository document1Repository, IDocument2Repository document2Repository, IDocument3Repository document3Repository, IDocument4Repository document4Repository, IDocument5Repository document5Repository, IMapper mapper)
        {
            _document1Repository = document1Repository;
            _document2Repository = document2Repository;
            _document3Repository = document3Repository;
            _document4Repository = document4Repository;
            _document5Repository = document5Repository;
            _mapper = mapper;
        }

        //[HttpPost("SendDocument1ToPrinciple")]
        //public async Task<ActionResult<Document1>> SendDocument1ToPrinciple(int document1ID)
        //{
        //    //Get Document Id

        //    //lấy ra sc3 file link của Document 1 
        //    //Add 1 Notification// bao gôm userId của người gửi// kèm message//trong message có name của document1 
        //    //Save Changes


        //    //return Document 1 với  message có link
        //}
    }
}
