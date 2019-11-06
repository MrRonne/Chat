namespace Chat
{
    public class Message
    {
        public string Author;
        public string Destination;
        public string Text;

        public Message(string author, string destination, string text)
        {
            Author = author;
            Destination = destination;
            Text = text;
        }

        public override string ToString() => $"FROM: {Author}\nTO: {Destination}\n{Text}";
    }
}