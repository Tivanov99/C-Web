namespace Git.Services
{
    using Git.Contracts;
    using Git.DataForm;
    using Git.Models;
    using System.Collections.Generic;

    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repository;

        public RepositoryService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void Create(CreateRepositoryDataForm repositoryDataForm)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public (bool, IEnumerable<ErrorViewModel>) Validate(CreateRepositoryDataForm repositoryDataForm)
        {
            throw new System.NotImplementedException();
        }
    }
}
