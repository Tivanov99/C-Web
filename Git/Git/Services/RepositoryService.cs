namespace Git.Services
{
    using Git.Contracts;
    using Git.DataForm;
    using Git.Models;
    using System.Collections;
    using System.Collections.Generic;

    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repository;

        public RepositoryService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void CreateCommit(CreateCommitDataForm commitDataForm)
        {
            throw new System.NotImplementedException();
        }

        public void CreateRepository(CreateRepositoryDataForm repositoryDataForm)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CommitViewModel> GetAllCommits()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RepositoryViewModel> GetAllRepositories()
        {
            throw new System.NotImplementedException();
        }

        public (bool, IEnumerable<ErrorViewModel>) ValidateCommit(CreateCommitDataForm commitDataForm)
        {
            throw new System.NotImplementedException();
        }

        public (bool, IEnumerable<ErrorViewModel>) ValidateRepository(CreateRepositoryDataForm repositoryDataForm)
        {
            throw new System.NotImplementedException();
        }
    }
}
