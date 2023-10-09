namespace Mancala.Domain;

public record PitId(byte Value)
{
    public static implicit operator PitId(byte value) => new(value);
    public static explicit operator byte(PitId pitId) => pitId.Value;
};