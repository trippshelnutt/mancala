using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public enum PitPlayer
{
    Player1,
    Player2
}

public enum PitType
{
    Play,
    Store
}

public class Pit
{
    public Pit(PitId id, PitPlayer player, PitType type, Maybe<BoardId> boardId, byte numberOfStones)
    {
        Id = id;
        Player = player;
        Type = type;
        BoardId = boardId;
        NumberOfStones = numberOfStones;
    }

    public static Pit CreatePit(PitId id, PitPlayer player, PitType type)
    {
        return new Pit(id, player, type, Maybe<BoardId>.None, 0);
    }

    public PitId Id { get; }
    public PitPlayer Player { get; }
    public PitType Type { get; }
    public Maybe<BoardId> BoardId { get; set; }
    public byte NumberOfStones { get; set; }

    public bool IsPlayer1 => Player == PitPlayer.Player1;
    public bool IsPlayer2 => Player == PitPlayer.Player2;

    public bool IsStore => Type == PitType.Store;
    public bool IsPlay => Type == PitType.Play;
}