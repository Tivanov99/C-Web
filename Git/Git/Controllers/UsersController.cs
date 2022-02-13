namespace Git.Controllers
{
    using Git.Contracts;
    using Git.Models;
    using MyWebServer.Controllers;
    using MyWebServer.DataForm;
    using MyWebServer.Http;
    using System;
    using System.Collections.Generic;

    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (IsUserAuthenticated())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginDataForm dataForm)
        {
            var (isExists, userId) = this.userService.IsUserExists(dataForm);

            if (isExists)
            {
                this.SignIn(userId);
                return this.Redirect("/Repositories/All");
            }
            return this.Login();
        }

        public HttpResponse Register()
        {
            if (this.IsUserAuthenticated())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterDataForm registerData)
        {
            var (isValid, errors) = this.userService
                .ValidateUser(registerData);

            if (!isValid)
            {
                return this.View(errors, "/Error");
            }

            try
            {
                this.userService.CreateUser(registerData);
                return this.Login();
            }
            catch (ArgumentException aex)
            {
                return this.View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
        }
        public HttpResponse LogOut()
        {
            this.SignOut();
            return this.Redirect("/Index");
        }
        private bool IsUserAuthenticated()
        => this.User.IsAuthenticated;
    }
}
