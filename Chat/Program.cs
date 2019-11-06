using System;
using Chat.Decorators;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            IClient client = new ConsoleClient();
            client = new DecoratorBuilder(client)
                .WithAnonymity()
                .WithEncryption()
                .Build();
            var message = new Message("Ronne", "Design pattern course", "I completed task 5");
            client.Send(message);

            Console.ReadKey();
        }
    }
}