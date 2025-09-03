using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Entities;

namespace Test.DataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<AppUser>> GetAll();
        Task<AppUser> Create(AppUser model);
        Task<AppUser> GetById(string Id);
        Task<AppUser> Update(AppUser model);
        Task Delete(AppUser model);
        Task<IList<AppUser>> GetByStateId(int StateId);
        Task<bool> EmailExist(string email);

    }
}
