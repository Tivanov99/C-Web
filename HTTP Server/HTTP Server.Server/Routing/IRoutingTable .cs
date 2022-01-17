namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;

    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HttpRequestMethod method, IResponse response);

        IRoutingTable MapGet(string url, IResponse response);

        IRoutingTable MapPost(string url, IResponse response);

        IResponse MatchRequest(IRequest request);
    }
}
