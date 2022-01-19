namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text,
            Action<IRequest,IResponse> preRenderAction = null)
            : base(text, ContentType.Html, preRenderAction)
        {

        }
    }
}
