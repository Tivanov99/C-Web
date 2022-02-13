namespace Git.Contracts
{
    using Git.DataForm;
    using Git.Models;
    using System.Collections.Generic;
    public interface IRepositoryService
    {
        IEnumerable<RepositoryViewModel> GetAll();

        (bool, IEnumerable<ErrorViewModel>) Validate(CreateRepositoryDataForm repositoryDataForm);

        void Create(CreateRepositoryDataForm repositoryDataForm);

        //(bool, IEnumerable<ErrorViewModel>) ValidateCommit(CreateCommitDataForm commitDataForm);

        //IEnumerable<CommitViewModel> GetAllCommits();

        //void CreateCommit(CreateCommitDataForm commitDataForm);
    }
}
