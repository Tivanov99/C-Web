namespace Git.Controllers
{
    using Git.Contracts;
    using Git.DataForm;
    using Git.Models;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Collections.Generic;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService _repositoryService)
        {
            this.repositoryService = _repositoryService;
        }

        public HttpResponse All()
       => this.View(this.repositoryService.GetAll());


        public HttpResponse Create()
        {
            if (this.User.IsAuthenticated)
            {
                return this.View();
            }
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryDataForm repositoryDataForm)
        {
            var (isValid, errors) = this.repositoryService
                .Validate(repositoryDataForm);

            if (!isValid)
            {
                return this.View(errors, "/Error");
            }

            try
            {
                this.repositoryService.Create(repositoryDataForm, this.User.Id);
                return this.All();
            }
            catch (Exception ex)
            {
                return this.View(new List<ErrorViewModel>() { new ErrorViewModel(ex.Message) }, "/Error");
            }
        }
    }
}
