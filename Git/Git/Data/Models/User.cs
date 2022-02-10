namespace Git.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Repository> Repositories { get; set; }

        public List<Commit> Commits { get; set; }
    }
}
