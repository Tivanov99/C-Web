namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Contracts;
    using SMS.Models;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public HttpResponse Index()
        {
            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            if (this.User.IsAuthenticated)
            {
                var products = this.homeService.GetAll();
                var model = new ProductModel() { Products = products };
                return this.View(model);
            }
            return this.Redirect("/Users/Login");
        }
    }
}