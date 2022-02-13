using System.Collections.Generic;

namespace Git.Models
{
    public class AllCommitsViewModel
    {
        public AllCommitsViewModel()
        {
            Commits = new();
        }
        public List<CommitViewModel> Commits { get; set; }
    }
}
