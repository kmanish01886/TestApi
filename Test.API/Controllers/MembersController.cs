
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.DataAccess.Repository.IRepository;
using Test.Models.Entities;

namespace Test.API.Controllers
{
    
    public class MembersController : BaseApiController
    {
        private readonly IUserRepository _userService;

        public MembersController(IUserRepository userService)
        {
            _userService = userService;
        }
       [HttpGet("AllMembers")]
        public async Task<ActionResult<IReadOnlyList<AppUser>>>GetMembers()
        {
            var members =await _userService.GetAll();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetMember(string id)
        {
            var member = await _userService.GetById(id);
            return Ok(member);
        }




    }
}
