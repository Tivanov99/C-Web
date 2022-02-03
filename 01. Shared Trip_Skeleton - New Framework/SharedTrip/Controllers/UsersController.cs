namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using MyWebServer.Services;
    using SharedTrip.Data;
    using System.Linq;

    public class UsersController : Controller
    {
        private ApplicationDbContext dbContext;
        private IPasswordHasher passwordHasher;
        public UsersController(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            this.dbContext = context;
            this.passwordHasher = passwordHasher;
        }
        public HttpResponse Login()
        => this.View();

        [HttpPost]
        public HttpResponse Login(UserLoginForm userLoginForm)
        {
            string hashedPassword = this.passwordHasher
                .HashPassword(userLoginForm.Password);


            bool userIsExist = this.dbContext
                .Users
                .Where(x => x.Username == userLoginForm.Username &&
                x.Password == hashedPassword)
                .Any();

            if (userIsExist)
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

    }
}
