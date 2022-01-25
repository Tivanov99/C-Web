namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.HTTP;

    public interface IRoutingTable
    {
        IRoutingTable Map(HttpRequestMethod method, string url, Func<Request, Response> Func);

        IRoutingTable MapGet(string url,  Func<Request, Response> Func);

        IRoutingTable MapPost(string url, Func<Request, Response> Func);

        Response MatchRequest(Request request);
    }
}
