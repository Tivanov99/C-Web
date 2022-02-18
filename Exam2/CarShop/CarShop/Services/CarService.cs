using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.DataModels;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public CarService(
            IRepository repo,
            IValidationService validationService
            )
        {
            this.repo = repo;
            this.validationService = validationService;
        }
        public List<CarViewModel> AllCars(string userId)
        {
            bool isUserMechanic = GetUserAccessorType(userId);

            if (!isUserMechanic)
            {
                return this.repo
                    .All<Car>()
                    .Where(c => c.OwnerId == userId)
                    .Select(c => new CarViewModel()
                    {
                        PlateNumber = c.PlateNumber,
                        FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count(),
                        RemainingIssues = c.Issues.Where(i => i.IsFixed == false).Count(),
                    })
                    .ToList();
            }

            return this.repo
                .All<Car>()
                .Where(c => c.Issues.Any(i => i.IsFixed == false))
               .Select(c => new CarViewModel()
               {
                   PlateNumber = c.PlateNumber,
                   FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count(),
                   RemainingIssues = c.Issues.Where(i => i.IsFixed == false).Count(),
               })
                    .ToList();
        }


        public (bool, string) Create(CarCreateViewModel carModel, string userId)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService
                .Validate(carModel);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Car car = new Car()
            {
                Model = carModel.Model,
                Year = carModel.Year,
                PictureUrl = carModel.Image,
                OwnerId = userId,
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registered, error);
        }

        private bool GetUserAccessorType(string userId)
            => this.repo.All<User>()
            .Where(u => u.Id == userId)
            .Select(u => u.IsMechanic)
            .FirstOrDefault();
    }
}
