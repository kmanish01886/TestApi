using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Test.API.Extensions;
using Test.DataAccess.Repository;
using Test.DataAccess.Repository.IRepository;
using Test.Models.DTOs;
using Test.Models.Entities;

namespace Test.API.Controllers
{
    public class AccountController : BaseApiController
    {
        public readonly IUserRepository _userRepository;
        public readonly ITokenService _tokernService;


        public AccountController(IUserRepository user, ITokenService tokenService) {
            _userRepository = user;
            _tokernService = tokenService;
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
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {

            var user = await _userRepository.GetByEmail(dto.Email);
            if (user==null)
            {
                return Unauthorized("This Email " + dto.Email + " is invalid");
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            for(var i=0; i<computeHash.Length; i++)
                {
                if (computeHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid password");
            }

            return Ok(user.ToDto(_tokernService));
        }
    }
}
