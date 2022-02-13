namespace Git.Services
{
    using Git.Contracts;
    using Git.DataForm;
    using Git.Models;
    using MyWebServer.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repository;

        public RepositoryService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void Create(CreateRepositoryDataForm repositoryDataForm, string ownerId)
        {
            Data.Models.Repository repo = new Data.Models.Repository()
            {
                Id = Guid.NewGuid().ToString(),
                Name = repositoryDataForm.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repositoryDataForm.RepositoryType == "Public",
                OwnerId = ownerId,
            };
            this.repository.Add<Data.Models.Repository>(repo);
        }

        public List<RepositoryViewModel> GetAll()
        => this.repository
                 .All<Data.Models.Repository>()
                 .Select(r => new RepositoryViewModel()
                 {
                     Id = r.Id,
                     CreatedOn = r.CreatedOn.ToString(GlobalConstants.dateTimeFormat),
                     Name = r.Name,
                     Owner = r.Owner.Username,
                     CommitsCount = r.Commits.Count()
                 })
                 .ToList();

        public (bool, List<ErrorViewModel>) Validate(CreateRepositoryDataForm repositoryDataForm)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(repositoryDataForm.Name) ||
                repositoryDataForm.Name.Length < GlobalConstants.repositoryNameMinLenght ||
                repositoryDataForm.Name.Length > GlobalConstants.repositoryNameMaxLenght)
            {
                isValid = false;
                errors.Add(new ErrorViewModel($"Repository name should be between {GlobalConstants.repositoryNameMinLenght} and {GlobalConstants.repositoryNameMaxLenght} characters!"));
            }

            return (isValid, errors);
        }
    }
}
