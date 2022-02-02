namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using System.Linq;

    public class CartsController : Controller
    {
        private SMSDbContext dbContext;
        public CartsController(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public HttpResponse AddProduct()
        {
            var result = this.Request.Query;
            return this.View();
        }

        public HttpResponse Details()
        {
            if (this.User.IsAuthenticated)
            {
                //TODO : Get all data for current user cart
                return this.View();
            }
            return this.Unauthorized();
        }
    }
}
