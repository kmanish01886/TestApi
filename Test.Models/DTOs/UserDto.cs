using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public required string DisplayName { get; set; }
        public required string Email { get; set; }
        public string? ImageUrl { get; set; }
        public required string? Token { get; set; }

    }
}
