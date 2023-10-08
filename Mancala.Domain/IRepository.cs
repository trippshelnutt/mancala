using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot<TId>
{
    public Result<TEntity> GetById(TId id);
    public Result<IEnumerable<TEntity>> GetAll();
    public Result<TEntity> Add(TEntity entity);
    public Result<TEntity> Update(TEntity entity);
}