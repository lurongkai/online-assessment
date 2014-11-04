namespace Oas.Domain
{
    public interface IAggregateMember
    {}

    public interface IEntity : IAggregateMember
    {}

    public interface IAggregateRoot : IAggregateMember
    {}

    public interface IAggregateRoot<T> : IAggregateRoot, IEntity<T>
        where T : IAggregateRoot
    {}

    public interface IEntity<T> : IAggregateMember<T>, IEntity
        where T : IAggregateRoot
    {}

    public interface IAggregateMember<T> : IAggregateMember
        where T : IAggregateRoot
    {}
}