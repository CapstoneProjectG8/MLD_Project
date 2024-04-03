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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var users = await _repository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var exUser = await _repository.GetUserById(id);
            if (exUser == null)
            {
                return NotFound();
            }

            return Ok(exUser);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserDTO user)
        {
            user.CreatedBy = 1;
            user.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            var u = await _repository.AddUser(_mapper.Map<User>(user));
            return Ok(u);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User cl)
        {
            if (id != cl.Id)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateUser(cl);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
