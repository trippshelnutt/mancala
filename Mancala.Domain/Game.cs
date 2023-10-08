using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Game : IAggregateRoot<GameId>
{
    public Game(Maybe<GameId> id, PlayerId playerId1, PlayerId playerId2, Maybe<PlayerId> currentPlayerId, Board board)
    {
        Id = id;
        PlayerId1 = playerId1;
        PlayerId2 = playerId2;
        CurrentPlayerId = currentPlayerId;
        Board = board;
    }

    public static Game CreateGame(PlayerId playerId1, PlayerId playerId2)
    {
        return new Game(
            Maybe<GameId>.None,
            playerId1,
            playerId2,
            Maybe<PlayerId>.None,
            Board.CreateBoard());
    }

    public Maybe<GameId> Id { get; set; }
    public PlayerId PlayerId1 { get; }
    public PlayerId PlayerId2 { get; }
    private Maybe<PlayerId> CurrentPlayerId { get; set; }
    private Board Board { get; }

    public void Setup()
    {
        Board.Setup();
        CurrentPlayerId = PlayerId1;
    }

    public int TotalStones => Board.TotalStones;
    public int Player1Stones => Board.GetStonesForPlayer1();
    public int Player2Stones => Board.GetStonesForPlayer2();

    public Result<IEnumerable<Pit>> GetPlays(PlayerId playerId) =>
        CheckCurrentPlayer(playerId)
            .Bind(FindPlays);

    public Result MakePlay(PlayerId playerId, Pit pit) =>
        CheckCurrentPlayer(playerId)
            .Bind(p => CheckValidPlay(p, pit))
            .Bind(_ => Result.Success(true))
            .Bind(_ => Board.MoveStones(pit));

    private Result<PlayerId> CheckCurrentPlayer(PlayerId playerId) =>
        Result.Success(playerId)
            .Ensure(p => p == PlayerId1 || p == PlayerId2, "You are not in this game.")
            .Ensure(_ => CurrentPlayerId.HasValue, "Game has not started.")
            .Ensure(p => p == CurrentPlayerId, "Not your turn!");

    private Result<Pit> CheckValidPlay(PlayerId playerId, Pit pit) =>
        FindPlays(playerId)
            .Ensure(p => p.Contains(pit), "Invalid play.")
            .Bind(_ => Result.Success(pit));

    private Result<IEnumerable<Pit>> FindPlays(PlayerId playerId) =>
        Result.Success(Enumerable.Empty<Pit>())
            .BindIf(playerId == PlayerId1, _ => Board.GetPlaysForPlayer1())
            .BindIf(playerId == PlayerId2, _ => Board.GetPlaysForPlayer2());
}