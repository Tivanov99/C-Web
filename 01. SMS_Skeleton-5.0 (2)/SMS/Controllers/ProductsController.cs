using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProductFormModel formModel)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }
            return this.Redirect("/Index");
        }
    }
}
