namespace Mancala.Domain;

public record struct PitId(byte Value)
{
    public static implicit operator PitId(byte value) => new(value);
    public static explicit operator byte(PitId pitId) => pitId.Value;
};

public class Pit
{
    public Pit(PitId id, BoardId boardId, bool isStore, byte numberOfStones)
    {
        Id = id;
        BoardId = boardId;
        IsStore = isStore;
        NumberOfStones = numberOfStones;
    }

    public static IList<Pit> GeneratePitListForBoard(BoardId boardId)
    {
        return new List<Pit>
        {
            new(1, boardId, true, 0),
            new(2, boardId, false, 0),
            new(3, boardId, false, 0),
            new(4, boardId, false, 0),
            new(5, boardId, false, 0),
            new(6, boardId, false, 0),
            new(7, boardId, false, 0),
            new(8, boardId, true, 0),
            new(9, boardId, false, 0),
            new(10, boardId, false, 0),
            new(11, boardId, false, 0),
            new(12, boardId, false, 0),
            new(13, boardId, false, 0),
            new(14, boardId, false, 0)
        };
    }

    public PitId Id { get; init; }
    public BoardId BoardId { get; init; }
    public bool IsStore { get; init; }
    public byte NumberOfStones { get; set; }
}