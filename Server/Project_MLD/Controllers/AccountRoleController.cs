using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleRepository _repository;

        public AccountRoleController(IAccountRoleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountRole>>> GetAllAccountRole()
        {
            var accountRoles = await _repository.GetAllAccountRoles();
            return Ok(accountRoles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountRole>> GetAccountRoleById(int id)
        {
            var existAR = await _repository.GetAccountRoleByAccountId(id);
            if (existAR == null)
            {
                return NotFound();
            }

            return Ok(existAR);
        }
    }
}
