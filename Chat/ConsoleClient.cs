using System;
using System.Collections.Generic;

namespace Chat
{
    public class ConsoleClient : IClient
    {
        public void Send(Message message)
        {
            Console.WriteLine(message.ToString());
        }

        public IEnumerable<Message> ReceiveMessages()
        {
            throw new NotImplementedException();
        }
    }
}