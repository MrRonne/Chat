using System.Collections.Generic;

namespace Chat
{
    public interface IClient
    {
        void Send(Message message);

        IEnumerable<Message> ReceiveMessages();
    }
}