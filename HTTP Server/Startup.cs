﻿using BasicWebServer.Server;
using BasicWebServer.Server.Contracts;
using BasicWebServer.Server.Responses;

public static class Startup
{
    private const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

    private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

    private const string FileName = "content.txt";

    public static async Task Main()
    {
        await DownloadSitesAsTextFile(FileName
            , new string[] { "https://judge.softuni.org/", "https://softuni.org/" });


        var server = new HttpServer(routes => routes
                       .MapGet("/", new TextResponse("Hello from the server!"))
                       .MapGet("/Redirect", new RedirectResponse("https://www.youtube.com/watch?v=5tXyXFIIoos"))
                       .MapGet("/HTML", new HtmlResponse(HtmlForm))
                       .MapGet("/Content", new HtmlResponse(DownloadForm))
                       .MapPost("/Content", new TextFileResponse(FileName))
                       .MapPost("/HTML", new TextResponse("", AddFromDataAction))
        )
        .Start();
    }

    static void AddFromDataAction(IRequest request, IResponse response)
    {
        response.Body = string.Empty;
        foreach (var (name, value) in request.Form)
        {
            response.Body += $"{name} - {value}";
            response.Body += Environment.NewLine;
        }

    }

    public delegate int Comparison <in T>(string left, string right);

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
}