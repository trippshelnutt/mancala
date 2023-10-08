using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public class Pit
{
    public Pit(PlayerId playerId, bool isStore, Maybe<PitId> id, Maybe<BoardId> boardId, byte numberOfStones)
    {
        PlayerId = playerId;
        IsStore = isStore;
        Id = id;
        BoardId = boardId;
        NumberOfStones = numberOfStones;
    }

    public static Pit CreatePit(PlayerId playerId, bool isStore)
    {
        return new Pit(playerId, isStore, Maybe<PitId>.None, Maybe<BoardId>.None, 0);
    }

    public PlayerId PlayerId { get; }
    public bool IsStore { get; }
    public Maybe<PitId> Id { get; set; }
    public Maybe<BoardId> BoardId { get; set; }
    public byte NumberOfStones { get; set; }

    public bool IsPlayerPlay(PlayerId playerId) => PlayerId == playerId;
    public bool IsPlayerStore(PlayerId playerId) => IsStore && IsPlayerPlay(playerId);
}