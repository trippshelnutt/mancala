using CSharpFunctionalExtensions;

namespace Mancala.Domain;

public interface IAggregateRoot<TId>
{
    public Maybe<TId> Id { get; set; }
}