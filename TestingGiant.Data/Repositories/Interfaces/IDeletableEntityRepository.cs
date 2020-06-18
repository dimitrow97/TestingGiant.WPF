using System.Linq;

namespace TestingGiant.Data.Repositories.Interfaces
{
    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void ActualDelete(T entity);
    }
}