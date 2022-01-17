namespace BasicWebServer.Server.Responses.HTTP
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.HTTP;
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            : base(HttpResponseStatusCode.NotFound)
        {

        }
    }
}
