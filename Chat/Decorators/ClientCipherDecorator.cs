using System.Collections.Generic;

namespace Chat.Decorators
{
    public class ClientCipherDecorator : ClientBaseDecorator
    {
        protected readonly string EncryptionBeginTag = "<Encrypted>";
        protected readonly string EncryptionEndTag = "</Encrypted>";
        public ClientCipherDecorator(IClient client) : base(client) { }

        public override void Send(Message message)
        {
            message.Text = EncryptionBeginTag + message.Text + EncryptionEndTag;
            Decoratee.Send(message);
        }

        public override IEnumerable<Message> ReceiveMessages()
        {
            foreach (var message in Decoratee.ReceiveMessages())
            {
                if (message.Text.StartsWith(EncryptionBeginTag))
                    message.Text = message.Text.Substring(
                        EncryptionBeginTag.Length,
                        message.Text.Length - (EncryptionBeginTag.Length + EncryptionEndTag.Length));
                yield return message;
            }
        }
    }
}