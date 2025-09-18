using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Entities;

namespace Test.DataAccess.Repository.IRepository
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
