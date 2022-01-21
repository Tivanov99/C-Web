namespace BasicWebServer.Server.Contracts
{
    using BasicWebServer.Server.Cookies;
    using System.Collections.Generic;
    public interface ICookieCollection : IEnumerable<Cookie>
    {
        void Add(string name, string value);

        bool Contains(string name);

        public string this[string name] { get; }
    }
}
