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
                AllViewsModel model = new();
                model.Issues = issueService
                    .GetCarIssues(carId);


                return this.View(model);
            }
            return this.Redirect("/Users/Login");
        }
    }
}
