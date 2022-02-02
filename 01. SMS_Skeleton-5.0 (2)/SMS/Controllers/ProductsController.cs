using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models;
using SMS.Validator;

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

            if (ItemDataValidator.IsValidItemData(formModel.Name, formModel.Price))
            {

            }

            return this.Redirect("/Index");
        }
    }
}
