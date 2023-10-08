namespace Mancala.Domain;

public record GameId(string Value)
{
    public static GameId GetRandomGameId()
    {
        return new GameId(Guid.NewGuid().ToString());
    }
};