namespace Mancala.Domain;

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