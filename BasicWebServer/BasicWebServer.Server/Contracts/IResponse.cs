namespace BasicWebServer.Server.Contracts
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers.Contracts;
    using System;

    public interface IResponse
    {
        public HttpResponseStatusCode StatusCode { get; }

        public IHeaderCollection Headers { get; }

        public string Body { get; set; }

        public Action<IRequest, IResponse> PreRenderAction { get;  }
    }
}
