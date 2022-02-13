namespace Git.Models
{
    using System.Collections.Generic;

    public class AllRepositoriesViewModel
    {
        public AllRepositoriesViewModel()
        {
            this.Repositories = new();
        }
        public List<RepositoryViewModel> Repositories { get; set; }
    }
}
