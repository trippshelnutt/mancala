namespace Mancala.Domain.Tests.Repositories;

public class MemoryGameRepository : MemoryRepository<Game, GameId>
{
    private MemoryGameRepository()
        : base(GameId.GetRandomGameId)
    {
    }

    public static MemoryGameRepository CreateGameRepository(MemoryPlayerRepository playerRepository)
    {
        var playersResult = playerRepository.GetAll();

        if (playersResult.IsFailure)
        {
            throw new Exception("Unable to load players.");
        }

        var players = playersResult.Value.ToList();

        var gameRepository = new MemoryGameRepository();

        gameRepository.Add(Game.CreateGame(players[0].Id.Value, players[1].Id.Value));
        gameRepository.Add(Game.CreateGame(players[2].Id.Value, players[3].Id.Value));

        return gameRepository;
    }
}