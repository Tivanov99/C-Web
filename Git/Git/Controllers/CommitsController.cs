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

        public HttpResponse All()
        {
            if (this.User.IsAuthenticated)
            {
                AllCommitsViewModel viewModel = new AllCommitsViewModel()
                {
                    Commits = this.commitService.GetAllCommits()
                };

                return this.View(viewModel);
            }
            return this.Redirect("/Users/Login");
        }
    }
}
