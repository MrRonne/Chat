namespace Chat.Decorators
{
    public class DecoratorBuilder
    {
        private IClient _client;

        public DecoratorBuilder(IClient client)
        {
            _client = client;
        }

        public DecoratorBuilder WithAnonymity()
        {
            _client = new ClientAnonymityDecorator(_client);
            return this;
        }

        public DecoratorBuilder WithEncryption()
        {
            _client = new ClientCipherDecorator(_client);
            return this;
        }

        public IClient Build()
        {
            return _client;
        }
    }
}