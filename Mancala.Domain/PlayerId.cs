namespace Mancala.Domain;

public record PlayerId(long Value)
{
    private static readonly Random Random = new();

    public static PlayerId GetRandomPlayerId()
    {
        var left = Random.Next();
        var right = Random.Next();

        return new PlayerId(((long)left << 32) | (uint)right);
    }
};