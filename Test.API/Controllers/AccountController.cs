using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Test.DataAccess.Repository.IRepository;
using Test.Models.DTOs;
using Test.Models.Entities;

namespace Test.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public readonly IUserRepository _userRepository;
        public AccountController(IUserRepository user) {
            _userRepository = user;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto dto)
        {
            
            bool email=await _userRepository.EmailExist(dto.Email);
            if (email) { 
                return BadRequest("This Email "+dto.Email + " is teken");
            }

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };
            await _userRepository.Create(user);
            return Ok(user);

        }


    }
}
