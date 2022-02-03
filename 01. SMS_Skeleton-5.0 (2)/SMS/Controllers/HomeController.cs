namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        private SMSDbContext dbContext;

        public HomeController(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                List<Product> products = this.dbContext
                    .Products
                    .Select(x => new Product()
                    {
                        Name = x.Name,
                        Price = x.Price,
                    })
                    .ToList();

                LoggedInUserIndexPageModel model = new(products);
                return this.View(model, "IndexLoggedIn");
            }
            return this.View();
        }
    }
}