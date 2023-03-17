using DILifeTimeSample.Contracts;

namespace DILifeTimeSample.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageTransient _messageTransient;
        private readonly IMessageScoped _messageScoped;
        private readonly IMessageSingleton _messageSingleton;

        public MessageService(IMessageTransient messageTransient, IMessageScoped messageScoped, IMessageSingleton messageSingleton)
        {
            _messageTransient = messageTransient;
            _messageScoped = messageScoped;
            _messageSingleton = messageSingleton;
        }

        public object GetMessage()
        {
            return new
            {
                ServiceTransient = _messageTransient.GuidId,
                ServiceScoped = _messageScoped.GuidId,
                ServiceSingleton = _messageSingleton.GuidId
            };
        }
    }
}
