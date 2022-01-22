namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            : base(text, ContentType.Html)
        {

        }
    }
}
