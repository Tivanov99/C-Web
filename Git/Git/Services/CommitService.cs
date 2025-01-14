﻿namespace Git.Services
{
    using Git.Contracts;
    using Git.Data.Models;
    using Git.DataForm;
    using Git.Models;
    using MyWebServer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommitService : ICommitService
    {
        private readonly IRepository repository;

        public CommitService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void CreateCommit(CreateCommitDataForm commitDataForm, string creatorId, string repositoryId)
        {
            Commit commit = new()
            {
                Id = Guid.NewGuid().ToString(),
                Description = commitDataForm.Description,
                CreatorId = creatorId,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = repositoryId
            };
            this.repository.Add<Commit>(commit);
        }

        public List<CommitViewModel> GetAllCommits(string creatorId)
        => this.repository.All<Commit>()
            .Where(c => c.CreatorId == creatorId)
            .Select(c => new CommitViewModel()
            {
                Id = c.Id,
                RepositoryName = c.Repository.Name,
                Description = c.Description,
                CreatedOn = c.CreatedOn.ToString(GlobalConstants.dateTimeFormat)
            })
            .ToList();

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
