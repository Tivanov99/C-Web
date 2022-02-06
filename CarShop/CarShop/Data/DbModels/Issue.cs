using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.DbModels
{
    public class Issue
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public Car Car { get; set; }

    }
}
