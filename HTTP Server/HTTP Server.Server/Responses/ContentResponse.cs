namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using BasicWebServer.Server.HTTP;
    using System.Text;

    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType,
            Action<IRequest, IResponse> preRenderAction=null)
            : base(HttpResponseStatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            this.PreRenderAction = preRenderAction;

            this.Headers.Add(Header.ConteType, contentType);

            this.Body = content;
        }
        public override string ToString()
        {
            if (this.Body != null)
            {
                string contentLength = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength, contentLength);
            }
            return base.ToString();
        }
    }
}