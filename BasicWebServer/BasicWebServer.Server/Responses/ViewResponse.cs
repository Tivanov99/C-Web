namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';
        public ViewResponse(string viewName, string controllerName)
            : base("", ContentType.Html)
        {

            GetContent(viewName, controllerName);
        }

        private void GetContent(string viewName, string controllerName)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath(
                $"./Views/" +
                viewName.TrimStart(PathSeparator)) +
                ".cshtml";

            SetContent(viewPath);
        }
        private async void SetContent(string viewPath)
        {
            var viewContent = await File.ReadAllTextAsync(viewPath);

            this.Body = viewContent;
        }
    }
}
