namespace BasicWebServer.Demo.Controllers
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.Session;
    using System.Linq;
    using System.Text;
    using System.Web;

    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(IRequest request)
            : base(request)
        {

        }

        public IResponse Index() => Text("Hello from the server!");

        public IResponse Redirect()
            => Redirect("https://www.youtube.com/watch?v=5tXyXFIIoos");

        public IResponse HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public IResponse Html()
            => View();

        public IResponse PostTextFile()
            => File(FileName);

        public IResponse Content() => View();

        public IResponse DownloadContent()
        {
            FileContentAccess.DownloadSitesAsTextFile(FileName,
                new string[] { "https://softuni.bg/" })
                .Wait();

            return File(FileName);
        }

        public IResponse Cookies()
        {
            bool requestHasCookies = this.Request.Cookies
               .Any(c => c.Name != HttpSession.SessionCookieName);

            string bodyText = "";

            if (requestHasCookies)
            {
                StringBuilder cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><ht>Value</th></tr>");

                foreach (Cookie currCookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(currCookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(currCookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");
                bodyText = cookieText.ToString();
                return Html(bodyText);
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");
            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public IResponse Session()
        {
            bool sessionExist = this.Request.HttpSession
            .ContainsKey(HttpSession.SessionCurrentDateKey);

            if (sessionExist)
            {
                string currentDate = this.Request.HttpSession[HttpSession.SessionCurrentDateKey];
                return Text($"Stored date: {currentDate}!");
            }

            return Html("Current date stored!");
        }
    }
}
