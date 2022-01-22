using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Tools
{
    public static class FileContentAccess
    {
        public static async Task DownloadSitesAsTextFile(
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
    }
}
