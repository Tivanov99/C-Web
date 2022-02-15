namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Models;

    public class ProductsController : Controller
    {
        public HttpResponse Create()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Create(CreateProductModel createProductModel)
        {

        }
    }
}
