namespace CarShop.Controllers
{
    using CarShop.DataForms;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

        [HttpPost]
        public HttpResponse Login(LoginUserDataForm loginUserDataForm)
        {
            if (this.userService.IsUserExist(loginUserDataForm))
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        public HttpResponse Register()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Index");
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterDataForm registerUserDataForm)
        {

            if (!this.userService.IsUsernameAlreadyExists(registerUserDataForm.Username))
            {
                this.userService.Create(registerUserDataForm);
                return this.Login();
            }

            return this.Login();
        }

    }
}
