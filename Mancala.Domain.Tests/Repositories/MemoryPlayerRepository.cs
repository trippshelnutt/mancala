using CSharpFunctionalExtensions;

namespace Mancala.Domain.Tests.Repositories;

public class MemoryPlayerRepository : IRepository<Player, PlayerId>
{
    private readonly List<Player> _players;

    public MemoryPlayerRepository()
    {
        _players = new List<Player>
        {
            new(new PlayerId(12), new PlayerName("Connor", "Roy")),
            new(new PlayerId(34), new PlayerName("Kendall", "Roy")),
            new(new PlayerId(56), new PlayerName("Shiv", "Roy")),
            new(new PlayerId(78), new PlayerName("Roman", "Roy")),
        };
    }

    public Maybe<Player> GetById(PlayerId id)
    {
        return _players.Find(p => p.Id == id) ?? Maybe<Player>.None;
    }

    public IEnumerable<Player> GetAll()
    {
        return _players;
    }

    public PlayerId Add(Player entity)
    {
        // TODO this should add
        _players.Add(entity);
        return entity.Id;
    }

    public PlayerId Update(Player entity)
    {
        // TODO this should save
        return entity.Id;
    }
}