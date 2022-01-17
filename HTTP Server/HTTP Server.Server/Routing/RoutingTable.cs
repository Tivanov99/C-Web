namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Responses.HTTP;
    using System;

    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, IResponse>> _routingTable;

        public RoutingTable()
        {
            _routingTable = new()
            {
                [HttpRequestMethod.GET] = new(),
                [HttpRequestMethod.POST] = new(),
                [HttpRequestMethod.PUT] = new(),
                [HttpRequestMethod.DELETE] = new()
            };
        }

        public IRoutingTable Map(string url, HttpRequestMethod method, IResponse response)
         => method switch
         {
             HttpRequestMethod.GET => this.MapGet(url, response),
             HttpRequestMethod.POST => this.MapPost(url, response),
             _ => throw new InvalidOperationException($"Method '{method}' is not supported")
         };
        public IRoutingTable MapGet(string url, IResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this._routingTable[HttpRequestMethod.GET][url] = response;
            return this;
        }

        public IRoutingTable MapPost(string url, IResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));
            this._routingTable[HttpRequestMethod.POST][url] = response;
            return this;
        }

        public IResponse MatchRequest(IRequest request)
        {
            HttpRequestMethod requestMethod = request.RequestMethod;
            string requestUrl = request.Url;

            if (!this._routingTable.ContainsKey(requestMethod) ||
                !this._routingTable[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }
            return this._routingTable[requestMethod][requestUrl];
        }

    }
}
