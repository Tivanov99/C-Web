namespace Git.Contracts
{
    using Git.DataForm;
    using Git.Models;
    using System.Collections.Generic;
    public interface IRepositoryService
    {
        List<RepositoryViewModel> GetAll();

        (bool, List<ErrorViewModel>) Validate(CreateRepositoryDataForm repositoryDataForm);

        void Create(CreateRepositoryDataForm repositoryDataForm, string userId);
    }
}
