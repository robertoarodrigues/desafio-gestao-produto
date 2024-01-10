namespace Gestao.Produto.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public int Codigo { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
