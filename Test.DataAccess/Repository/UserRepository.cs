
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Repository.IRepository;
using Test.Models.Entities;

namespace Test.DataAccess.Repository
{ 
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitofwork;
        public UserRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<AppUser> Create(AppUser model)
        {
            try
            {
                var repository = _unitofwork.GetRepository<AppUser>();
                repository.Add(model);
                using (var transaction = repository.BeginTransaction())
                {
                    await repository.SaveChangesAsync();
                    transaction.Commit();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(AppUser model)
        {
            try
            {
                var assetGroupRepository = _unitofwork.GetRepository<AppUser>();
                assetGroupRepository.Delete(model);
                using (var transaction = assetGroupRepository.BeginTransaction())
                {
                    await assetGroupRepository.SaveChangesAsync();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyList<AppUser>> GetAll()
        {
            try
            {
                var repository = _unitofwork.GetRepository<AppUser>();
                /*IList<AppUser>*/ var results = await repository.Query().ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AppUser> GetById(string Id)
        {
            try
            {
                var repository = _unitofwork.GetRepository<AppUser>();
                var result = await repository.Query().Where(l => l.Id == Id).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IList<AppUser>> GetByStateId(int StateId)
        {
            try
            {
                var repository = _unitofwork.GetRepository<AppUser>();
                IList<AppUser> results = await repository.Query().ToListAsync();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AppUser> Update(AppUser model)
        {
            try
            {
                var repository = _unitofwork.GetRepository<AppUser>();
                repository.Update(model);
                using (var transaction = repository.BeginTransaction())
                {
                    await repository.SaveChangesAsync();
                    transaction.Commit();
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
