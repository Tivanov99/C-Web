namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(
            string text,
            Action<IRequest, IResponse> preRenderAction = null)
            : base(text, ContentType.PlainText, preRenderAction)
        {

        }
    }
}
