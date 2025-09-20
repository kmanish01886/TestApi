using Test.DataAccess.Repository;
using Test.DataAccess.Repository.IRepository;
using Test.Models.DTOs;
using Test.Models.Entities;

namespace Test.API.Extensions
{
    public static class AppUserExtensions
    {
        public static UserDto ToDto(this AppUser user, ITokenService tokenService)
        {
            return new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}
