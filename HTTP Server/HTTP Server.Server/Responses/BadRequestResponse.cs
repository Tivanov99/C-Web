namespace BasicWebServer.Server.Responses.HTTP
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.HTTP;

    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            : base(HttpResponseStatusCode.BadRequest)
        {
        }
    }
}
