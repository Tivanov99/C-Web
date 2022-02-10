﻿namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Commit
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }
    }
}
