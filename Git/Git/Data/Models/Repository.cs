using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            Commits = new();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Commit> Commits { get; set; }
    }
}
