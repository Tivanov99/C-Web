namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;

    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null)
            : base("", ContentType.Html)
        {
            GetContent(viewName, controllerName, model);
        }

        private void GetContent(string viewName, string controllerName, object model = null)
        {
            string viewPath = GetPath(viewName, controllerName);

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            this.Body = viewContent;
        }

        private string GetPath(string viewName, string controllerName)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath(
                $"./Views/" +
                viewName.TrimStart(PathSeparator)) +
                ".cshtml";

            return viewPath;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    pr.Name,
                    Value = pr.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{entry.Name}{closingBrackets}",
                    entry.Value.ToString());
            }
            return viewContent;
        }
    }
}