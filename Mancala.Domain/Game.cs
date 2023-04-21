namespace Mancala.Domain;

public record struct GameId(string Value)
{
    public static implicit operator GameId(string value) => new(value);
    public static explicit operator string(GameId gameId) => gameId.Value;
}

public class Game : IAggregateRoot<GameId>
{
    public Game(GameId id, Board board, PlayerId playerId1, PlayerId playerId2, PlayerId currentPlayerId)
    {
        Id = id;
        Board = board;
        PlayerId1 = playerId1;
        PlayerId2 = playerId2;
        CurrentPlayerId = currentPlayerId;
    }

    public GameId Id { get; init; }
    public Board Board { get; init; }
    public PlayerId PlayerId1 { get; init; }
    public PlayerId PlayerId2 { get; init; }
    public PlayerId CurrentPlayerId { get; private set; }

    public void Setup()
    {
        Board.Setup();
        CurrentPlayerId = PlayerId1;
    }

    public void MakeSelection(PlayerId playerId, PitId pitId)
    {
        if (CurrentPlayerId == PlayerId.None)
        {
            throw new Exception("Game has not started.");
        }

        if (CurrentPlayerId != playerId)
        {
            throw new Exception("Not your turn!");
        }
    }
}