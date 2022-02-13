namespace Git.Services
{
    using Git.Contracts;
    using Git.Data.Models;
    using Git.DataForm;
    using Git.Models;
    using MyWebServer.Common;
    using System;
    using System.Collections.Generic;

    public class CommitService : ICommitService
    {
        private readonly IRepository repository;
        public CommitService(IRepository _repository)
        {
            this.repository = _repository;
        }
        public void CreateCommit(CreateCommitDataForm commitDataForm)
        {
            throw new NotImplementedException();
        }

        public List<CommitViewModel> GetAllCommits()
        => this.repository.All < Commit >

        public (bool, List<ErrorViewModel>) ValidateCommit(CreateCommitDataForm commitDataForm)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(commitDataForm.Description) ||
                commitDataForm.Description.Length < GlobalConstants.commitDescriptionMinLenght)
            {
                isValid = false;
                errors.Add(new ErrorViewModel($"Commit description should contains minimum {GlobalConstants.commitDescriptionMinLenght} chacacters."));
            }
            return (isValid, errors);
        }
    }
}
