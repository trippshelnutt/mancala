namespace Mancala.Domain;

public record struct PitId(byte Value)
{
    public static readonly List<PitId> Player1PlayPitIds = new()
    {
        new PitId(2), new PitId(3), new PitId(4), new PitId(5), new PitId(6), new PitId(7)
    };

    public static readonly List<PitId> Player2PlayPitIds = new()
    {
        new PitId(9), new PitId(10), new PitId(11), new PitId(12), new PitId(13), new PitId(14)
    };

    public static readonly PitId Player1StorePitId = new(1);

    public static readonly PitId Player2StorePitId = new(8);
};