namespace BasicWebServer.Server.Headers.Contracts
{
    public interface IHeader
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
