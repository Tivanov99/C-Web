namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;

    public interface IRoutingTable
    {
        IRoutingTable Map(HttpRequestMethod method, string url, Func<IRequest, IResponse> Func);

        IRoutingTable MapGet(string url,  Func<IRequest, IResponse> Func);

        IRoutingTable MapPost(string url, Func<IRequest, IResponse> Func);

        IResponse MatchRequest(IRequest request);
    }
}
