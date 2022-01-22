namespace BasicWebServer.Server.Contracts
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers.Contracts;
    using System;

    public interface IResponse
    {
        public HttpResponseStatusCode StatusCode { get; }

        public IHeaderCollection Headers { get; }

        public ICookieCollection Cookies { get; }

        public string Body { get; set; }

    }
}
