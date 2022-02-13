namespace Git.Contracts
{
    using Git.DataForm;
    using Git.Models;
    using System.Collections.Generic;
    public interface IRepositoryService
    {
        IEnumerable<RepositoryViewModel> GetAll();

        (bool, IEnumerable<ErrorViewModel>) ValidateRepository(CreateRepositoryForm dataForm);

        void CreateRepository(CreateRepositoryForm dataForm);

        (bool, IEnumerable<ErrorViewModel>) ValidateCommit();
    }
}
