namespace Mancala.Domain;

public record Player(PlayerId Id, PlayerName Name) : IAggregateRoot<PlayerId>
{
    public PlayerName Name { get; set; } = Name;
}