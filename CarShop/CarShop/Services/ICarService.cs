namespace CarShop.Services
{
    using CarShop.DTOS;
    using System.Collections.Generic;

    public interface ICarService
    {
        List<CarDTOModel> GetCarsCreatedByUser(string userId);

        List<CarDTOModel> GetAllCarsWithUnfixedIssues();
    }
}
