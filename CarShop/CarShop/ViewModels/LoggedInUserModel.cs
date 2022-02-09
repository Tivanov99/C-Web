namespace CarShop.ViewModels
{
    using CarShop.DTOS;
    using System.Collections.Generic;

    public class LoggedInUserModel
    {
        public bool IsMechanic { get; set; }

        public List<CarDetailsDTOModel> Cars { get; set; }
    }
}
