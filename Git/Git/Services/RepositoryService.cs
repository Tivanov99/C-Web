namespace Git.Services
{
    using Git.Contracts;
    using System.Collections;

    public class RepositoryService
    {
        private readonly IRepository repository;

        public RepositoryService(IRepository _repository)
        {
            this.repository = _repository;
        }


    }
}
