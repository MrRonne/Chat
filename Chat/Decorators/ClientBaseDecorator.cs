using System.Collections.Generic;

namespace Chat.Decorators
{
    public abstract class ClientBaseDecorator : IClient
    {
        protected readonly IClient Decoratee;

        protected ClientBaseDecorator(IClient client)
        {
            Decoratee = client;
        }

        public abstract void Send(Message message);
        public abstract IEnumerable<Message> ReceiveMessages();
    }
}