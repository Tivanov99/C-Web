using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Contracts;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.Cookies;
using BasicWebServer.Server.Session;
using System.Text;
using System.Web;

public static class Startup
{
    private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";


    private const string FileName = "content.txt";

    private const string Username = "user";
    private const string Password = "user123";

    public static async Task Main()
    {
        await DownloadSitesAsTextFile(FileName
            , new string[] { "https://judge.softuni.org/", "https://softuni.org/" });


        var server = new HttpServer(routes => routes
        .MapGet<HomeController>("/", c => c.Index())
        .MapGet<HomeController>("/Redirect", c => c.Redirect())
        .MapGet<HomeController>("/HTML", c => c.Html())
        .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
        .MapGet<HomeController>("/Content", c => c.Content())
        .MapPost<HomeController>("/Content", c=>c.DownloadContent())
        //.MapGet<HomeController>("/Cookies", new HtmlResponse("", AddCookieAction))
        //.MapGet<HomeController>("/Session", new TextResponse("", DisplaySessionInfoAction))
        //.MapGet<HomeController>("/Login", new HtmlResponse(LoginForm))
        //.MapPost<HomeController>("/Login", new HtmlResponse("", LoginAction))
        //.MapGet<HomeController>("/Logout", new HtmlResponse("", LogoutAction))
        //.MapGet<HomeController>("/UserProfile", new HtmlResponse("", GetUserDataAction))

        );
        await server.Start();
    }

    static void AddFromDataAction(IRequest request, IResponse response)
    {
        ;
        response.Body = string.Empty;
        foreach (var (name, value) in request.Form)
        {
            response.Body += $"{name} - {value}";
            response.Body += Environment.NewLine;
        }

    }

    public delegate int Comparison<in T>(string left, string right);

    private static async Task<string> DownloadWebSiteContent(string url)
    {
        var httpClient = new HttpClient();
        using (httpClient)
        {
            var response = await httpClient
                .GetAsync(url);

            var html = await response
                .Content
                .ReadAsStringAsync();

            return html.Substring(0, 2000);
        }
    }
    private static async Task DownloadSitesAsTextFile(
        string fileName, string[] urls)
        {
            var download = new List<Task<string>>();

            foreach (var url in urls)
            {
                download.Add(DownloadWebSiteContent(url));
            }

            var response = await Task
                .WhenAll(download);

            var responsesString = string.Join(
                Environment.NewLine + new string('-', 100),
                response);

            await File.WriteAllTextAsync(fileName, responsesString);
        }

    private static void AddCookieAction(IRequest request, IResponse response)
    {
        bool requestHasCookies = request.Cookies
            .Any(c => c.Name != Session.SessionCookieName);

        string bodyText = "";

        if (requestHasCookies)
        {
            StringBuilder cookieText = new StringBuilder();

            cookieText.AppendLine("<h1>Cookies</h1>");

            cookieText.Append("<table border='1'><tr><th>Name</th><ht>Value</th></tr>");

            foreach (Cookie currCookie in request.Cookies)
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
            response.Body = bodyText;
        }
        else
        {
            bodyText = "<h1>Cookies set!</h1>";
            response.Body = bodyText;
        }

        if (!requestHasCookies)
        {
            response.Cookies.Add("My-Cookie", "My-Value");
            response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
        }
    }
    private static void DisplaySessionInfoAction(IRequest request, IResponse response)
    {
        bool sessionExist = request.HttpSession
            .ContainsKey(Session.SessionCurrentDateKey);

        string bodyText = "";
        if (sessionExist)
        {
            string currentDate = request.HttpSession[Session.SessionCurrentDateKey];
            bodyText = currentDate;
        }
        else
        {
            bodyText = "Current date stored!";
        }
        response.Body = "";
        response.Body += bodyText;
    }

    private static void LoginAction(IRequest request, IResponse response)
    {
        request.HttpSession.Clear();

        var bodyText = "";

        bool usernameMatches = request.Form["Username"] == Username;
        bool passwordMatches = request.Form["Password"] == Password;

        if (usernameMatches && passwordMatches)
        {
            request.HttpSession[Session.SessionUserKey] = "MyUserId";
            response.Cookies
                .Add(Session.SessionCookieName,
                    request.HttpSession.Id);
            bodyText = "<h3>Logged successfully!</h3>";
        }
        else
        {
            bodyText = LoginForm;
        }
        response.Body = String.Empty;
        response.Body += bodyText;
    }

    private static void LogoutAction(IRequest request, IResponse response)
    {
        request.HttpSession.Clear();
        response.Body = "";
        response.Body += "<h3>Logged out successfully!</h3>";
    }

    private static void GetUserDataAction(IRequest request, IResponse response)
    {
        if (request.HttpSession.ContainsKey(Session.SessionUserKey))
        {
            response.Body = "";
            response.Body += "Currently logged-in user " +
                $"is with username '{Username}'</h3>";
        }
        else
        {
            response.Body = "";
            response.Body += "<h3>You should first log in " +
                "- <a href='/Login'>Login</a></h3>";
        }
    }
}