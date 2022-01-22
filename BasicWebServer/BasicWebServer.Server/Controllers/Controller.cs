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
        public Controller(IRequest request)
        {
            this.Request = request;
        }
        protected IRequest Request { get; set; }

        protected Response Text(string text) => new TextResponse(text);

        protected IResponse Html(string text, ICookieCollection cookies = null)
        {
            IResponse response = new HtmlResponse(text);
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

        protected Response View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName());

        private string GetControllerName()
        => this.GetType().Name
        .Replace(nameof(Controller), string.Empty);
    }
}
