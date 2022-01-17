namespace BasicWebServer.Server.HTTP
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using BasicWebServer.Server.Headers.Contracts;
    using System.Text;

    public class Response : IResponse
    {
        public Response(HttpResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers.Add($"{Header.Server}", "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");
        }

        public HttpResponseStatusCode StatusCode { get; init; }

        public IHeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public Action<IRequest, IResponse> PreRenderAction { get; protected set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (IHeader header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            result.AppendLine();

            if (!String.IsNullOrEmpty(this.Body))
            {
                result.Append(this.Body);
            }
            return result.ToString();
        }
    }
}
