namespace Git.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Repository> Repositories { get; set; }

        public List<Commit> Commits { get; set; }
    }
}
