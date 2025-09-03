using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T-Department
        IQueryable<T> GetAll();
        T GetSingle(Expression<Func<T, bool>> predicate);
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        IQueryable<T> Query();
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        IDbContextTransaction BeginTransaction();
        Task SaveChangesAsync();

    }
}
