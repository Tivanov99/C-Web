namespace CarShop.Controllers
{
    using CarShop.DataForms;
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

                var carData = this.issueService
                    .GetIssueCar(carId);

                model.Issues = issueService
                    .GetCarIssues(carId);

                model.CarYear = carData.CarYear;
                model.CarModel = carData.CarModel;
                model.CarId = carId;

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
        public HttpResponse Add(string carId, AddIssueDataForm dataForm)
        {
            if (this.User.IsAuthenticated)
            {
                this.issueService
                     .CreateCarIssue(carId, dataForm.Description);

                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
    }
}
