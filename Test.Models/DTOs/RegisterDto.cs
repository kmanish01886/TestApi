﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.DTOs
{
    public class RegisterDto
    {
        public required string DisplayName { get; set; }
        public required string Email { get; set; }   
        public required string Password { get; set; }
    }
}
