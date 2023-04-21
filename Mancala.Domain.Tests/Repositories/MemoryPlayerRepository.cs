namespace Mancala.Domain.Tests.Repositories;

public class MemoryPlayerRepository : IRepository<Player, PlayerId>
{
    private readonly List<Player> _players;

    public MemoryPlayerRepository()
    {
        _players = new List<Player>
        {
            new(12, new PlayerName("Connor", "Roy")),
            new(34, new PlayerName("Kendall", "Roy")),
            new(56, new PlayerName("Shiv", "Roy")),
            new(78, new PlayerName("Roman", "Roy")),
        };
    }

    public Player GetById(PlayerId id)
    {
        var player = _players.Find(p => p.Id == id);

        if (player == null)
        {
            throw new Exception("Player not found.");
        }

        return player;
    }

    public Player? FindById(PlayerId id)
    {
        return _players.Find(p => p.Id == id);
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