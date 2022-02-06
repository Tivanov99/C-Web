namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using System.Text;

    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(Request request, string viewName, string controllerName, object model = null)
            : base("", ContentType.Html)
        {
            GetContent(request, viewName, controllerName, model);
        }

        private void GetContent(Request request, string viewName, string controllerName, object model = null)
        {
            StringBuilder sb = new StringBuilder();

            string layout = GetLayout();

            string navi = GetNavi(request);

            sb.Append(layout);

            sb.Replace("@Rendernavi()", navi);

            string viewPath = GetPath(viewName, controllerName);

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = PopulateModel(viewContent, model);
            }

            this.Body = sb.Replace("@RenderContent()", viewContent).ToString();
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
        private string GetLayout()
        {
            var layout = Path.GetFullPath(
              $"./Views/" +
              "Layout") +
              ".cshtml";
            return File.ReadAllText(layout);
        }

        private string GetNavi(Request request)
        {
            string naviPath = request
                .Session
                .ContainsKey("AuthenticatedUserId") ?
               Path.GetFullPath(
               $"./Views/" +
               "Navigations/" +
               "LoggedInUserNavigation") +
               ".html" :
               Path.GetFullPath(
               $"./Views/" +
               "Navigations/" +
               "LoggedOutNavigation") +
               ".html";

            return File.ReadAllText(naviPath);
        }
    }
}