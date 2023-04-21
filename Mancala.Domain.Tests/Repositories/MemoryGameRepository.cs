namespace Mancala.Domain.Tests.Repositories;

public class MemoryGameRepository : IRepository<Game, GameId>
{
    private readonly List<Game> _games;

    public MemoryGameRepository()
    {
        var boards = new List<Board>
        {
            new(12),
            new(34)
        };

        _games = new List<Game>
        {
            new("game1", boards[0], 12, 34, PlayerId.None),
            new("game2", boards[1], 56, 78, PlayerId.None)
        };
    }

    public Game GetById(GameId id)
    {
        var game = _games.Find(g => g.Id == id);

        if (game == null)
        {
            throw new Exception("Game not found.");
        }

        return game;
    }

    public Game? FindById(GameId id)
    {
        return _games.Find(g => g.Id == id);
    }

    public IEnumerable<Game> GetAll()
    {
        return _games;
    }

    public GameId Add(Game entity)
    {
        // TODO this should add
        _games.Add(entity);
        return entity.Id;
    }

    public GameId Update(Game entity)
    {
        // TODO this should save
        return entity.Id;
    }
}