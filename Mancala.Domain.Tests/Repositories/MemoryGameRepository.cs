using CSharpFunctionalExtensions;

namespace Mancala.Domain.Tests.Repositories;

public class MemoryGameRepository : IRepository<Game, GameId>
{
    private readonly List<Game> _games;

    public MemoryGameRepository()
    {
        var boards = new List<Board>
        {
            new(new BoardId(12)),
            new(new BoardId(34))
        };

        _games = new List<Game>
        {
            new(new GameId("game1"), boards[0], new PlayerId(12), new PlayerId(34), Maybe<PlayerId>.None),
            new(new GameId("game2"), boards[1], new PlayerId(56), new PlayerId(78), Maybe<PlayerId>.None)
        };
    }

    public Maybe<Game> GetById(GameId id)
    {
        return _games.Find(g => g.Id == id) ?? Maybe<Game>.None;
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