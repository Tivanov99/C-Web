using Git.DataForm;
using Git.Models;
using System.Collections.Generic;

namespace Git.Contracts
{
    public interface ICommitService
    {
        (bool, List<ErrorViewModel>) ValidateCommit(CreateCommitDataForm commitDataForm);

        List<CommitViewModel> GetAllCommits(string repositoryId);

        void CreateCommit(CreateCommitDataForm commitDataForm, string creatorId, string repositoryId);
    }
}
