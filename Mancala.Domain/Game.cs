using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Game : IAggregateRoot<GameId>
{
    public Game(GameId id, Board board, PlayerId playerId1, PlayerId playerId2, Maybe<PlayerId> currentPlayerId)
    {
        Id = id;
        Board = board;
        PlayerId1 = playerId1;
        PlayerId2 = playerId2;
        CurrentPlayerId = currentPlayerId;
    }

    public GameId Id { get; init; }
    private Board Board { get; }
    private PlayerId PlayerId1 { get; }
    private PlayerId PlayerId2 { get; }
    private Maybe<PlayerId> CurrentPlayerId { get; set; }

    public void Setup()
    {
        Board.Setup();
        CurrentPlayerId = PlayerId1;
    }

    public int TotalStones => Board.TotalStones;
    public int Player1Stones => Board.Player1Stones;
    public int Player2Stones => Board.Player2Stones;

    public Result<IEnumerable<PitId>> GetPlays(PlayerId playerId) =>
        CheckCurrentPlayer(playerId)
            .Bind(FindPlays);

    public Result MakePlay(PlayerId playerId, PitId pitId) =>
        CheckCurrentPlayer(playerId)
            .Bind(p => CheckValidPlay(p, pitId))
            .Bind(_ => Result.Success(true))
            .BindIf(playerId == PlayerId1, _ => Board.MoveStonesForPlayer1(pitId))
            .BindIf(playerId == PlayerId2, _ => Board.MoveStonesForPlayer2(pitId));

    private Result<PlayerId> CheckCurrentPlayer(PlayerId playerId) =>
        Result.Success(playerId)
            .Ensure(p => p == PlayerId1 || p == PlayerId2, "You are not in this game.")
            .Ensure(_ => CurrentPlayerId.HasValue, "Game has not started.")
            .Ensure(p => p == CurrentPlayerId, "Not your turn!");

    private Result<PitId> CheckValidPlay(PlayerId playerId, PitId pitId) =>
        FindPlays(playerId)
            .Ensure(p => p.Contains(pitId), "Invalid play.")
            .Bind(_ => Result.Success(pitId));

    private Result<IEnumerable<PitId>> FindPlays(PlayerId playerId) =>
        Result.Success(Enumerable.Empty<PitId>())
            .BindIf(playerId == PlayerId1, _ => Board.GetPlaysForPlayer1())
            .BindIf(playerId == PlayerId2, _ => Board.GetPlaysForPlayer2());
}