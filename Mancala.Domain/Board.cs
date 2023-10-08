using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Board
{
    public Board(Maybe<BoardId> id, IList<Pit> pitList)
    {
        Id = id;
        PitList = pitList;
    }

    public static Board CreateBoard(PlayerId playerId1, PlayerId playerId2)
    {
        var player1PitList = CreatePitListForPlayer(playerId1);
        var player2PitList = CreatePitListForPlayer(playerId2);

        var pitList = player1PitList.Concat(player2PitList).ToList();

        return new Board(Maybe<BoardId>.None, pitList);
    }

    private static IEnumerable<Pit> CreatePitListForPlayer(PlayerId playerId)
    {
        return new List<Pit>
        {
            Pit.CreatePit(playerId, true),
            Pit.CreatePit(playerId, false),
            Pit.CreatePit(playerId, false),
            Pit.CreatePit(playerId, false),
            Pit.CreatePit(playerId, false),
            Pit.CreatePit(playerId, false),
            Pit.CreatePit(playerId, false),
        };
    }

    public Maybe<BoardId> Id { get; }
    public IList<Pit> PitList { get; init; }

    public void Setup()
    {
        var nonStorePits = PitList.Where(p => !p.IsStore).ToList();
        nonStorePits.ForEach(p => p.NumberOfStones = 4);
    }

    public int TotalStones => PitList.Sum(p => p.NumberOfStones);

    public int GetStonesForPlayer(PlayerId playerId) =>
        PitList.Where(p => p.IsPlayerStore(playerId)).Sum(p => p.NumberOfStones);

    public Result<List<Pit>> GetPlaysForPlayer(PlayerId playerId) =>
        Result.Success(PitList.Where(p => p.IsPlayerPlay(playerId) && p.NumberOfStones > 0).ToList());

    public Result<bool> MoveStonesForPlayer(PlayerId playerId, Pit pit)
    {
        throw new NotImplementedException();
    }
}