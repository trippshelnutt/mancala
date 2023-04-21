namespace Mancala.Domain;

public record struct BoardId(long Value)
{
    public static implicit operator BoardId(long value) => new(value);
    public static explicit operator long(BoardId boardId) => boardId.Value;
}

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
}