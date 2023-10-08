using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Board
{
    public Board(Maybe<BoardId> id, IDictionary<PitId, Pit> pitMap)
    {
        Id = id;
        PitMap = pitMap;
    }

    public static Board CreateBoard()
    {
        var pitList = new List<Pit>
        {
            Pit.CreatePit(new PitId(0), PitPlayer.Player1, PitType.Store),
            Pit.CreatePit(new PitId(1), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(2), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(3), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(4), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(5), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(6), PitPlayer.Player1, PitType.Play),
            Pit.CreatePit(new PitId(7), PitPlayer.Player2, PitType.Store),
            Pit.CreatePit(new PitId(8), PitPlayer.Player2, PitType.Play),
            Pit.CreatePit(new PitId(9), PitPlayer.Player2, PitType.Play),
            Pit.CreatePit(new PitId(10), PitPlayer.Player2, PitType.Play),
            Pit.CreatePit(new PitId(11), PitPlayer.Player2, PitType.Play),
            Pit.CreatePit(new PitId(12), PitPlayer.Player2, PitType.Play),
            Pit.CreatePit(new PitId(13), PitPlayer.Player2, PitType.Play),
        };

        var pitMap = pitList.ToDictionary(p => p.Id);

        return new Board(Maybe<BoardId>.None, pitMap);
    }

    public Maybe<BoardId> Id { get; }
    private IDictionary<PitId, Pit> PitMap { get; }

    public void Setup()
    {
        var nonStorePits = PitMap.Values.Where(p => !p.IsStore).ToList();
        nonStorePits.ForEach(p => p.NumberOfStones = 4);
    }

    public int TotalStones => PitMap.Values.Sum(p => p.NumberOfStones);

    public int GetStonesForPlayer1() =>
        PitMap.Values.Where(p => p is { IsPlayer1: true, IsStore: true }).Sum(p => p.NumberOfStones);

    public int GetStonesForPlayer2() =>
        PitMap.Values.Where(p => p is { IsPlayer1: true, IsStore: true }).Sum(p => p.NumberOfStones);

    public Result<IEnumerable<Pit>> GetPlaysForPlayer1() =>
        Result.Success(PitMap.Values.Where(p => p is { IsPlayer1: true, IsStore: false, NumberOfStones: > 0 }));

    public Result<IEnumerable<Pit>> GetPlaysForPlayer2() =>
        Result.Success(PitMap.Values.Where(p => p is { IsPlayer2: true, IsStore: false, NumberOfStones: > 0 }));

    public Result<bool> MoveStones(Pit pit)
    {
        throw new NotImplementedException();
    }
}