namespace Mancala.Domain;

public record GameId(string Value)
{
    public static GameId NewRandomGameId()
    {
        return new GameId(Guid.NewGuid().ToString());
    }
};