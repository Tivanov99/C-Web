namespace BasicWebServer.Server.Contracts
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;

    public interface IRequest
    {
        public string Url { get; }

        //public string Path { get;  }

        public HttpRequestMethod RequestMethod { get; }

        public HeaderCollection Headers { get; }

        public ICookieCollection Cookies { get; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; }
    }
}
