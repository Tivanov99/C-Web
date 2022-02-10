namespace CarShop.Controllers
{
    using CarShop.Services;
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

        }
    }
}
