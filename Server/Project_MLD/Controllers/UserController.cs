using AutoMapper;
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

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            var mapperUser = _mapper.Map<List<UserDTO>>(users);
            return Ok(mapperUser);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var exUser = await _repository.GetUserById(id);
            if (exUser == null)
            {
                return NotFound("User Not Found");
            }
            var mapperUser = _mapper.Map<UserDTO>(exUser);
            return Ok(mapperUser);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser(UserDTO user)
        {
            try
            {
                var u = await _repository.AddUser(_mapper.Map<User>(user));
                return Ok(u);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            try
            {
                var mapUser = _mapper.Map<User>(user);

                var result = await _repository.UpdateUser(mapUser);
                if (!result)
                {
                    return BadRequest("Can not Update");
                }
                return Ok("Update Success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
