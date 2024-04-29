using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace SoftServeCinema.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity entity);
        void Attach(TEntity entity);
        void CrearTracker();
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        Task SaveAsync();
        Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
        Task<TEntity> GetFirstBySpecAsync(ISpecification<TEntity> specification);
    }
}
