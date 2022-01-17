namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using BasicWebServer.Server.HTTP;

    public class TextFileResponse : Response
    {
        public TextFileResponse(string fileName)
            : base(HttpResponseStatusCode.OK)
        {
            this.FileName = fileName;
            this.Headers.Add(Header.ConteType, ContentType.PlainText);
        }

        public string FileName { get; init; }

        public override string ToString()
        {
            if (File.Exists(this.FileName))
            {
                this.Body = File
                    .ReadAllTextAsync(this.FileName)
                    .Result;

                this.Headers
                    .Add(Header
                        .ContentDisposition,
                        $"attachment; filename=\"{this.FileName}\"");
            }
            return base.ToString();
        }
    }
}
