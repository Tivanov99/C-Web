namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using SMS.Validator;

    public class ProductsController : Controller
    {
        private SMSDbContext dbContext;

        public ProductsController(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
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
                Data.Models.Product product = new Data.Models.Product()
                {
                    Name = formModel.Name,
                    Price = formModel.Price,
                    Cart = null
                };
                this.dbContext
                    .Products
                    .Add(product);

                this.dbContext
                    .SaveChanges();
            }

            return this.Redirect("/Index");
        }
    }
}
