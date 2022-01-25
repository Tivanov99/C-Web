namespace BasicWebServer.Server.HTTP
{
    using BasicWebServer.Server.Session;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.Enums;
    using BasicWebServer.Server.Headers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Request
    {
        private static Dictionary<string, HttpSession> Sessions = new();

        public string Url { get; private set; }

        public HttpRequestMethod RequestMethod { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public ICookieCollection Cookies { get; private set; }

        public HttpSession Session { get; private set; }

        public static Request Parse(string requestString)
        {
            string[] lines = requestString.Split("\r\n");


            string[] requestLines = lines
                .First()
                .Split(" ");

            var parsedRequestMethod = ParseRequestMethod(requestLines[0]);

            string url = requestLines[1];

            var headers = ParsePlainTextHeaders(lines.Skip(1).ToArray());

            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join("\r\n", bodyLines);

            var form = ParseForm(body, headers);

            var cookies = ParseCookies(headers);

            var session = GetSession(cookies);

            return new Request
            {
                RequestMethod = parsedRequestMethod,
                Url = url,
                Headers = headers,
                Body = body,
                Form = form,
                Session = session,
                Cookies = cookies,
            };
        }

        private static HeaderCollection ParsePlainTextHeaders(string[] requestLines)
        {
            HeaderCollection headers = new HeaderCollection();
            for (int i = 0; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    string[] splitedHeader = requestLines[i].Split(": ");

                    headers.Add(splitedHeader[0], splitedHeader[1]);
                }
            }
            return headers;
        }
        private static HttpRequestMethod ParseRequestMethod(string method)
        {
            try
            {
                return (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }

        private static Dictionary<string, string> ParseForm(string body, HeaderCollection headers)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.ContaisHeader(Header.ConteType) &&
                headers[Header.ConteType] == ContentType.FormUrlEncoded)
            {
                var parseResult = ParseFormData(body);
                foreach (var (name, value) in parseResult)
                {
                    formCollection.Add(name, value);
                }
            }
            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
        => HttpUtility.UrlDecode(bodyLines)
            .Split("&")
            .Select(part => part.Split("="))
            .Where(part => part.Length == 2)
            .ToDictionary(
            part => part[0],
            part => part[1],
            StringComparer.InvariantCultureIgnoreCase);

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            CookieCollection cookies = new CookieCollection();

            if (headers.ContaisHeader(Header.Cookie))
            {
                string cookiedHeader = headers[Header.Cookie];

                string[] allCookies = cookiedHeader.Split(";");

                foreach (string cookieText in allCookies)
                {
                    string[] cookieParts = cookieText.Split("=");

                    string cookieName = cookieParts[0].Trim();
                    string cookieValue = cookieParts[1].Trim();
                    cookies.Add(cookieName, cookieValue);
                }
            }
            return cookies;
        }

        private static HttpSession GetSession(CookieCollection cookies)
        {
            string sessionId = cookies.Contains(HttpSession.SessionCookieName)
                  ? cookies[HttpSession.SessionCookieName]
                  : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new HttpSession(sessionId);
            }
            return Sessions[sessionId];
        }
    }
}