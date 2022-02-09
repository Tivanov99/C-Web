
namespace CarShop.DTOS
{
    using CarShop.Data.DbModels;
    using System.Collections.Generic;

    public class CarDetailsDTOModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string PictureUrl { get; set; }

        public string PlateNumber { get; init; }

        public List<Issue> Issues { get; set; }
    }
}
