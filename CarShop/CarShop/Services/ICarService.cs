namespace CarShop.Services
{
    using CarShop.DataForms;
    using CarShop.DTOS;
    using System.Collections.Generic;

    public interface ICarService
    {
        List<CarDTOModel> GetAllCars(string userId);

        void CreateCar(AddCarDataForm dataForm, string userId);
    }
}
