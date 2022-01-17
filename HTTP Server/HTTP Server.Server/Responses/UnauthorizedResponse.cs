namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.HTTP;

    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse()
            : base(HttpResponseStatusCode.Unauthorized)
        {
        }
    }
}