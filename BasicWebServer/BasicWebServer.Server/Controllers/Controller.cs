namespace BasicWebServer.Server.Controllers
{
    using BasicWebServer.Server.Contracts;
    using BasicWebServer.Server.Cookies;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Responses;
    using BasicWebServer.Server.Responses.HTTP;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        public Controller(Request request)
        {
            this.Request = request;
        }
        protected Request Request { get; set; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string text, ICookieCollection cookies = null)
        {
            Response response = new HtmlResponse(text);
            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest() => new BadRequestResponse();

        protected Response Unauthorized() => new UnauthorizedResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response File(string fileName) => new TextFileResponse(fileName);

        protected Response NotFound() => new NotFoundResponse();

        protected Response View(Request request, [CallerMemberName] string viewName = "")
            => new ViewResponse(request, viewName, GetControllerName());

        protected Response View(Request request, object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(request, viewName, this.GetControllerName(), model);

        private string GetControllerName()
        => this.GetType().Name
        .Replace(nameof(Controller), string.Empty);
    }
}
