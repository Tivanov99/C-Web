namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Responses.HTTP;
    using System;

    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<
            HttpRequestMethod,
            Dictionary<string, Func<Request, Response>>> _routingTable;

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

        public IRoutingTable Map(HttpRequestMethod method, string url, Func<Request, Response> Func)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(method, nameof(method));

            this._routingTable[method][url] = Func;
            return this;
        }

        public IRoutingTable MapGet(string url, Func<Request, Response> Func)
            => Map(HttpRequestMethod.GET, url, Func);

        public IRoutingTable MapPost(string url, Func<Request, Response> Func)
            => Map(HttpRequestMethod.POST, url, Func);

        public Response MatchRequest(Request request)
        {
            HttpRequestMethod requestMethod = request.RequestMethod;
            string requestUrl = request.Url;

            if (!this._routingTable.ContainsKey(requestMethod) ||
                !this._routingTable[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }
            var func = this._routingTable[requestMethod][requestUrl];
            return func(request);
        }
    }
}
