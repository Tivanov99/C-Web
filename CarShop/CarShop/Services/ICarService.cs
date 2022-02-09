namespace CarShop.Services
{
    using CarShop.DTOS;
    using System.Collections.Generic;

    public interface ICarService
    {
        List<CarDTOModel> GetAllCars(string userId);

        void CreateCar()
    }
}
