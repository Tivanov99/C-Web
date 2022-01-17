namespace BasicWebServer.Server.Headers.Contracts
{
    public interface IHeaderCollection : IEnumerable<IHeader>
    {
        void Add(string name, string value);

        public int Count { get; }

        bool ContaisHeader(string name);

        string this[string name]
        {
            get;
        }

    }
}
