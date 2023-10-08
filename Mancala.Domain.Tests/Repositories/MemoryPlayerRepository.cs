namespace Mancala.Domain.Tests.Repositories;

public class MemoryPlayerRepository : MemoryRepository<Player, PlayerId>
{
    private MemoryPlayerRepository()
        : base(PlayerId.GetRandomPlayerId)
    {
    }

    public static MemoryPlayerRepository CreatePlayerRepository()
    {
        var playerRepository = new MemoryPlayerRepository();

        playerRepository.Add(Player.CreatePlayer(new PlayerName("Connor", "Roy")));
        playerRepository.Add(Player.CreatePlayer(new PlayerName("Kendall", "Roy")));
        playerRepository.Add(Player.CreatePlayer(new PlayerName("Shiv", "Roy")));
        playerRepository.Add(Player.CreatePlayer(new PlayerName("Roman", "Roy")));

        return playerRepository;
    }
}