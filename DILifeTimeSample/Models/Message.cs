using DILifeTimeSample.Contracts;

namespace DILifeTimeSample.Models;

public class Message : IMessageTransient, IMessageScoped, IMessageSingleton
{
    private readonly Guid _guidId;

    public Message()
    {
        _guidId = Guid.NewGuid();
    }

    public Guid GuidId => _guidId;
}
