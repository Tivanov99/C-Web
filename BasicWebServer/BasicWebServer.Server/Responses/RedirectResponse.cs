namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using BasicWebServer.Server.HTTP;
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location)
            : base(HttpResponseStatusCode.Found)
        {
            Headers.Add(Header.Location, location);
        }
    }
}
