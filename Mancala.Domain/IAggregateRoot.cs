namespace Mancala.Domain;

public interface IAggregateRoot<out TId>
{
    public TId Id { get; }
}