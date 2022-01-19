namespace BasicWebServer.Server.HTTP
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Request : IRequest
    {
        public Request(string queryString)
        {
            this.Headers = new HeaderCollection();
            Cookies = new CookieCollection();
            Parse(queryString);
        }
        public string Url { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public HeaderCollection Headers { get; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public ICookieCollection Cookies { get; private set; }

        private void Parse(string requestString)
        {
            string[] lines = requestString.Split("\r\n");


            string[] requestLines = lines
                .First()
                .Split(" ");

            ParseRequestMethod(requestLines[0]);

            this.Url = requestLines[1];

            ParsePlainTextHeaders(lines.Skip(1).ToArray());

            string[] bodyLines = lines.Skip(this.Headers.Count + 2).ToArray();

            var body = string.Join("\r\n", bodyLines);

            this.Body = body;

            this.Form = ParseForm(body);

            this.ParseCookies();
        }

        private void ParsePlainTextHeaders(string[] requestLines)
        {
            for (int i = 0; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    string[] splitedHeader = requestLines[i].Split(": ");

                    this.Headers.Add(splitedHeader[0], splitedHeader[1]);
                }
            }
        }
        private void ParseRequestMethod(string method)
        {
            try
            {
                this.RequestMethod = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }

        private Dictionary<string, string> ParseForm(string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (this.Headers.ContaisHeader(Header.ConteType) &&
                this.Headers[Header.ConteType] == ContentType.FormUrlEncoded)
            {
                var parseResult = ParseFormData(body);
                foreach (var (name, value) in parseResult)
                {
                    formCollection.Add(name, value);
                }
            }
            return formCollection;
        }

        private Dictionary<string, string> ParseFormData(string bodyLines)
        => HttpUtility.UrlDecode(bodyLines)
            .Split("&")
            .Select(part => part.Split("="))
            .Where(part => part.Length == 2)
            .ToDictionary(
            part => part[0],
            part => part[1],
            StringComparer.InvariantCultureIgnoreCase);

        private void ParseCookies()
        {
            if (this.Headers.ContaisHeader(Header.Cookie))
            {
                string cookiedHeader = this.Headers[Header.Cookie];

                string[] allCookies = cookiedHeader.Split(";");

                foreach (string cookieText in allCookies)
                {
                    string[] cookieParts = cookieText.Split("=");

                    string cookieName = cookieParts[0].Trim();
                    string cookieValue = cookieParts[1].Trim();
                    this.Cookies.Add(cookieName, cookieValue);
                }
            }
        }
    }
}