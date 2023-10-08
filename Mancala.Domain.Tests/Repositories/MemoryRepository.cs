using CSharpFunctionalExtensions;

namespace Mancala.Domain.Tests.Repositories;

public class MemoryRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IAggregateRoot<TId>
{
    private readonly Func<TId> _entityIdFactory;
    private readonly List<TEntity> _entityList = new();

    public MemoryRepository(Func<TId> entityIdFactory)
    {
        _entityIdFactory = entityIdFactory;
    }

    public Result<TEntity> GetById(TId id)
    {
        if (id == null)
        {
            return Result.Failure<TEntity>("Id must not be null.");
        }

        var maybeEntity = _entityList.Find(e => e.Id == id) ?? Maybe<TEntity>.None;

        return maybeEntity.ToResult("Unable to get entity.");
    }

    public Result<IEnumerable<TEntity>> GetAll()
    {
        return _entityList;
    }

    public Result<TEntity> Add(TEntity entity)
    {
        if (entity.Id.HasNoValue)
        {
            entity.Id = _entityIdFactory();
        }

        _entityList.Add(entity);

        return entity;
    }

    public Result<TEntity> Update(TEntity entity)
    {
        // TODO this should save
        return Result.Failure<TEntity>("Not implemented.");
    }
}