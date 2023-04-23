using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot<TId>
{
    public Maybe<TEntity> GetById(TId id);
    public IEnumerable<TEntity> GetAll();
    public TId Add(TEntity entity);
    public TId Update(TEntity entity);
}