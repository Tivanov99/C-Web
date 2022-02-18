using CarShop.ViewModels;
using System.Collections.Generic;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        (bool, string) Create(CarCreateViewModel carModel,string userId);

        List<CarViewModel> AllCars(string userId);
    }
}
