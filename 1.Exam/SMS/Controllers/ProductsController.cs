namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Models;
    using SMS.Services;

    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Create()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Create(CreateProductModel createProductModel)
        {
            var (isValid, errors) = this.productService
                .ValidateProductData(createProductModel);

            if (!isValid)
            {
                return this.View("/Error", errors);
            }

            this.productService.Create(createProductModel);
            return this.Redirect("/IndexLoggedIn");
        }

    }
}
