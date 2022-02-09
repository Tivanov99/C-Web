using CarShop.Data;
using CarShop.DTOS;
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
        public CarService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
            .First();

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
    }
}
