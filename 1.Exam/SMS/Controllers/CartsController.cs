using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Contracts;
using SMS.Models;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;
        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public HttpResponse Details()
        {
            if (this.User.IsAuthenticated)
            {
                var products = this.cartService
                    .AllProducts(this.User.Id);

                if (products != null)
                {
                    CartModelView modelView = new CartModelView();
                    modelView.Products = products;
                    return this.View(modelView);
                }
            }
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Buy()
        {
            if (this.User.IsAuthenticated)
            {
                this.cartService.BuyAll(this.User.Id);
                return this.Redirect("/IndexLoggedIn");
            }
            return this.Redirect("/Users/Login");
        }

        public HttpResponse AddProduct(string productId)
        {
            this.cartService
                .AddProduct(productId, this.User.Id);

            return this.Details();
        }
    }
}
