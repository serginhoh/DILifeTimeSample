namespace DILifeTimeSample.Contracts
{
    public interface IMessage
    {
        Guid GuidId { get; }
    }

    public interface IMessageTransient : IMessage { }
    public interface IMessageScoped : IMessage { }
    public interface IMessageSingleton : IMessage { }
}
