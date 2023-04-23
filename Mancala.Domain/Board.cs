using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Board
{
    public Board(BoardId id)
    {
        Id = id;
        PitList = Pit.GeneratePitListForBoard(id);
    }

    public Board(BoardId id, IList<Pit> pitList)
    {
        Id = id;
        PitList = pitList;
    }

    public BoardId Id { get; }
    public IList<Pit> PitList;

    public void Setup()
    {
        var nonStorePits = PitList.Where(p => !p.IsStore).ToList();
        nonStorePits.ForEach(p => p.NumberOfStones = 4);
    }

    public int TotalStones => PitList.Sum(p => p.NumberOfStones);
    public int Player1Stones => PitList.Where(p => p.IsPlayer1Store).Sum(p => p.NumberOfStones);
    public int Player2Stones => PitList.Where(p => p.IsPlayer2Store).Sum(p => p.NumberOfStones);

    public Result<IEnumerable<PitId>> GetPlaysForPlayer1() =>
        Result.Success(PitList.Where(p => p is { IsPlayer1Play: true, NumberOfStones: > 0 }).Select(p => p.Id));

    public Result<IEnumerable<PitId>> GetPlaysForPlayer2() =>
        Result.Success(PitList.Where(p => p is { IsPlayer2Play: true, NumberOfStones: > 0 }).Select(p => p.Id));

    public Result<bool> MoveStonesForPlayer1(PitId pitId)
    {
        throw new NotImplementedException();
    }

    public Result<bool> MoveStonesForPlayer2(PitId pitId)
    {
        throw new NotImplementedException();
    }
}