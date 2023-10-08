using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public record Player(Maybe<PlayerId> Id, PlayerName Name) : IAggregateRoot<PlayerId>
{
    public Maybe<PlayerId> Id { get; set; } = Id;
    public PlayerName Name { get; set; } = Name;

    public static Player CreatePlayer(PlayerName name)
    {
        return new Player(Maybe<PlayerId>.None, name);
    }
}