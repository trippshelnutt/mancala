namespace Mancala.Domain;

public record struct PlayerId(long Value)
{
    public static readonly PlayerId None = new(0);

    public static implicit operator PlayerId(long value) => new(value);
    public static explicit operator long(PlayerId playerId) => playerId.Value;
};

public record struct PlayerName(string FirstName, string LastName);

public class Player : IAggregateRoot<PlayerId>
{
    public Player(PlayerId id, PlayerName name)
    {
        Id = id;
        Name = name;
    }

    public PlayerId Id { get; init; }
    public PlayerName Name { get; set; }
}