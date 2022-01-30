namespace SMS.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        [ForeignKey(nameof(Cart))]
        //[Required]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
