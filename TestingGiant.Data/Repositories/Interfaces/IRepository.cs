using System;
using System.Linq;

namespace TestingGiant.Data.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(string id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(string id);

        void Detach(T entity);

        int SaveChanges();
    }
}