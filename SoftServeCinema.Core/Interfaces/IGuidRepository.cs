using Ardalis.Specification;


namespace SoftServeCinema.Core.Interfaces
{
    public interface IGuidRepository<TEntity> : IDisposable where TEntity : class, IGuidEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity entity);
      
        void Update(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        Task SaveAsync();
        Task<bool> ExistAsync(Guid id);
        Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
        Task<TEntity> GetFirstBySpecAsync(ISpecification<TEntity> specification);

       
    }
}
