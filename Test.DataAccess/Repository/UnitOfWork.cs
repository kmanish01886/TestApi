using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Data;
using Test.DataAccess.Repository.IRepository;

namespace Test.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        private Dictionary<Type, object> repositories;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public IRepository<T> GetRepository<T>()
           where T : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }

            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new Repository<T>(this._db);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
