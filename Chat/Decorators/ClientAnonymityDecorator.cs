using System;
using System.Collections.Generic;

namespace Chat.Decorators
{
    public class ClientAnonymityDecorator : ClientBaseDecorator
    {
        protected readonly Random Randomizer = new Random();
        protected readonly Dictionary<string, string> AnonymousNames = new Dictionary<string, string>();

        public ClientAnonymityDecorator(IClient client) : base(client) { }

        public override void Send(Message message)
        {
            if (AnonymousNames.TryGetValue(message.Author, out var anonymousName))
                message.Author = anonymousName;
            else
            {
                anonymousName = CreateAnonymousName(message.Author);
                AnonymousNames.Add(message.Author, anonymousName);
                message.Author = anonymousName;
            }
            Decoratee.Send(message);
        }

        protected string CreateAnonymousName(string name)
        {
            while (true)
            {
                var anonymousName = Randomizer.Next(0, int.MaxValue).ToString();
                if (AnonymousNames.ContainsValue(anonymousName)) continue;
                return anonymousName;
            }
        }

        public override IEnumerable<Message> ReceiveMessages() => Decoratee.ReceiveMessages();
    }
}