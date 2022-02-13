namespace Git.Contracts
{
    using Git.DataForm;
    using Git.Models;
    using System.Collections.Generic;
    public interface IRepositoryService
    {
        IEnumerable<RepositoryViewModel> GetAllRepositories();

        (bool, IEnumerable<ErrorViewModel>) ValidateRepository(CreateRepositoryDataForm repositoryDataForm);

        void CreateRepository(CreateRepositoryDataForm repositoryDataForm);

        (bool, IEnumerable<ErrorViewModel>) ValidateCommit(CreateCommitDataForm commitDataForm);

        IEnumerable<CommitViewModel> GetAllCommits();

        void CreateCommit(CreateCommitDataForm commitDataForm);
    }
}
