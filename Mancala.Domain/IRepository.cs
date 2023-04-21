namespace Mancala.Domain;

public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot<TId>
{
    public TEntity GetById(TId id);
    public TEntity? FindById(TId id);
    public IEnumerable<TEntity> GetAll();
    public TId Add(TEntity entity);
    public TId Update(TEntity entity);
}