using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class CarCreateViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Car model must be between {2} and {1} characters.")]
        public string Model { get; set; }

        public int Year { get; set; }

        [StringLength(300, ErrorMessage = "Too long image url!")]
        public string Image { get; set; }

        [RegularExpression("@[A-Z]{2}[0-9]{4}[A-Z]{2}", ErrorMessage = "Invalid plate number!")]
        public string PlateNumber { get; set; }
    }
}
