using CarShop.Data;
using CarShop.Data.DbModels;
using CarShop.DataForms;
using CarShop.DTOS;
using CarShop.Validator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private ApplicationDbContext dbContext;
        private CarDataValidator carDataValidator;
        public CarService(ApplicationDbContext dbContext,
            CarDataValidator carDataValidator)
        {
            this.dbContext = dbContext;
            this.carDataValidator = carDataValidator;
        }

        public List<CarDTOModel> GetAllCars(string userId)
        {
            bool isMechanic = IsUserMechanic(userId);

            if (isMechanic)
                return GetCarsForMechanic();

            return GetCarsByUserId(userId);
        }

        private bool IsUserMechanic(string userID)
            => this.dbContext
            .Users
            .Where(u => u.Id == userID)
            .Select(u => u.IsMechanic)
            .FirstOrDefault();

        private List<CarDTOModel> GetCarsByUserId(string userID)
        => this.dbContext
            .Cars
            .AsNoTracking()
            .Where(c => c.Owner.Id == userID)
            .Select(c => new CarDTOModel()
            {
                Id = c.Id,
                PlateNumber = c.PlateNumber,
                FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count(),
                RemainingIssues = c.Issues.Where(i => i.IsFixed == false).Count()
            })
            .ToList();

        private List<CarDTOModel> GetCarsForMechanic()
            => this.dbContext
            .Cars
            .AsNoTracking()
            .Where(c => c.Issues.Any(i => i.IsFixed == false))
            .Select(c => new CarDTOModel()
            {
                Id = c.Id,
                PlateNumber = c.PlateNumber,
                FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count(),
                RemainingIssues = c.Issues.Where(i => i.IsFixed == false).Count()
            })
            .ToList();

        public void CreateCar(AddCarDataForm dataForm, string userId)
        {
            if (this.carDataValidator.ValidateCarData(dataForm))
            {
                string id = Guid.NewGuid().ToString();
                this.dbContext
                    .Cars
                    .Add(new Car()
                    {
                        Id = id.Substring(0, 20),
                        Model = dataForm.Model,
                        Year = dataForm.Year,
                        PictureUrl = dataForm.Image,
                        PlateNumber = dataForm.PlateNumber,
                        OwnerId = userId,
                        Issues = new List<Issue>()
                    });

                this.dbContext
                    .SaveChanges();
            }
        }
    }
}
