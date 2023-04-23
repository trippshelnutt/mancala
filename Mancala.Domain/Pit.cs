namespace Mancala.Domain;

public class Pit
{
    public Pit(PitId id, BoardId boardId, byte numberOfStones)
    {
        Id = id;
        BoardId = boardId;
        NumberOfStones = numberOfStones;
    }

    public static IList<Pit> GeneratePitListForBoard(BoardId boardId) =>
        Enumerable.Range(1, 14).Select(i => new Pit(new PitId((byte)i), boardId, 0)).ToList();

    public PitId Id { get; init; }
    public BoardId BoardId { get; init; }
    public byte NumberOfStones { get; set; }

    public bool IsStore => IsPlayer1Store || IsPlayer2Store;
    public bool IsPlayer1Store => Id == PitId.Player1StorePitId;
    public bool IsPlayer2Store => Id == PitId.Player2StorePitId;

    public bool IsPlayer1Play => PitId.Player1PlayPitIds.Contains(Id);
    public bool IsPlayer2Play => PitId.Player2PlayPitIds.Contains(Id);
}