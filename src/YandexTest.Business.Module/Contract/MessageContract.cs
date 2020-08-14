namespace YandexTest.Business.Module.Contract
{
    public class MessageContract
    {
        public MessageContractMessage Message { get; set; }
    }

    public class MessageContractMessage
    {
        public MessageContractChat Chat { get; set; }

        public MessageContractLocation Location { get; set; }

        public string Text { get; set; }
    }

    public class MessageContractChat
    {
        public int Id { get; set; }
    }

    public class MessageContractLocation
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
