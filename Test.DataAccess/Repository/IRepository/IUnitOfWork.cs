using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        IRepository<T> GetRepository<T>()
      where T : class;
    }
}
