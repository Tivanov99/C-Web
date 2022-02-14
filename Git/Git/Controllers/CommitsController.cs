namespace Git.Controllers
{
    using Git.Contracts;
    using Git.Models;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        public CommitsController(ICommitService _commitService)
        {
            this.commitService = _commitService;
        }

        public HttpResponse All(string repositoryId)
        {
            if (this.User.IsAuthenticated)
            {
                AllCommitsViewModel viewModel = new AllCommitsViewModel()
                {
                    Commits = this.commitService.GetAllCommits(repositoryId)
                };

                return this.View(viewModel);
            }
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Create(string id)
        {
            //if (this.User.IsAuthenticated)
            //{
            CreateCommitModelView modelView = new()
            {
                Id = id,
                RepositoryName =
                };
            var da = this.Request;

            return this.View(modelView);
            //}
            return this.Redirect("/Users/Login");
        }
    }
}
