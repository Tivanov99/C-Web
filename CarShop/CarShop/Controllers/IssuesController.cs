namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private IssueService issueService;

        public IssuesController(IssueService issueService)
        {
            this.issueService = issueService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (this.User.IsAuthenticated)
            {
                AllIssuesModel model = new();
                model.Issues = issueService
                    .GetCarIssues(carId);



                return this.View(model);
            }
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Add()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Add(string carId)
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
    }
}
